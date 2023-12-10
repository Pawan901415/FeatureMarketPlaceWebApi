using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class FeatureUpdateRequest
    {


       

        [Required(ErrorMessage = "The FeatureName field is required.")]
        [StringLength(50, ErrorMessage = "The FeatureName field must not exceed 50 characters.")]


        public string? FeatureName { get; set; }

        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string Value { get; set; }


        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string? FeatureDataType { get; set; }







        public FeatureClass ToFeature()
        {
            return new FeatureClass
            {


                FeatureName = FeatureName,
                Value = Value,

                FeatureDataType = FeatureDataType,


                
               

                






            };




        }
    }
}
