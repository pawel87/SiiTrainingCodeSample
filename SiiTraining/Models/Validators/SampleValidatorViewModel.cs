using SiiTraining.Code.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Models.Validators
{
    public class SampleValidatorViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        public string Text { get; set; }

        [CustomYearValidation(ErrorMessage = "Please input valid year")]
        public int Year { get; set; }
    }
}
