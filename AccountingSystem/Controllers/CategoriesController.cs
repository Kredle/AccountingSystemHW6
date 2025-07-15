using AccountingSystem.Data;
using AccountingSystem.Data.DTO;
using AccountingSystem.Repositories.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IPurchaseCategoryRepository _repository;
        private readonly IMapper _mapper; 

        public CategoriesController(IPurchaseCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAll();

            return Ok(_mapper.Map<List<PurchaseCategoryDTO>>(categories));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _repository.GetById(id);

            if (category == null) return NotFound();

            return Ok(_mapper.Map<PurchaseCategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryRequestDTO addCategoryRequestDTO)
        {
            var category = await _repository.Create(addCategoryRequestDTO);

            var categoryDTO = _mapper.Map<PurchaseCategoryDTO>(category);

            return CreatedAtAction(nameof(GetById), new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            var category = await _repository.Update(id, updateCategoryRequestDTO);
            if (category == null) return NotFound();
            return Ok(_mapper.Map<PurchaseCategoryDTO>(category));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _repository.Delete(id);
            if (category == null) return NotFound();

            return Ok(_mapper.Map<PurchaseCategoryDTO>(category));
        }

    }
}
