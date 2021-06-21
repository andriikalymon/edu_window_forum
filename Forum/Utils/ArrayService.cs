using System;
using System.Collections.Generic;
using System.Linq;
namespace Forum.Web.Utils
{
    public static class ArrayService
    {
        public static string[] ConcatArray(string[] array, params string[] optional)
        {
            var strings = new List<string>();
            foreach (var item in array)
            {
                strings.Add(item);
            }
            foreach (var item in optional)
            {
                strings.Add(item);
            }

            return strings.ToArray();
        }
    }
}
