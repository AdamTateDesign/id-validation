using IdValidation.Domain.Interfaces;
using IdValidation.Domain.Models.Validation;
using IdValidation.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace IdValidation.Services.Tests
{
    public class ValidationService_ValidateFile_Tests
    {
        private readonly IValidationService _target;
        public ValidationService_ValidateFile_Tests()
        {
            _target = new ValidationService();
        }

        [Fact]
        public async Task CallsValidateByIdForEachIdReturnsPopulatedListModel()
        {
            var input = new ValidationInput { Ids = new string[] { "75441832625", "704723287", "6846869352" } };

            var result = await _target.ValidateFile(input);

            Assert.True(result.Count() == input.Ids.Count());
        }
    }
}
