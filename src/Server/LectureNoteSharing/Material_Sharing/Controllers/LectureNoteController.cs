using System.Security.Claims;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.LectureNoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.Controllers
{
    public class LectureNoteController : Controller
    {
        private readonly ILectureNoteService _lectureNoteService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LectureNoteController(ILectureNoteService lectureNoteService
        , SignInManager<ApplicationUser> signInManager)
        {
            _lectureNoteService = lectureNoteService;
            _signInManager = signInManager;
        }

        [Authorize]
        [Route("lecturenote/create")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync(LectureNoteViewModel lectureNoteEdit)
        {
            if (ModelState.IsValid)
            {
                lectureNoteEdit.AuthorUsername = User.FindFirst(ClaimTypes.Name).Value;
                await _lectureNoteService.CreateAsync(lectureNoteEdit);
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [Route("lecturenote/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateLectureNote");
        }

        [HttpGet]
        public IActionResult Tops(int page=1){
            if(page>0)
                return Json(_lectureNoteService.GetTopRating(page,5));
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Index(){
            return View("Index");
        }

        [Route("/lecturenote/view")]
        [HttpGet]
        public IActionResult GetById(string Id)
        {
            if(Id != null){
                if(User.Identity.IsAuthenticated)
                    ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var lectureNote = _lectureNoteService.GetById(Id);
                if(lectureNote != null){
                    return View("Show", lectureNote);
                }
            }
            return BadRequest();
        }

        [Route("lecturenote/edit/{id}")]
        [HttpGet]
        [Authorize]
        public IActionResult Edit(string Id)
        {
            throw new System.NotImplementedException();
            //return View("edit",_lectureNoteService.GetById(Id));
        }

        [Route("lecturenote/edit")]
        [HttpPost]
        [Authorize]
        public IActionResult Edit(LectureNoteViewModel model){
            throw new System.NotImplementedException();
        }

        [Route("lecturenote/tags/{tag}")]
        [HttpGet]
        public IActionResult GetByTag(string tag){
            if(tag != null){
                ViewData["Tag"] = tag;
                return View("ViewTag");
            }
            else 
                return NoContent();
        }

        [Route("lecturenote/tags/tops")]
        [HttpGet]
        public IActionResult GetTopTagsPost(int page,string tagId){
            if(tagId != null && page>0)        
                return Json(_lectureNoteService.GetTagLecture(page,tagId,5));
            else
                return BadRequest();

        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyTitle(string title)
        {
            return _lectureNoteService.CheckUniqueTitle(title) ?
                Json("true") : Json($"Already have lecture note with {title} Title");
        }

        
    }
}