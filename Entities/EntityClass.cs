using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EntityClass
    {
        [Key]
        [Required]
        public string EntityName { get; set; }

        [Required]
        public string Description { get; set; }



        //navigational property prop
        public virtual ICollection<FeatureClass> ?Features { get; set; }



    }
}