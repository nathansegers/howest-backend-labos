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
using labo02.DTO;
using labo02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace labo02.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("vaccin")]
    public class VaccinController : ControllerBase
    {

        private CSVSettings _settings;
        private readonly ILogger<VaccinController> _logger;

        private static List<VaccinType> _vaccinTypes;
        private static List<VaccinationLocation> _vaccinLocations;

        private static List<VaccinationRegistration> _registrations;

        private IMapper _mapper;

        public VaccinController(ILogger<VaccinController> logger, IOptions<CSVSettings> settings, IMapper mapper)
        {
            _settings = settings.Value;
            _logger = logger;
            _mapper = mapper;

            if (_vaccinTypes == null)
                _vaccinTypes = new List<VaccinType>();
                _vaccinTypes = ReadCSVVaccins();
            

            if (_vaccinLocations == null) {
                _vaccinLocations = new List<VaccinationLocation>();
                _vaccinLocations = ReadCSVLocations();
            }

            if (_registrations == null) {
                _registrations = new List<VaccinationRegistration>();
                _registrations = ReadCSVRegistrations();
            }
        }

        private List<VaccinType> ReadCSVVaccins()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false, Delimiter = ";"
            };

            using(var reader = new StreamReader(_settings.Vaccins)) {
                using(var csv = new CsvReader(reader, config)) {
                    var records = csv.GetRecords<VaccinType>();
                    return records.ToList<VaccinType>();
                };
            }
        }

        private List<VaccinationLocation> ReadCSVLocations()
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false, Delimiter = ";"
            };

            using(var reader = new StreamReader(_settings.Locations)) {
                using(var csv = new CsvReader(reader, config)) {
                    var records = csv.GetRecords<VaccinationLocation>();
                    return records.ToList<VaccinationLocation>();
                };
            }
        }

        private List<VaccinationRegistration> ReadCSVRegistrations()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false, Delimiter = ";", MissingFieldFound = null
            };

            using(var reader = new StreamReader(_settings.Registrations)) {
                using(var csv = new CsvReader(reader, config)) {
                    var records = csv.GetRecords<VaccinationRegistration>();
                    return records.ToList<VaccinationRegistration>();
                };
            }
        }

        [Route("types"),
        HttpGet]
        public ActionResult<List<VaccinType>> GetVaccins() {
            return new OkObjectResult(_vaccinTypes);
        }

        [Route("locations")]
        [HttpGet]
        public ActionResult<List<VaccinationLocation>> GetLocations() {
            return new OkObjectResult(_vaccinLocations);
        }

        [Route("registrations")]
        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<List<VaccinationRegistrationDTO>> GetRegistrationsSmall(string date = "") {
            return _mapper.Map<List<VaccinationRegistrationDTO>>(_registrations);
        }

        [Route("registrations")]
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<List<VaccinationRegistration>> GetRegistrations(string date = "") {
            if (String.IsNullOrWhiteSpace(date)) {
                return new OkObjectResult(_registrations);
            } else {
                return _registrations.FindAll(r => r.VaccinationDate == DateTime.Parse(date));
            }
        }

        // [Route("registrations")]
        // [HttpGet]
        // public ActionResult<List<VaccinationRegistration>> GetRegistrations() {
        //     return new OkObjectResult(_registrations);
        // }

        [Route("registration")]
        [HttpPost]
        public ActionResult<VaccinationRegistration> NewRegistration(VaccinationRegistration _vaccinationRegistration) {

            _vaccinationRegistration.VaccinationRegistrationId = Guid.NewGuid();
            if (_vaccinTypes.Find(v => v.VaccinTypeId == _vaccinationRegistration.VaccinTypeId) == null)
                return new BadRequestObjectResult("Invalid VaccinType");

            if (_vaccinLocations.Find(v => v.VaccinationLocationId == _vaccinationRegistration.VaccinationLocationId) == null)
                return new BadRequestObjectResult("Invalid VaccinLocation");
            
            _registrations.Add(_vaccinationRegistration);

            SaveRegistrations();
            
            return new OkObjectResult(_vaccinationRegistration);
        }

        async private void SaveRegistrations()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                  HasHeaderRecord = false, Delimiter = ";"
            };

            using (var writer = new StreamWriter(_settings.Registrations))
            using (var csv = new CsvWriter(writer, config))
            {
                await csv.WriteRecordsAsync(_registrations);
            }
        }
    }
}
