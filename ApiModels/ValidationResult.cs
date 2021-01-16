using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace id_validation_app.ApiModels
{
    public class ValidationResult
    {
        public string Input { get; set; }

        public bool Valid { get; set; }

        public string Reason { get; set; }
    }
}
