using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController(ISubcategoriesService subcategoriesService) : ControllerBase
    {
        private readonly ISubcategoriesService _subcategoriesService = subcategoriesService;

        [HttpGet]
        public ActionResult<IEnumerable<SubcategoryViewDto>> GetAll()
        {
            var subcategories = _subcategoriesService.GetAll();
            return Ok(subcategories);
        }

        [HttpGet("{id}")]
        public ActionResult<SubcategoryViewDto> GetById([FromRoute] int id)
        {
            var subcategory = _subcategoriesService.GetById(id);
            return Ok(subcategory);
        }

        [HttpPost]
        public ActionResult Add([FromBody] SubcategoryCreateDto dto)
        {
            int subcategoryId = _subcategoriesService.Add(dto);
            return Created($"/api/categories/{subcategoryId}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] SubcategoryUpdateDto dto)
        {
            _subcategoriesService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _subcategoriesService.Delete(id);
            return NoContent();
        }
    }
}
