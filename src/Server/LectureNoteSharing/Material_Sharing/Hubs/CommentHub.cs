using System.Threading.Tasks;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.DAL.Repositories;
using Material_Sharing.ViewModel.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Material_Sharing.Hubs{
   
    public class CommentHub:Hub<IClientHub>{
        
        private readonly ICommentService _commentService;
        public CommentHub(ICommentService commentService){ 
            _commentService = commentService;           
        }        

        [Authorize]
        public async Task PostComment(CreateCommentViewModel model){
            if(model.AuthorId != null && model.CommentText != null && model.LectureNoteId != null){
                
                var comment = await _commentService.CreateAsync(model);                
                this.Clients.Group(model.LectureNoteId).AddComment(comment); 
            }
        }


        public async Task StartListenAsync(string postId){
            await Groups.AddAsync(Context.ConnectionId,postId);
        }
    }
    public interface IClientHub
    {        
        void AddComment(CommentViewModel comment);
    }
}