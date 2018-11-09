
using System.Security.Claims;
using System.Threading.Tasks;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.ViewModel.RatingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.Controllers
{
    public class RatingController : Controller
    {
        private readonly ILectureNoteRatingService _ratingService;
        public RatingController(ILectureNoteRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        [Route("/rating/put")]
        public async Task<IActionResult> TakeRatingAsync([FromBody]RatingPutViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AuthorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await _ratingService.CreateAsync(model);
                return NoContent();
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("/rating/get/")]
        public IActionResult GetRating(string postId)
        {
            if(postId != null){
                if (User.Identity.IsAuthenticated)
                {
                    RatingViewModel rating = _ratingService.GetLectureNoteRatingForUser(postId, User.FindFirst(ClaimTypes.Name).Value);
                    if (rating != null)
                    {
                        return Json(rating);
                    }
                }
            }
            return Json(new RatingViewModel
            {
                Liked = false,
                Rating = 0,
                PostId = ""
            });
        }
    }
}