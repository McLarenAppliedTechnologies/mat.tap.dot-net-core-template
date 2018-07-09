using System.Runtime.Serialization;

namespace TEST.API.Analytics.API.DTO
{
    [DataContract]
    public class CourseDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Credits { get; set; }
    }
}
