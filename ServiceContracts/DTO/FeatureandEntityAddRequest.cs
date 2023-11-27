using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public  class FeatureandEntityAddRequest
    {



        [Required(ErrorMessage = "The EntityName field is required.")]
        [StringLength(50, ErrorMessage = "The EntityName field must not exceed 50 characters.")]
        public string? EntityName { get; set; }




        [Required(ErrorMessage = "The Description  field is required.")]
        [StringLength(200, ErrorMessage = "The  decription must not exceed 200 characters.")]
        public string? Description { get; set; }




        public string? FeatureName { get; set; }

        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string Value { get; set; }


        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string? FeatureDataType { get; set; }








    }
}
