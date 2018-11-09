using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.DAL.Entities
{
    public class LectureNote
    {
        [Key]
        public string Id {get;set;}

        [Required]
        public string Title {get;set;}

        [Required]
        public string Description {get;set;}

        [Required]
        public string Text {get;set;}
        
        [Required]
        [ForeignKey("SpecialtyId")]
        public SpecialtyNumber Specialty {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateOfCreate {get;set;}
        
        public DateTime DateOfLastChange {get;set;}

        [Required]
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }

        public double AverageRating {get;set;}
        
        public List<Comment> Comments {get;set;}
        public List<LectureNoteRating> Ratings {get;set;}
        public List<LectureNoteTag> Tags{get;set;}
    }
}
