using System;

namespace TEST.API.Core.DataManagers
{
    public class EntityNotFoundException : Exception
    {
        public string EntityName { get; private set; }
        public object Id { get; private set; }

        public EntityNotFoundException(string entityName, object id)
            : base($"{entityName} with ID: {id} was not found")
        {
            EntityName = entityName;
            Id = id;
        }
    }
}
