using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext){}
    }
}