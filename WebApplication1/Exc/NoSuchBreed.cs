using System;
using System.Runtime.Serialization;

namespace WebApplication1.Services
{
    [Serializable]
    internal class NoSuchBreed : Exception
    {
        public NoSuchBreed() : base("Breed does not exist")
        {

        }
    }
}