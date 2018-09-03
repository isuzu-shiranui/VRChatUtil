using System;
using System.Collections.Generic;

namespace VRChatUtilModule.Utility
{
    public static class ListAccessExtention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool TryGetElement<T>(this IList<T> list, int index)
        {
            return index <= list.Count || index >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T GetElementOrDefault<T>(this IList<T> list, int index)
        {
            try
            {
                return list.TryGetElement(index) ? list[index] : default(T);
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool TryGetElement<T>(this T[] list, int index)
        {
            return index <= list.Length || index >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T GetElementOrDefault<T>(this T[] list, int index)
        {
            try
            {
                return list.TryGetElement(index) ? list[index] : default(T);
            }
            catch (Exception)
            {

                return default(T);
            }
        }
    }
}
