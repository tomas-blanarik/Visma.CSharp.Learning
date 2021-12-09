using System;

namespace CSharpLearning.WebAPI.Services
{
    public class Service : IService
    {
        public int Read()
        {
            return new Random().Next();
        }

        public void Write()
        {
            // do nothing
        }
    }
}
