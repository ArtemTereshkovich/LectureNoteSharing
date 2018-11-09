using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.ViewModel.CommentService{
    public class CreateCommentViewModel{
        [Required]
        public string CommentText {get;set;}
        public string AuthorId {get;set;}
        [Required]
        public string LectureNoteId {get;set;}
    }
}