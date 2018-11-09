using System.Collections.Generic;

namespace Material_Sharing.ViewModel.UserService{
    public class RegistryIdentityResult{
        public bool IsRegistred {get;set;}
        public IEnumerable<string> ResultString{get;set;}
        public ApplicationUserViewModel User {get;set;}
    }
}