using System.Runtime.Serialization;

namespace VRChatUtilModule.Utility
{
    public class SerializeSurrogate<T> : ISerializationSurrogate where T : class 
    {
        /// <inheritdoc />
        /// <summary>
        /// シリアライズのためのオブジェクトデータ取得
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            if(!(obj is T targetObject)) return;

            //リフレクションを利用してプロパティ情報を取得
            var infoArray = targetObject.GetType().GetProperties();

            foreach (var propertyInfo in infoArray)
            {
                info.AddValue(propertyInfo.Name, propertyInfo.GetValue(targetObject));
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// デシリアライズのためのデータセット
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            if (!(obj is T targetObject)) return null;

            var infoArray = targetObject.GetType().GetProperties();

            foreach (var propertyInfo in infoArray)
            {
                propertyInfo.SetValue(targetObject, info.GetValue(nameof(propertyInfo.Name), propertyInfo.PropertyType));
            }

            // Formatterは, この戻り値を無視する
            return null;
        }
    }
}