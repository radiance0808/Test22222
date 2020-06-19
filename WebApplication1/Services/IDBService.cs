using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    interface IDBService
    {
        void AddPet (int id, int idBreedType,string Name, bool IsMale, DateTime DateDeath, DateTime DateAdopted);
        List<Pet> GetPets(DateTime year);
    }
}
