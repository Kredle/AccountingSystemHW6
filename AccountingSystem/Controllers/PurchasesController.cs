using AccountingSystem.Data.DTO;
using AccountingSystem.Repositories.Purchases;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public PurchasesController(IPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var purchases = await _repository.GetAll();

            return Ok(_mapper.Map<List<PurchaseDTO>>(purchases));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var purchase = await _repository.GetById(id);
            if (purchase == null) return NotFound();
            
            return Ok(_mapper.Map<PurchaseDTO>(purchase));
        }
    }
}
