using System;
using System.Collections.Generic;
using System.Linq;

namespace Rappen.XTB.LCG
{
    internal class CSharpUtils
    {
        internal static void GenerateClasses(List<EntityMetadataProxy> entities, string ns)
        {
            foreach (var entity in entities.Where(e => e.Selected))
            {
                foreach (var attribute in entity.Attributes.Where(a => a.Selected))
                {

                }
            }
        }
    }
}