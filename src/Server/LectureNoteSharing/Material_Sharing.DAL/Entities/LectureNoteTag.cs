using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Material_Sharing.DAL.Entities
{
    public class LectureNoteTag
    {
        [Key]
        public string Id {get;set;}

        [Required]
        [ForeignKey("LectureNoteId")]
        public LectureNote LectureNote {get;set;}
        
        [Required]
        [ForeignKey("TageId")]
        public Tag Tag {get;set;}
    }
}