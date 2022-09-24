using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIS_API.Data;
using RIS_API.DTOs;
using RIS_API.IRepositories;
using Ris2022.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<PatientsController> _logger;
        protected readonly IMapper _mapper;
        public PatientsController(IUnitOfWork unitOfWork, ILogger<PatientsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<PatientsController>
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var Patients = await _unitOfWork.Patients.GetAllAsync();
                var results = _mapper.Map<IList<PatientDTO>>(Patients);
                return Ok(results);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetPatients)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later");
            }
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id:int}",Name = "GetPatient")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var Patient = await _unitOfWork.Patients.GetAsync(c => c.Id == id, new List<string> { "HL7Messages" });
                var result = _mapper.Map<PatientDTO>(Patient);
                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Something Went Wrong in {nameof(GetPatientById)}", exception);
                return StatusCode(500, "Internal Server Error, Try Again Later...");
            }
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<IActionResult> InsertPatient([FromBody] PatientDTO patientDTO)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Attemp to Add Patient in {nameof(InsertPatient)}" + ModelState.ToString());
                return BadRequest(ModelState);
            }
            try
            {
                var patient = _mapper.Map<Patient>(patientDTO);
                await _unitOfWork.Patients.InsertAsync(patient);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetPatient", new { id = patient.Id },patient);
                //return Ok();
            }
            catch (Exception exeption)
            {
                _logger.LogError($"Invalid Attemp to Add Patient in {nameof(InsertPatient)}" , exeption);
                return StatusCode(500, "Internal Server Error, Try Again Later...");
                throw;
            }
        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public async Task InsertPatient(Patient patient)
        {
            try
            {
                // await _unitOfWork.Patients.InsertAsync(Patient);
                //return Task Ok("Patient Created Successfully");

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
