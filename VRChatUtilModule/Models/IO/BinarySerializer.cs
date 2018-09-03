using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Models.IO
{
    public class BinarySerializer
    {
        /// <summary>
        /// オブジェクトの内容をファイルから読み込み復元する
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <returns>復元されたオブジェクト</returns>
        public static T LoadFromBinaryFile<T>(string path) where T : class 
        {
            if (!File.Exists(path)) return null;

            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var binaryFormatter = new BinaryFormatter();

                    var json = binaryFormatter.Deserialize(fileStream).ToString();
                    fileStream.Close();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// オブジェクトの内容をファイルに保存する
        /// </summary>
        /// <param name="obj">保存するオブジェクト</param>
        /// <param name="path">保存先のファイル名</param>
        public static void SaveToBinaryFile<T>(T obj, string path) where T : class 
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {

                    var json = JsonConvert.SerializeObject(obj);
                    var binaryFormatter = new BinaryFormatter();

                    //var selector = new SurrogateSelector();
                    //var surrogate = new SerializeSurrogate<T>();
                    //var context = new StreamingContext(StreamingContextStates.All);

                    //selector.AddSurrogate(typeof(T), context, surrogate);

                    //binaryFormatter.SurrogateSelector = selector;

                    binaryFormatter.Serialize(fileStream, json);
                    fileStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
