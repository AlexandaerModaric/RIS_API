using RIS_API.Data;
using Ris2022.Data.Models;

namespace RIS_API.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Patient> Patients { get; }
        IGenericRepository<HL7Message> Hl7Messages { get; }
        IGenericRepository<Modality> Modalities { get; }
        IGenericRepository<Modalitytype> ModalityTypes { get; }
        IGenericRepository<Proceduretype> Proceduretypes { get; }
        Task Save();
    }
}
