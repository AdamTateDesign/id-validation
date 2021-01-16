using System;
using System.Collections.Generic;
using System.Text;

namespace IdValidation.Domain.Models.Validation
{
    public class ValidationInput
    {
        public IEnumerable<string> Ids { get; set; }
    }
}
