using System.Collections.Generic;

namespace Material_Sharing.ViewModel.UserService{
    public class ForgotPasswordResultModel{
        public bool HasUser {get;set;}
        public bool IsSuccesed {get;set;}
        public string ForgotResult {get;set;}
    }
}