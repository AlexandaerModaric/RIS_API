using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIS_API.DTOs;
using RIS_API.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalitiesController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<ModalitiesController> _logger;
        protected readonly IMapper _mapper;
        public ModalitiesController(IUnitOfWork unitOfWork, ILogger<ModalitiesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<ModalitiesController>
        [HttpGet]
        public async Task<IActionResult> GetAllModalitiesAsync()
        {
            try
            {
                var modalities = await _unitOfWork.Modalities.GetAllAsync();
                var results = _mapper.Map<IList<ModalityDTO>>(modalities);
                return Ok(results);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetAllModalitiesAsync)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later");
            }
        }

        // GET api/<ModalitiesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModalityById(int id)
        {
            try
            {
                var Modality = await _unitOfWork.Modalities.GetAsync(c => c.Id == id, new List<string> { "HL7Messages" });
                var result = _mapper.Map<ModalityDTO>(Modality);
                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetModalityById)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later...");
            }
        }

        // POST api/<ModalitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModalitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModalitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
