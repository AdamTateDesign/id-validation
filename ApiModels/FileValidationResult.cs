using IdValidation.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace id_validation_app.ApiModels
{
    public class FileValidationResult
    {
        public int IdCount => Results?.Count() ?? 0;

        public int InvalidCheckDigitCount => Results?.Count(x => !x.Valid && x.Reason.Equals(ValidationReasons.Checksum)) ?? 0;

        public int InvalidOtherCount => Results?.Count(x => !x.Valid && x.Reason.Equals(ValidationReasons.Other)) ?? 0;

        public int ValidCount => Results?.Count(x => x.Valid) ?? 0;
        public IEnumerable<ValidationResult> Results { get; set; }
    }
}
