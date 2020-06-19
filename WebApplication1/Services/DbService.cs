using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DbService : IDBService
    {
        private readonly PetsDbContext _context;
    

        public DbService(PetsDbContext context)
        {
            _context = context;
        }
    
        public void AddPet(int id, int idBreedType, string Name, bool IsMale, DateTime DateDeath, DateTime DateAdopted)
        {
            var breedCheck = _context.BreedTypes.FirstOrDefault(p => p.IdBreedType);
            if breedCheck = null {
                throw new NoSuchBreed();
            }
            Pet pet = new Pet();

            pet.IdPet = id;
            pet.IdBreedType = idBreedType;
            pet.IsMale = IsMale;
            pet.DateRegistered = DateTime.Now;
            pet.ApprocimateDateOfBirth = DateDeath;
            pet.DateAdopted = DateAdopted;

            _context.Pets.Add(pet);
            _context.SaveChanges();

        }

        public List<Pet> GetPets(DateTime year)
        {
            var dateRegistered = _context.Pets.Where(p => p.DateRegistered > year).OrderBy(p => p.DateRegistered);
            if (dateRegistered == null) throw new PetDoesNotExist();
            if (year == null) { var res = _context.Pets.Where(p => p.IdPet > 0); }
                return null;
        }
    }


}
