using Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class FeatureAddRequest
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

        public string ? AdminComments { get; set; }

        public int? UserID { get; set; }

        public string EntityName { get; set; }




        

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
                UserID =Convert.ToInt32( UserID),
                EntityName = EntityName
            
            
            
            
            
            
            };





        }

    }

    public static class FeatureAddRequestExtension
    {



        public static List<FeatureClass> ToFeature(this List<FeatureAddRequest> FeatureItemRequests)
        {

            var FeatureItems = new List<FeatureClass>();

            foreach (var FeatureItemRequest in FeatureItems)
            {
                var FeatureItem = new FeatureClass {
                
               FeatureID=FeatureItemRequest.FeatureID,
               

               FeatureName = FeatureItemRequest.FeatureName,

               Value = FeatureItemRequest.Value,
               FeatureDataType = FeatureItemRequest.FeatureDataType,

               AdminComments = FeatureItemRequest.AdminComments,

               UserID = FeatureItemRequest.UserID,

               CreatedAt= FeatureItemRequest.CreatedAt,
               ApprovalStatus= FeatureItemRequest.ApprovalStatus,
               EntityName= FeatureItemRequest.EntityName,
                
                
                
                
                };

                FeatureItems.Add(FeatureItem);


            }
            return FeatureItems;

        }
    }





}
