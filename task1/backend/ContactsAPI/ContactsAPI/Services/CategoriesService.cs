using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryViewDto> GetAll();
        CategoryViewDto GetById(int id);
        int Add(CategoryCreateDto dto);
        void Update(int id, CategoryUpdateDto dto);
        void Delete(int id);
    }

    public class CategoriesService(ICategoriesRepository categoriesRepository) : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository = categoriesRepository;

        public IEnumerable<CategoryViewDto> GetAll()
        {
            var categories = _categoriesRepository.GetAll();
            return CategoryViewDto.MapToDtos(categories);
        }

        public CategoryViewDto GetById(int id)
        {
            return CategoryViewDto.MapToDto(GetCategoryById(id));
        }

        public int Add(CategoryCreateDto dto)
        {
            var category = CategoryCreateDto.MapToEntity(dto);
            int categoryId = _categoriesRepository.Add(category);
            return categoryId;
        }

        public void Update(int id, CategoryUpdateDto dto)
        {
            var category = GetCategoryById(id);
            category.Name = dto.Name;
            _categoriesRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetCategoryById(id);
            _categoriesRepository.Delete(category);
        }

        private Category GetCategoryById(int id)
        {
            var category = _categoriesRepository.GetById(id);
            if (category == null)
            {
                throw new NotFoundException($"Category with id {id} not found");
            }
            return category;
        }
    }
}
