using System;

namespace VismaIdella.PersonApi.Application.Exceptions
{
    public class EntityConflictException : Exception
    {
        public EntityConflictException(Type entityType)
            : base($"{entityType.Name} already exists with the same parameters")
        { }

        public EntityConflictException(Type entityType, Type childrenType)
            : base($"{entityType.Name} still contains children element of type {childrenType.Name}")
        { }
    }
}
