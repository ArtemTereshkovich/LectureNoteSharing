using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Material_Sharing.DAL.Entities{
    public class CommentLike{
        [Key]
        public string Id {get;set;}

        [Required]
        [ForeignKey("AuthorId")]
        public ApplicationUser Author {get;set;}

        [Required]
        [ForeignKey("CommentId")]
        public Comment Comment {get;set;}
    }
}