using System;

namespace WebApplication1.Models
{
    public class Volunteer_Pet
    {
        public int IdVolunteer { get; set; }
        public int IdPet { get; set; }
        public DateTime DateAccepted { get; set; }
        public Volunteer Volunteer { get; set; }
        public Pet Pet { get; set; }
    }
}