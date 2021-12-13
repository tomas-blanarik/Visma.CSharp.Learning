using System;

namespace VismaIdella.PersonApi.Application.Exceptions
{
    public class EntityConflictException : Exception
    {
        public EntityConflictException(Type entityType)
            : base($"{entityType.Name} already exists with the same parameters")
        { }

        public EntityConflictException(Type entityType, Type childrenType)
            : base($"{entityType.Name} still contains children elements of type {childrenType.Name}")
        { }

        public EntityConflictException(Type entityType, Type childType, int childId)
            : base($"{entityType.Name} doesn't contains child element of type {childType.Name} with ID: '{childId}'")
        { }
    }
}
