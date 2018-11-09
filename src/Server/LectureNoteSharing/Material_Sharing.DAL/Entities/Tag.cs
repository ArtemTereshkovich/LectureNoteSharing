using System;
using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.DAL.Entities{
    public class Tag{
        [Key]
        public string Id {get;set;}

        [Required]
        public string Title {get;set;}

        [Required]
        public int CountUses {get;set;} 
    }
}