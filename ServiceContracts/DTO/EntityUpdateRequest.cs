﻿using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public  class EntityUpdateRequest
    {


        [Required(ErrorMessage = "The EntityName field is required.")]
        [StringLength(50, ErrorMessage = "The EntityName field must not exceed 50 characters.")]
        public string? EntityName { get; set; }




        [Required(ErrorMessage = "The Description  field is required.")]
        [StringLength(200, ErrorMessage = "The  decription must not exceed 200 characters.")]
        public string? Description { get; set; }


        public EntityClass ToEntity()
        {
            return new EntityClass
            {


                EntityName = EntityName,
                Description = Description

            };

        }

    }
}
