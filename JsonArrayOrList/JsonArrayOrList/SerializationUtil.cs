using System.IO;
using Newtonsoft.Json;

namespace JsonArrayOrList
{
    public static class SerializationUtil
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public static string Serialize(object obj)
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(new JsonTextWriter(stringWriter), obj);
            return stringWriter.GetStringBuilder().ToString();
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
