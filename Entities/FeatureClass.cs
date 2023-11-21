using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class FeatureClass
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureID { get; set; }

        [Required]
        public string FeatureName { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string FeatureDataType { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte ApprovalStatus { get; set; }

        public string AdminComments { get; set; }

        public int UserID { get; set; }

        [ForeignKey("Entity")]
        public string EntityName { get; set; }

        public virtual EntityClass Entity { get; set; }
    }
}
