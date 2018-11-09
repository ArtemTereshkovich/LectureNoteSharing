namespace Material_Sharing.ViewModel.UserService{
    public class SignInExternalResultModel : SignInResultModel{
        public bool IsNewUser {get;set;}
        public bool IsConfirmedEmail {get;set;}
        public RegisterViewModel RegisterModel {get;set;}
        public string LoginProvider {get;set;}
    }
}