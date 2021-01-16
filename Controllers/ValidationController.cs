using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using id_validation_app.ApiModels;
using IdValidation.Domain.Interfaces;
using IdValidation.Domain.Models.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace id_validation_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {

        private readonly ILogger<ValidationController> _logger;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public ValidationController(ILogger<ValidationController> logger, IValidationService validationService, IMapper mapper)
        {
            _logger = logger;
            _validationService = validationService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("validate-id")]
        public async Task<ValidationResult> Validate(string id)
        {
            var result = await _validationService.ValidateById(id);
            return _mapper.Map<ValidationResult>(result);
        }

        [HttpPost]
        [Route("validate-file")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FileValidationResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateFile(IEnumerable<string> ids)
        {
            if (!ids?.Any() ?? false)
            {
                return this.BadRequest("Invalid Format in File");
            }

            var input = new ValidationInput { Ids = ids };

            var validationResults = await _validationService.ValidateFile(input);

            return this.Ok(_mapper.Map<FileValidationResult>(validationResults));
        }
    }
}
