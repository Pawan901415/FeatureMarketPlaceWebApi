using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class EntityResponse
    {


        public string EntityName {  get; set; }

        public string Description {  get; set; }


        public List<FeatureResponse> FeatureItems { get; set; } = new List<FeatureResponse>();


        public EntityClass ToEntityResponse()
        {
            return new EntityClass
            {


                EntityName = EntityName,
                Description = Description

            };

        }


    }

    public static class EntityExtensions
    {

        //public static EntityResponse ToEntityResponse(this EntityClass entity)
        //{
        //    return new EntityResponse
        //    {
        //       EntityName= entity.EntityName,
        //       Description= entity.Description,
        //    };
        //}


        //public static List<EntityResponse> ToEntityResponseList(this List<EntityClass> entities)
        //{
        //    var entityResponses = new List<EntityResponse>();
        //    foreach (var entity in entities )
        //    {
        //        entityResponses.Add(entity.ToEntityResponse());
        //    }
        //    return entityResponses;
        //}




        public static EntityResponse ToEntityResponse(this EntityClass entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new EntityResponse
            {
                EntityName = entity.EntityName,
                Description = entity.Description,
                // Add other properties as needed
            };
        }

        public static List<EntityResponse> ToEntityResponseList(this List<EntityClass> entities)
        {
            if (entities == null)
            {
                return null;
            }

            var entityResponses = new List<EntityResponse>();

            foreach (var entity in entities)
            {
                var response = entity.ToEntityResponse();
                if (response != null)
                {
                    entityResponses.Add(response);
                }
            }

            return entityResponses;
        }






    }





}




