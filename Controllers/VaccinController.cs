using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using labo02.Configuration;
using labo02.data;
using labo02.DTO;
using labo02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace labo02.Controllers
{
    [ApiController]
    [Route("vaccin")]
    public class VaccinController : ControllerBase
    {

        private readonly ILogger<VaccinController> _logger;

        private IMapper _mapper;

        private RegistrationContext _context;

        public VaccinController(ILogger<VaccinController> logger, IMapper mapper, RegistrationContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }


        [Route("types"),
        HttpGet]
        public async Task<ActionResult<List<VaccinType>>> GetVaccins() {
            List<VaccinType> vaccinTypes = await _context.VaccinTypes.ToListAsync<VaccinType>();
            return new OkObjectResult(vaccinTypes);
        }


        [Route("locations")]
        [HttpGet]
        public async Task<ActionResult<List<VaccinationLocation>>> GetLocations() {
            List<VaccinationLocation> vaccinationlocation = await _context.VaccinationLocation.ToListAsync<VaccinationLocation>();
            return new OkObjectResult(vaccinationlocation);
        }

        // [Route("registrations")]
        // [HttpGet]
        // public ActionResult<List<VaccinationRegistrationDTO>> GetRegistrationsSmall(string date = "") {
        //     return _mapper.Map<List<VaccinationRegistrationDTO>>(_registrations);
        // }

        // [Route("registrations")]
        // [HttpGet]
        // public ActionResult<List<VaccinationRegistration>> GetRegistrations(string date = "") {
        //     if (String.IsNullOrWhiteSpace(date)) {
        //         return new OkObjectResult(_registrations);
        //     } else {
        //         return _registrations.FindAll(r => r.VaccinationDate == DateTime.Parse(date));
        //     }
        // }

        // [Route("registration")]
        // [HttpPost]
        // public ActionResult<VaccinationRegistration> NewRegistration(VaccinationRegistration _vaccinationRegistration) {

        //     _vaccinationRegistration.VaccinationRegistrationId = Guid.NewGuid();
        //     if (_vaccinTypes.Find(v => v.VaccinTypeId == _vaccinationRegistration.VaccinTypeId) == null)
        //         return new BadRequestObjectResult("Invalid VaccinType");

        //     if (_vaccinLocations.Find(v => v.VaccinationLocationId == _vaccinationRegistration.VaccinationLocationId) == null)
        //         return new BadRequestObjectResult("Invalid VaccinLocation");
            
        //     _registrations.Add(_vaccinationRegistration);

        //     SaveRegistrations();
            
        //     return new OkObjectResult(_vaccinationRegistration);
        // }
    }
}
