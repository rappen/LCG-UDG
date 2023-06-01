// Kindly stolen from Ivan Ficko's tool FastRecordCounter
// https://github.com/DynamicsNinja/FastRecordCounter/blob/main/FastRecordCounter/FastRecordCounter.cs
// only small adjustments.

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.LCG
{
    internal static class StolenFromDynamicsNinja
    {
        internal static void CountRecords(this PluginControlBase tool, List<EntityMetadata> entities, Action<string, int, string> setCount, Action completed)
        {
            if (tool.ConnectionDetail.OrganizationMajorVersion >= 9)
            {
                ExecuteRetrieveTotalRecordCount(tool, entities, 100, setCount, completed);
            }
            else
            {
                ExecuteLegacyCount(tool, entities, setCount, completed);
            }
        }

        private static void ExecuteRetrieveTotalRecordCount(PluginControlBase tool, List<EntityMetadata> entities, int batchsize, Action<string, int, string> setCount, Action completed)
        {
            tool.WorkAsync(new WorkAsyncInfo
            {
                Message = $"Counting records....{Environment.NewLine}0,00%",
                Work = (w, a) =>
                {
                    var requestsCollection = new OrganizationRequestCollection();

                    requestsCollection.AddRange(entities.Select(e => new RetrieveTotalRecordCountRequest { EntityNames = new[] { e.LogicalName } }));

                    var chunks = Chunk(requestsCollection, batchsize);

                    var options = new ParallelOptions { MaxDegreeOfParallelism = -1 };

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    var finished = 0m;

                    Parallel.ForEach(chunks, options, chunk =>
                    {
                        var svc = ((CrmServiceClient)tool.Service).Clone() ?? tool.Service;

                        var requests = new OrganizationRequestCollection();
                        requests.AddRange(chunk);

                        var countRequest = new ExecuteMultipleRequest()
                        {
                            Requests = requests,
                            Settings = new ExecuteMultipleSettings
                            {
                                ContinueOnError = true,
                                ReturnResponses = true
                            }
                        };

                        var results = (ExecuteMultipleResponseItemCollection)svc.Execute(countRequest).Results["Responses"];

                        for (var index = 0; index < results.Count; index++)
                        {
                            var result = results[index];

                            if (result.Fault != null)
                            {
                                var entityName = ((RetrieveTotalRecordCountRequest)countRequest.Requests[index]).EntityNames.FirstOrDefault();

                                setCount?.Invoke(entityName, -1, result.Fault.Message);
                            }
                            else
                            {
                                var countResponse = ((EntityRecordCountCollection)result.Response.Results.FirstOrDefault().Value).FirstOrDefault();

                                var entityName = countResponse.Key;
                                var count = (int)countResponse.Value;

                                setCount?.Invoke(entityName, count, null);
                            }
                        }

                        finished++;

                        var progress = decimal.Round((finished / chunks.Count) * 100, 2);

                        w.ReportProgress(0, $"Counting records...{Environment.NewLine}{progress}%");
                    });

                    watch.Stop();
                    var ms = (decimal)watch.ElapsedMilliseconds;
                },
                ProgressChanged = e =>
                {
                    tool.SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = (completedargs) =>
                {
                    tool.ShowErrorDialog(completedargs.Error);
                    completed?.Invoke();
                }
            });
        }

        private static void ExecuteLegacyCount(PluginControlBase tool, List<EntityMetadata> entities, Action<string, int, string> setCount, Action completed)
        {
            tool.WorkAsync(new WorkAsyncInfo
            {
                Message = $"Counting records...",
                Work = (w, e) =>
                {
                    foreach (var entity in entities)
                    {
                        w.ReportProgress(0, $"Counting records..{Environment.NewLine}'{entity.DisplayName?.UserLocalizedLabel?.Label}'...");

                        try
                        {
                            ExecuteAggregateCountQuery(tool, entity, setCount);
                        }
                        catch (FaultException<OrganizationServiceFault> ex)
                        {
                            if (ex.Detail.ErrorCode == -2147164125 || ex.Detail.ErrorCode == -2147219456)
                            {
                                ExecuteCountBy5000Records(tool, entity, w, setCount);
                            }
                            else
                            {
                                setCount?.Invoke(entity.LogicalName, -1, ex.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            setCount?.Invoke(entity.LogicalName, -1, ex.Message);
                        }
                    }
                },
                ProgressChanged = e =>
                {
                    tool.SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    completed?.Invoke();
                }
            });
        }

        private static void ExecuteAggregateCountQuery(PluginControlBase tool, EntityMetadata entity, Action<string, int, string> setCount)
        {
            var fetchXml = $@"
            <fetch aggregate='true'>
              <entity name='{entity.LogicalName}'>
                <attribute name='{entity.PrimaryIdAttribute}' alias='cnt' aggregate='count' />
              </entity>
            </fetch>";

            var executeFetchReq = new ExecuteFetchRequest { FetchXml = fetchXml };
            var executeFetchResponse = (ExecuteFetchResponse)tool.Service.Execute(executeFetchReq);
            Regex regex = new Regex(@"<cnt.*>(\d+)<\/cnt>");
            var match = regex.Match(executeFetchResponse.FetchXmlResult);

            if (match.Success)
            {
                var cntString = match.Groups[match.Groups.Count - 1].Value;
                var cnt = int.Parse(cntString);
                setCount(entity.LogicalName, cnt, null);
            }
            else
            {
                setCount(entity.LogicalName, -1, "Error regex");
            }
        }

        private static void ExecuteCountBy5000Records(PluginControlBase tool, EntityMetadata entity, BackgroundWorker worker, Action<string, int, string> setCount)
        {
            try
            {
                var query = new QueryExpression(entity.LogicalName)
                {
                    ColumnSet = new ColumnSet(entity.PrimaryIdAttribute),
                    PageInfo = new PagingInfo
                    {
                        PageNumber = 1,
                        PagingCookie = null,
                        Count = 5000
                    }
                };

                var count = 0;

                while (true)
                {
                    var results = tool.Service.RetrieveMultiple(query);

                    count += results.Entities.Count;

                    if (results.MoreRecords)
                    {
                        query.PageInfo.PageNumber++;
                        query.PageInfo.PagingCookie = results.PagingCookie;
                    }
                    else
                    {
                        break;
                    }

                    worker.ReportProgress(0,
                        $@"Counting records...{Environment.NewLine}'{entity.DisplayName?.UserLocalizedLabel?.Label}'{Environment.NewLine}{count.ToString("#,#", CultureInfo.InvariantCulture)}");
                }

                setCount(entity.LogicalName, count, null);
            }
            catch (Exception ex)
            {
                setCount(entity.LogicalName, -1, ex.Message);
            }
        }

        private static List<List<T>> Chunk<T>(IEnumerable<T> data, int size)
        {
            return data
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}