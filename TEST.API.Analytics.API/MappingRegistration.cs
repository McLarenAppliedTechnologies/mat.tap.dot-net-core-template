using System;
using AutoMapper;
using TEST.API.Analytics.API.DO;
using TEST.API.Analytics.API.DTO;

namespace TEST.API.Analytics.API
{
    /// <summary>
    /// Auto mapper registration.
    /// </summary>
    public class MappingRegistration
    {
        /// <summary>
        /// Method where DTO and DO object mappings are registered.
        /// </summary>
        public void RegisterMapping(IMapperConfigurationExpression configuration)
        {
            FromDtoToDo(configuration);
            FromDoToDto(configuration);
        }

        private void FromDoToDto(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<StudentDO, StudentDTO>();
            configuration.CreateMap<EnrollmentDO, EnrollmentDTO>();
        }

        private void FromDtoToDo(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<StudentDTO, StudentDO>();
            configuration.CreateMap<EnrollmentDTO, EnrollmentDO>();
        }
    }
}
