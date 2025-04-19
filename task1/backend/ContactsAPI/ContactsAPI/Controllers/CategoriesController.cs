using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoriesService categoriesService) : ControllerBase
    {
        private readonly ICategoriesService _categoriesService = categoriesService;

        [HttpGet]
        public ActionResult<IEnumerable<CategoryViewDto>> GetAll()
        {
            var categories = _categoriesService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryViewDto> GetById([FromRoute] int id)
        {
            var category = _categoriesService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CategoryCreateDto dto)
        {
            int categoryId = _categoriesService.Add(dto);
            return Created($"/api/categories/{categoryId}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CategoryUpdateDto dto)
        {
            _categoriesService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoriesService.Delete(id);
            return NoContent();
        }
    }
}