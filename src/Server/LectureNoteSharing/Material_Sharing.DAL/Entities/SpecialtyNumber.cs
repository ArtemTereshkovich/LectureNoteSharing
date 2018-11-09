using System;
using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.DAL.Entities{
    public class SpecialtyNumber{
        [Key]
        public string Id {get;set;}

        [Required]
        public string Title {get;set;}        
    }
}