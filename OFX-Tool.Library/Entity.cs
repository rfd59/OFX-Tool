using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library
{
    public static class Entity
    {
        public static bool PropertyEquality(Object? obj1, Object? obj2)
        {
            if (obj1 == null)
            {
                return obj1 == obj2;
            }
            else
            {
                // Check if the object type is a list
                if (obj1.GetType().IsGenericType && obj1.GetType().GetGenericTypeDefinition() == typeof(List<>) && obj2 != null)
                {
                    return ((IEnumerable<object>)obj1).SequenceEqual((IEnumerable<object>)obj2);
                } else
                {
                    return obj1.Equals(obj2);
                }
                
            }
        }
    }
}
