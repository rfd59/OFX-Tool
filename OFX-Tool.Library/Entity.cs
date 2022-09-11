using RFD.OFXTool.Library.Attributes;
using RFD.OFXTool.Library.Entities;
using System.Reflection;

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
                }
                else
                {
                    return obj1.Equals(obj2);
                }

            }
        }

        public static string GetHeader(string property)
        {
            return ((Header)GetAttribute<Header, HeaderDocument>(property)).Name;
        }

        public static string GetElement<T>(string property)
        {
            return ((Element)GetAttribute<Element, T>(property)).Name;
        }

        public static string GetElement<T>()
        {
            return ((Element)Attribute.GetCustomAttribute(typeof(T), typeof(Element), true)).Name;
        }

        private  static Attribute GetAttribute<A,T>(string property)
        {
            // This uses C#'s reflection to get the attribute if one exists
            PropertyInfo? propertyInfo = typeof(T).GetProperty(property);
            return Attribute.GetCustomAttribute(propertyInfo, typeof(A), true);
        }

    }
}
