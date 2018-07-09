using System;
using System.Runtime.Serialization;

namespace TEST.API.Analytics.API.DTO
{
    [DataContract]
    public class StudentDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstMidName { get; set; }
        [DataMember]
        public DateTime EnrollmentDate { get; set; }
    }
}
