using System.Collections.Generic;

namespace MapTheState.Web.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue SafeGet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return default(TValue);
            }
        }
    }
}