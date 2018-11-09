using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.LectureNoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.Controllers
{
    public class TagNoteController : Controller
    {
        private readonly ITagService _tagService;

        public TagNoteController(ITagService tagService){
            _tagService = tagService;
        }

        

        [HttpGet]
        [Route("tags/tops")]
        public IActionResult GetTopsTag(int count = 10){
            return Json(_tagService.GetTopTagsCloud(count));
        }
    }
}