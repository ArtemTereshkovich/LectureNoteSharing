using System.Collections.Generic;

namespace Material_Sharing.ViewModel.UserService{
    public class ResetPasswordResultModel{
        public bool HasUser {get;set;}
        public bool IsSucceded {get;set;}
        public IEnumerable<string> ResetResults {get;set;} 
    }
}