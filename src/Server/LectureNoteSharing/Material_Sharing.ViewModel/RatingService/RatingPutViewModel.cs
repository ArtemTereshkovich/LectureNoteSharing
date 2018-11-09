using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.ViewModel.RatingService{
    public class RatingPutViewModel{
        [Required]
        public string PostId {get;set;}
        [Required]
        public int Rating {get;set;}
        public string AuthorId {get;set;}
    }
}