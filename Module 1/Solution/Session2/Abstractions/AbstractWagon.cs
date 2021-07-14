using System;

namespace Session2.Abstractions
{
    public abstract class AbstractWagon
    {
        protected readonly Guid Id = Guid.NewGuid();

        public abstract void PrintInfo();
    }
}
