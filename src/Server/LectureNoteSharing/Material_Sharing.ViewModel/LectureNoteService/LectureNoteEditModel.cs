using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Material_Sharing.ViewModel.TagService;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.ViewModel.LectureNoteService{
    public class LectureNoteEditModel{
        public string Id {get;set;}
        
        [Required]
        [Remote(action:"VerifyTitle",controller:"LectureNote")]
        public string Title {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public string Text {get;set;}
        [Required]
        public string SpecialtyNumberId {get;set;}
        public string AuthorId {get;set;}
        public DateTime DateOfCreate {get;set;}
        public DateTime DateOfEdit {get;set;}
        public double AverageRating {get;set;}
        public IEnumerable<TagViewModel> Tags {get;set;}
    }
}