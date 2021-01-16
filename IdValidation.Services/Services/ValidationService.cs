using AutoMapper;
using IdValidation.Domain.Constants;
using IdValidation.Domain.Interfaces;
using IdValidation.Domain.Models.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdValidation.Services.Services
{
    public class ValidationService : IValidationService
    {

        public Task<ValidationResultModel> ValidateById(string id)
        {
            return Task.Run(() =>
            {
                var result = new ValidationResultModel() { Input = id };

            if (!id.Length.Equals(10) || !id.All(char.IsDigit))
             {
                    result.Valid = false;
                    result.Reason = ValidationReasons.Other;
             }
             else
             {
                    int checkDigit = int.Parse(id.Substring(id.Length - 1));
                    var idWithoutCheck = id.Remove(id.Length - 1);

                    var calculatedRemainer = this.CalculcateChecksumResult(idWithoutCheck);
                    result.Valid = IsCheckDigitCorrect(calculatedRemainer, checkDigit);
                    result.Reason = !result.Valid ? ValidationReasons.Checksum : string.Empty;
             }
              
                return result;
            });
        }

        public async Task<IList<ValidationResultModel>> ValidateFile(ValidationInput input)
        {
            var models = new List<ValidationResultModel>();

            foreach (var id in input.Ids)
            {
                models.Add((await this.ValidateById(id)));
            }

            return models;
        }

        private int CalculcateChecksumResult(string id)
        {
            int startingWeight = 11;
            var intList = id.Select(digit => int.Parse(digit.ToString()));
            var total = intList.Sum(x =>
            {
                var next = x * startingWeight;
                startingWeight -= 1;
                return next;
            });

            var remainder = total % 12;
            return 12 - remainder;
        }

        private bool IsCheckDigitCorrect(int remainder, int checkDigit)
        {
            return remainder switch
            {
                10 => false,
                12 => false,
                11  => (checkDigit == 0),
                _ => (remainder.Equals(checkDigit))
            };
        } 
    }
}
