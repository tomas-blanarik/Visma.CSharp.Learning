using System;

namespace VismaIdella.PersonApi.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType, int entityId)
            : base($"{entityType.Name} with ID '{entityId}' not found")
        { }
    }
}
