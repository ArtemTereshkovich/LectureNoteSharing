using System.Collections.Generic;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.ViewModel.TagService;

namespace Material_Sharing.BLL.Services{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TagTopViewModel> GetTopTagsCloud(int count)
        {
            var list = _unitOfWork.Tags.GetTopTags(count);
            var viewlist = new List<TagTopViewModel>();
            foreach(var tag in list){
                viewlist.Add(new TagTopViewModel{
                    label = tag.Title,
                    url = "/lecturenote/tags/"  + tag.Id,
                    targer = "_top"
                });
            }
            return viewlist;
        }
    }
}