using System;
using System.ComponentModel.DataAnnotations;

namespace labo02.Models
{
    public class VaccinationRegistration
    {
        public Guid VaccinationRegistrationId { get; set; }
        [Required]        
        public string Name { get; set; }
    
        [Required]
        public string FirstName { get; set; }
    
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Range(18,120)]
        public int Age { get; set; }

        [Required]
        public DateTime VaccinationDate { get; set; }
        
        [Required]
        public Guid VaccinTypeId { get; set; }

        [Required]
        public Guid VaccinationLocationId { get; set; }
    }
}
