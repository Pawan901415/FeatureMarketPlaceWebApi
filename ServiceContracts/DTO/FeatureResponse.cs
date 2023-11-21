using Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class FeatureResponse
    {


        public int FeatureId { get; set; }


        public string FeatureName { get; set; }


        public string FeatureDataType { get; set; }


        public DateTime CreatedAt { get; set; }


        public byte ApprovalStatus { get; set; }


        public string AdminComments { get; set; }


        public int UserId { get; set; }


        public string EntityName { get; set; }

        public string Value { get; set; }



    }





    public static class FeatureResponseExtensions
    {

        public static FeatureResponse ToFeatureResponse(this FeatureClass feature)
        {
            return new FeatureResponse
            {
                FeatureId = feature.FeatureID,
                FeatureName = feature.FeatureName,
                FeatureDataType = feature.FeatureDataType,
                ApprovalStatus = feature.ApprovalStatus,



                AdminComments = feature.AdminComments,

                 UserId=feature.UserID,
                EntityName = feature.EntityName,


                CreatedAt = feature.CreatedAt,
                Value = feature.Value







            };
        }


        public static List<FeatureResponse> ToFeatureResponseList(this List<FeatureClass> features)
        {
            var featureResponses = new List<FeatureResponse>();
            foreach (var feature in features)
            {
                featureResponses.Add(feature.ToFeatureResponse());
            }
            return featureResponses;
        }









    }

}
