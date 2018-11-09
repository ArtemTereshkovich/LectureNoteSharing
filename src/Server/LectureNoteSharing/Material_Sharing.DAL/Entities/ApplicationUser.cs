using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Material_Sharing.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name{get;set;}
        [Required]
        public string Surname{get;set;}
        public List<LectureNote> LectureNotes {get;set;}
        public List<Comment> Comments {get;set;}
        public List<CommentLike> CommentLikes {get;set;}
        public List<LectureNoteRating> Ratings {get;set;}
    }
}
