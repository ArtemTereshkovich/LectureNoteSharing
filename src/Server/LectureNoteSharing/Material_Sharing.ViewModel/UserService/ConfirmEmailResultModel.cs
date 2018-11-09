using System.Collections.Generic;

namespace Material_Sharing.ViewModel.UserService{
    public class ConfirmEmailResultModel{
        public bool HasUser {get;set;}
        public bool IsSuccessed {get;set;}
        public IEnumerable<string> ConfirmResults {get;set;}
    }
}