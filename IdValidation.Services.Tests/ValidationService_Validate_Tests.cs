using IdValidation.Domain.Constants;
using IdValidation.Domain.Interfaces;
using IdValidation.Services.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace IdValidation.Services.Tests
{
    public class ValidationService_Validate_Tests
    {
        private readonly IValidationService _target;
        public ValidationService_Validate_Tests()
        {
            _target = new ValidationService();
        }

        [Theory]
        [InlineData("9071986497", false, "checksum")]
        [InlineData("7859089345", true, "")]
        [InlineData("7624800153", false, "checksum")]
        [InlineData("75441832625", false, "other")]
        [InlineData("704723287", false, "other")]
        [InlineData("6846869352", true , "")]
        [InlineData("6841458511", true, "")]
        [InlineData("6527761720", false, "checksum")]
        [InlineData("5970570118", true, "")]
        [InlineData("5188230615", false, "checksum")]
        [InlineData("5128574185", false, "checksum")]
        [InlineData("5081617317", true, "")]
        [InlineData("4257451659", true, "")]
        [InlineData("2689955320", false, "checksum")]
        [InlineData("2403033374", true, "")]
        [InlineData("1837780620", true, "")]
        [InlineData("1741881960", false, "checksum")]
        [InlineData("0525925273", true, "")]
        [InlineData("0292742443", false, "checksum")]
        [InlineData("0011942946", true, "")]
        public async Task IdIsValidFormatValidatesCorrectly(string id, bool expected, string expectedReason)
        {
            var result = await _target.ValidateById(id);
            Assert.Equal(expected, result.Valid);
            Assert.Equal(expectedReason, result.Reason);
        }

        [Theory]
        [InlineData("rewrewrew")]
        [InlineData("1234567891011")]
        [InlineData("$£$£CorrUptId$£%^")]
        public async Task InvalidIdAlwaysReturnsFalseWithReasonOther(string id)
        {
            var result = await _target.ValidateById(id);
            Assert.False(result.Valid);
            Assert.True(result.Reason == ValidationReasons.Other);

        }
    }
}
