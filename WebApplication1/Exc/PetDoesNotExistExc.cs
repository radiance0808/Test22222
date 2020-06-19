using System;
using System.Runtime.Serialization;

namespace WebApplication1.Services
{
    [Serializable]
    internal class PetDoesNotExist : Exception
    {
        public PetDoesNotExist() : base("Pet does not exist")
        {

        }
    }
}