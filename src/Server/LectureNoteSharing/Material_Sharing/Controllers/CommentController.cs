using System.Security.Claims;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.Hubs;
using Material_Sharing.ViewModel.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Material_Sharing.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService,
            
            IUnitOfWork unitOfWork
        )
        {
            _commentService = commentService;
            _unitOfWork = unitOfWork;            
        }

        [HttpGet]
        [Route("comments/get")]
        public IActionResult GetComments(string postId){
            if(postId != null){
                return Json(_commentService.GetByPostId(postId));
            }
            else
                return BadRequest();
        }

        
    }

}