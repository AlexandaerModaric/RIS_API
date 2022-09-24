using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RIS_API.DTOs;
using RIS_API.IRepositories;
using Ris2022.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalityTypesController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<ModalityTypesController> _logger;
        protected readonly IMapper _mapper;
        public ModalityTypesController(IUnitOfWork unitOfWork, ILogger<ModalityTypesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<ModalityTypesController>
        [HttpGet]
        public async Task<IActionResult> GetModalityTypes()
        {
            try
            {
                var ModalityTypes = await _unitOfWork.ModalityTypes.GetAllAsync();
                var results = _mapper.Map<IList<ModalitytypeDTO>>(ModalityTypes);
                return Ok(results);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetModalityTypes)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later");
            }
        }

        // GET api/<ModalityTypesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModalityTypeById(int id)
        {
            try
            {
                var ModalityType = await _unitOfWork.ModalityTypes.GetAsync(c=>c.Id==id,new List<string> { "HL7Messages" });
                var result = _mapper.Map<ModalitytypeDTO>(ModalityType);
                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetModalityTypeById)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later...");
            }
        }

        // POST api/<ModalityTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModalityTypesController>/5
        [HttpPut("{id}")]
        public async Task InsertModalityType(Modalitytype modalitytype)
        {
            try
            {
                // await _unitOfWork.ModalityTypes.InsertAsync(modalitytype);
                //return Task Ok("ModalityType Created Successfully");

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<ModalityTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
