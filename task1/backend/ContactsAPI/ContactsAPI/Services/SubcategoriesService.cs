using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public interface ISubcategoriesService
    {
        IEnumerable<SubcategoryViewDto> GetAll();
        SubcategoryViewDto GetById(int id);
        int Add(SubcategoryCreateDto contactDto);
        void Update(int id, SubcategoryUpdateDto dto);
        void Delete(int id);
    }

    public class SubcategoriesService(ISubcategoriesRepository subcategoriesRepository) : ISubcategoriesService
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository = subcategoriesRepository;

        public IEnumerable<SubcategoryViewDto> GetAll()
        {
            var subcategories = _subcategoriesRepository.GetAll();
            return SubcategoryViewDto.MapToDtos(subcategories);
        }

        public SubcategoryViewDto GetById(int id)
        {
            var subcategory = GetSubcategoryById(id);
            return SubcategoryViewDto.MapToDto(subcategory);
        }

        public int Add(SubcategoryCreateDto contactDto)
        {
            var subcategory = SubcategoryCreateDto.MapToEntity(contactDto);
            int subcategoryId = _subcategoriesRepository.Add(subcategory);
            return subcategoryId;
        }

        public void Update(int id, SubcategoryUpdateDto dto)
        {
            var subcategory = GetSubcategoryById(id);
            SubcategoryUpdateDto.MapToEntity(dto, subcategory);
            _subcategoriesRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var subcategory = GetSubcategoryById(id);
            _subcategoriesRepository.Delete(subcategory);
        }

        private Subcategory GetSubcategoryById(int id)
        {
            var subcategory = _subcategoriesRepository.GetById(id);
            if (subcategory is null)
            {
                throw new NotFoundException($"Subcategory with id {id} not found");
            }
            return subcategory;
        }
    }
}
