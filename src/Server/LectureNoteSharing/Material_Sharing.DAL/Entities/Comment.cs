using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Material_Sharing.DAL.Entities
{
    public class Comment
    {
        [Key]
        public string Id {get;set;}

        [Required]
        [ForeignKey("LectureNoteId")]
        public LectureNote LectureNote {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date {get;set;}

        [Required]
        public string CommentText {get;set;}

        [Required]
        [ForeignKey("AuthorId")]
        public ApplicationUser Author {get;set;}

        public List<CommentLike> CommentLikes {get;set;}
        
    }
}
