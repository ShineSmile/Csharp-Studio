using System.IO;
using Newtonsoft.Json;

namespace WcfObjectRecieve
{
    class WcfService : IWcfService
    {

        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public Student GrowUpByObject(Student requestModel)
        {
            requestModel.Age += 1;
            return requestModel;
        }

        public Student GrowUpByStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                var requestModel = JsonConvert.DeserializeObject<Student>(jsonString);
                requestModel.Age += 1;
                return requestModel;
            }
        }
    }
}
