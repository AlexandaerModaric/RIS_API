using RIS_API.Data;
using RIS_API.IRepositories;
using Ris2022.Data.Models;
using Ris2022.Repositories;

namespace RIS_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly RISDbContext _context;
        protected IGenericRepository<Patient> _Patients;
        protected IGenericRepository<HL7Message> _Hl7Messages;
        protected IGenericRepository<Modality> _Modalities;
        protected IGenericRepository<Modalitytype> _ModalityTypes;
        protected IGenericRepository<Proceduretype> _Proceduretypes;
        public UnitOfWork(RISDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Patient> Patients => _Patients ??= new GenericRepository<Patient>(_context);

        public IGenericRepository<HL7Message> Hl7Messages => _Hl7Messages ??= new GenericRepository<HL7Message>(_context);

        public IGenericRepository<Modality> Modalities => _Modalities ??= new GenericRepository<Modality>(_context);

        public IGenericRepository<Modalitytype> ModalityTypes => _ModalityTypes ??= new GenericRepository<Modalitytype>(_context);

        public IGenericRepository<Proceduretype> Proceduretypes => _Proceduretypes ??= new GenericRepository<Proceduretype>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
