using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Collections.Generic;

namespace Rappen.XTB.LCG
{
    public static class MetadataHelper
    {
        #region Public Fields

        public static string[] entityProperties = {
            "Description",
            "DisplayName",
            "DisplayCollectionName",
            "EntityColor",
            "IntroducedVersion",
            "IsActivity",
            "IsActivityParty",
            "IsCustomEntity",
            "IsCustomizable",
            "IsIntersect",
            "IsManaged",
            "IsPrivate",
            "IsValidForAdvancedFind",
            "LogicalName",
            "ObjectTypeCode",
            "OwnershipType",
            "PrimaryIdAttribute",
            "PrimaryNameAttribute",
            "SchemaName",
            "OneToManyRelationships",
            "ManyToOneRelationships",
            "ManyToManyRelationships"
        };
        public static string[] entityDetails = { "Attributes" };
        public static string[] attributeProperties = {
            "AttributeType",
            "AttributeTypeName",
            //"AutoNumberFormat",
            "CalculationOf",
            "DateTimeBehavior",
            "DefaultFormValue",
            "DefaultValue",
            "Description",
            "DisplayName",
            "Format",
            "IsCustomAttribute",
            "IsCustomizable",
            "IsManaged",
            "IsPrimaryId",
            "IsPrimaryName",
            "IsValidForCreate",
            "LogicalName",
            "MaxLength",
            "MaxValue",
            "MinValue",
            "OptionSet",
            "Precision",
            "RequiredLevel",
            "SchemaName",
            "Targets",
        };

        #endregion Public Fields

        #region Private Fields

        private static readonly Dictionary<string, EntityMetadata> entities = new Dictionary<string, EntityMetadata>();

        #endregion Private Fields

        #region Public Methods

        public static AttributeMetadata GetAttribute(IOrganizationService service, string entity, string attribute, object value)
        {
            if (value is AliasedValue)
            {
                var aliasedValue = value as AliasedValue;
                entity = aliasedValue.EntityLogicalName;
                attribute = aliasedValue.AttributeLogicalName;
            }
            return GetAttribute(service, entity, attribute);
        }

        public static AttributeMetadata GetAttribute(IOrganizationService service, string entity, string attribute)
        {
            GetEntityMetadataFromServer(service, entity);
            return entities.GetAttribute(entity, attribute);
        }

        private static void GetEntityMetadataFromServer(IOrganizationService service, string entity)
        {
            if (entities.ContainsKey(entity))
            {
                return;
            }

            var response = LoadEntityDetails(service, entity);
            if (response?.EntityMetadata != null
                && response.EntityMetadata.Count == 1
                && response.EntityMetadata[0].LogicalName == entity)
            {
                entities.Add(entity, response.EntityMetadata[0]);
            }
        }

        public static RetrieveMetadataChangesResponse LoadEntities(IOrganizationService service, int majorversion)
        {
            if (service == null)
            {
                return null;
            }

            var eqe = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression(entityProperties)
            };

            if (majorversion > 5)
            {
                eqe.Criteria.Conditions.Add(new MetadataConditionExpression("IsPrivate", MetadataConditionOperator.NotEquals, true));
            }
            var req = new RetrieveMetadataChangesRequest()
            {
                Query = eqe,
                ClientVersionStamp = null
            };
            return service.Execute(req) as RetrieveMetadataChangesResponse;
        }

        public static RetrieveMetadataChangesResponse LoadEntityDetails(IOrganizationService service, string entityName)
        {
            if (service == null)
            {
                return null;
            }

            var eqe = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression(entityProperties)
            };
            eqe.Properties.PropertyNames.AddRange(entityDetails);
            eqe.Criteria.Conditions.Add(new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, entityName));
            var aqe = new AttributeQueryExpression
            {
                Properties = new MetadataPropertiesExpression(attributeProperties)
            };
            aqe.Criteria.Conditions.Add(new MetadataConditionExpression("IsLogical", MetadataConditionOperator.NotEquals, true));
            eqe.AttributeQuery = aqe;
            var req = new RetrieveMetadataChangesRequest
            {
                Query = eqe,
                ClientVersionStamp = null
            };
            return service.Execute(req) as RetrieveMetadataChangesResponse;
        }

        #endregion Public Methods
    }
}