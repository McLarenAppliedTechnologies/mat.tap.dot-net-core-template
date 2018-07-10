using System.Runtime.Serialization;
using TEST.API.Analytics.API.DO;

namespace TEST.API.Analytics.API.DTO
{
    [DataContract]
    public class EnrollmentDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public Grade? Grade { get; set; }
    }
}
