using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Material_Sharing.DAL.Entities
{
    public class LectureNoteRating
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Rating { get; set; }

        [Required]
        [ForeignKey("LectureNoteId")]
        public LectureNote LectureNote{get;set;}

        [Required]
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}