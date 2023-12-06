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


        [Required]
        public int FeatureID { get; set; }

        [Required(ErrorMessage = "The FeatureName field is required.")]
        [StringLength(50, ErrorMessage = "The FeatureName field must not exceed 50 characters.")]


        public string? FeatureName { get; set; }

        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string Value { get; set; }


        [Required(ErrorMessage = "The Velue field is required.")]
        [StringLength(100, ErrorMessage = "The Value field must not exceed 50 characters.")]
        public string? FeatureDataType { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte ApprovalStatus { get; set; }

        public string? AdminComments { get; set; }

        public string? UserName { get; set; }






        public FeatureClass ToFeature()
        {
            return new FeatureClass
            {

                FeatureID = FeatureID,
                FeatureName = FeatureName,
                Value = Value,

                FeatureDataType = FeatureDataType,


                CreatedAt = CreatedAt,
                ApprovalStatus = Convert.ToByte(ApprovalStatus),
                AdminComments = AdminComments,
                UserName =UserName






            };




        }
    }
}
