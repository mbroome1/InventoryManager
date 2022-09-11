using AutoMapper;
using InventoryManager.Api.Entites;
using InventoryManager.Api.Models;
using InventoryManager.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoriesController(IStockRepository stockRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoriesFromRepository = await _categoryRepository.GetAllCategories();
            if (categoriesFromRepository == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesFromRepository));
        }

        [HttpGet("{categoryid}")]
        public async Task<ActionResult<CategoryWithStockDto>> GetCategory(int categoryId)
        {
            var categoryStockFromRepository = await _categoryRepository.GetCategory(categoryId);
            if (categoryStockFromRepository == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryWithStockDto>(categoryStockFromRepository));
        }
    }
}
