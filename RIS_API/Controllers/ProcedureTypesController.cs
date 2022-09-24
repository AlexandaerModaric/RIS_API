using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIS_API.DTOs;
using RIS_API.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureTypesController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<ProcedureTypesController> _logger;
        protected readonly IMapper _mapper;
        public ProcedureTypesController(IUnitOfWork unitOfWork, ILogger<ProcedureTypesController> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<ProcedureTypesController>
        [HttpGet]
        public async Task<IActionResult> GetProcedureTypes()
        {
            try
            {
                var ProcedureTypes = await _unitOfWork.Proceduretypes.GetAllAsync();
                var results = _mapper.Map<IList<ProceduretypeDTO>>(ProcedureTypes);
                return Ok(results);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Somthing Went Wrong in {nameof(GetProcedureTypes)}",exception);
                return StatusCode(500,"Internal Server Error, Try Again Later...");
            }
        }

        // GET api/<ProcedureTypesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProcedureTypeByID(int id)
        {
            try
            {
                var ProcedureType = await _unitOfWork.Proceduretypes.GetAsync(c=>c.Id ==id, new List<string> { "HL7Messages"});
                var result = _mapper.Map<ProceduretypeDTO>(ProcedureType);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Somthing Went Wrong in {nameof(GetProcedureTypes)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later");
            }
        }
        // POST api/<ProcedureTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProcedureTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProcedureTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
