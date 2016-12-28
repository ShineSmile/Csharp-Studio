using System.Runtime.Serialization;

namespace WcfObjectRecieve
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
