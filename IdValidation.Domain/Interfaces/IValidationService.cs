using IdValidation.Domain.Models.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdValidation.Domain.Interfaces
{
    public interface IValidationService
    {
        Task<ValidationResultModel> ValidateById(string id);

        Task<IList<ValidationResultModel>> ValidateFile(ValidationInput input);
    }
}
