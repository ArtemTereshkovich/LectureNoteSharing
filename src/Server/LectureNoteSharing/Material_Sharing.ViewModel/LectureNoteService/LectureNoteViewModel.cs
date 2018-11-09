using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Material_Sharing.ViewModel.TagService;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.ViewModel.LectureNoteService{
    public class LectureNoteViewModel{
        public string Id {get;set;}
        
        [Required]
        [Remote(action:"VerifyTitle",controller:"LectureNote")]
        public string Title {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public string Text {get;set;}
        [Required]
        public string SpecialtyNumber {get;set;}
        public string AuthorUsername {get;set;}
        public string DateOfCreate {get;set;}
        public string DateOfEdit {get;set;}
        public string AverageRating {get;set;}
        public IEnumerable<string> Tags {get;set;}
    }
}