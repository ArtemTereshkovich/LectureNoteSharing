namespace Material_Sharing.ViewModel.UserService{
    public class SignInResultModel{
        public bool IsAuthorized {get;set;}
        public string Result {get;set;}
        public ApplicationUserViewModel User {get;set;}
    }
}