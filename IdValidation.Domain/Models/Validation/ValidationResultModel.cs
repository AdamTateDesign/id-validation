using System;
using System.Collections.Generic;
using System.Text;

namespace IdValidation.Domain.Models.Validation
{
    public class ValidationResultModel
    {
        public string Input { get; set; }

        public bool Valid { get; set; }

        public string Reason { get; set; }
    }
}
