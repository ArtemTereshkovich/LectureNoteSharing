using System.ComponentModel.DataAnnotations;

namespace Material_Sharing.ViewModel.RatingService{
    public class RatingViewModel{
        
        public string PostId {get;set;}
        public int Rating {get;set;}
        public bool Liked {get;set;}
    }
}