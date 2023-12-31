﻿using Entities;
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






        public static EntityResponse ToEntityResponse(this EntityClass entity)
        {
            if (entity == null)
            {
                return null;
            }

            var entityResponse = new EntityResponse
            {
                EntityName = entity.EntityName,
                Description = entity.Description,
            };

            if (entity.Features != null)
            {
                entityResponse.FeatureItems = entity.Features.Select(feature => feature.ToFeatureResponse()).ToList();
            }

            return entityResponse;
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




