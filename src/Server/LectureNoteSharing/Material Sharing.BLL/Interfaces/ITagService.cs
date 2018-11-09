using System.Collections.Generic;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.TagService;

namespace Material_Sharing.BLL.Interfaces{
    public interface ITagService
    { 
        IEnumerable<TagTopViewModel> GetTopTagsCloud(int count);
    }
}