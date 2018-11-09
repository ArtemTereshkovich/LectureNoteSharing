using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.ViewModel.LectureNoteService;

namespace Material_Sharing.BLL.Services{
    public class LectureNoteService : ILectureNoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ISpecialtyNumberService _specialtyNumberService;

        public LectureNoteService(IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserService userService,
            ISpecialtyNumberService specialtyNumberService)
        {
            _mapper = mapper;
            _userService = userService;
            _specialtyNumberService = specialtyNumberService;
            _unitOfWork = unitOfWork;
        }

        public bool CheckUniqueTitle(string title)
        {
            return _unitOfWork.LectureNotes.CheckUniqueTitle(title);
        }

        public async Task<LectureNoteViewModel> CreateAsync(LectureNoteViewModel lectureNote)
        {
            LectureNote lectureNoteModel = _mapper.Map<LectureNoteViewModel, LectureNote>(lectureNote);
            lectureNoteModel.Author = await _unitOfWork.UserManager.FindByNameAsync(lectureNote.AuthorUsername);
            lectureNoteModel.AverageRating = 0.0;
            lectureNoteModel.DateOfCreate = DateTime.Now;
            lectureNoteModel.DateOfLastChange = DateTime.Now;
            lectureNoteModel.Specialty =await _specialtyNumberService.CreateSpecialtyNumberAsync(lectureNote.SpecialtyNumber);
            lectureNoteModel =_unitOfWork.LectureNotes.Add(lectureNoteModel);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LectureNote,LectureNoteViewModel>(lectureNoteModel);
        }

        public void Delete(LectureNoteViewModel lectureNote)
        {
            _unitOfWork.LectureNotes.Remove(_mapper.Map<LectureNoteViewModel, LectureNote>(lectureNote));
            _unitOfWork.SaveAsync();
        }

        public IEnumerable<LectureNoteViewModel> GetAll()
        {
            IEnumerable<LectureNote> lectureNotes =_unitOfWork.LectureNotes.GetAll();
            return _mapper.Map<IEnumerable<LectureNote>,IEnumerable<LectureNoteViewModel>>(lectureNotes);
        }

        public LectureNoteViewModel GetById(string id)
        {
            LectureNote lectureNote = _unitOfWork.LectureNotes.Get(id);
            return _mapper.Map<LectureNote,LectureNoteViewModel>(lectureNote);
        }

        public IEnumerable<LectureNoteViewModel> GetByTagId(string tagId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LectureNoteViewModel> GetByUserId(string userId)
        {
            IEnumerable<LectureNote> lectureNotes = _unitOfWork.LectureNotes.GetByUserId(userId);
            return _mapper.Map<IEnumerable<LectureNote>,IEnumerable<LectureNoteViewModel>>(lectureNotes);
        }

        public IEnumerable<LectureNoteViewModel> GetTagLecture(int page, string tagId, int count)
        {
            var list = _unitOfWork.LectureNotes.GetTagsTopNotes(page,tagId,count);
            return _mapper.Map<IEnumerable<LectureNote>, IEnumerable<LectureNoteViewModel>>(list);
        }

        public IEnumerable<LectureNoteViewModel> GetTopRating(int page, int countPerPage)
        {
            var list =_unitOfWork.LectureNotes.GetTopNotes(page, countPerPage);
            return _mapper.Map<IEnumerable<LectureNote>, IEnumerable<LectureNoteViewModel>>(list);
        }

        public LectureNoteViewModel Update(LectureNoteEditModel lectureNote)
        {
            LectureNote updateLectureNote = _mapper.Map<LectureNoteEditModel,LectureNote>(lectureNote);
            LectureNote updatednote = _unitOfWork.LectureNotes.Update(updateLectureNote);
            return _mapper.Map<LectureNote,LectureNoteViewModel>(updatednote);
        }
    }
}