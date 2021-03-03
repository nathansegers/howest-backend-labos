using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using labo02.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace labo02.Controllers
{
    [ApiController]
    [Route("/test")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;
        private DBSettings _settings;

        public TestController(ILogger<TestController> logger, IOptions<DBSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        [HttpGet]
        public DBSettings Get()
        {
            return _settings;
        }
    }
}
