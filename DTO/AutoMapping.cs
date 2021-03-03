using System;
using AutoMapper;
using labo02.Models;

namespace labo02.DTO
{
    public class AutoMapping : Profile
    {
        
        public AutoMapping() {
            CreateMap<VaccinationRegistration, VaccinationRegistrationDTO>();
        }
    }
}
