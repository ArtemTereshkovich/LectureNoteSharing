using System.Collections.Generic;
using System.Threading.Tasks;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.CommentService;

namespace Material_Sharing.BLL.Interfaces{
    public interface ICommentService
    {    
       IEnumerable<CommentViewModel> GetByPostId(string postId);
       Task<CommentViewModel> CreateAsync(CreateCommentViewModel model);
    }
}