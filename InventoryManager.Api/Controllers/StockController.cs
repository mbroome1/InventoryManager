using AutoMapper;
using InventoryManager.Api.Entites;
using InventoryManager.Api.Models;
using InventoryManager.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockController(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllStock()
        {
            var stockFromRepository =  await _stockRepository.GetAllStock();

            if (stockFromRepository == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<StockDto>>(stockFromRepository));
        }

        [HttpGet("{stockid}", Name = "GetStockById")]
        public async Task<ActionResult<StockDto>> GetStockById(int stockId)
        {
            var stockFromRepository = await _stockRepository.GetStockById(stockId);

            if (stockFromRepository == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StockDto>(stockFromRepository));

        }

        [HttpPost]
        public async Task<ActionResult<StockDto>> CreateStock([FromBody] StockForCreationDto stock)
        {
            var newStockEntity = _mapper.Map<Stock>(stock);
             _stockRepository.CreateStock(newStockEntity);
            await _stockRepository.SaveChanges();

            var getNewStock = await _stockRepository.GetStockById(newStockEntity.Id);

            var createdStockToReturn = _mapper.Map<StockDto>(getNewStock);

            return CreatedAtRoute("GetStockById", 
                new { Id = newStockEntity.Id },
                createdStockToReturn);
        }

        [HttpPut("{stockid}")]
        public async Task<ActionResult> UpdateStock(int stockId, StockForUpdateDto stock)
        {
            if (!await _stockRepository.StockExists(stockId))
            {
                return NotFound();
            }

            var stockFromRepository = await _stockRepository.GetStockById(stockId);
            if (stockFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(stock, stockFromRepository);

            await _stockRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{stockid}")]
        public async Task<ActionResult> DeleteStock(int stockId)
        {
            if (!await _stockRepository.StockExists(stockId))
            {
                return NotFound();
            }

            var stockFromRepository = await _stockRepository.GetStockById(stockId);
            if (stockFromRepository == null)
            {
                return NotFound();
            }

            _stockRepository.DeleteStock(stockFromRepository);

            await _stockRepository.SaveChanges();

            return NoContent();
        }

    }
}
