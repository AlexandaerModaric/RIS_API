using AutoMapper;
using RIS_API.Data;
using RIS_API.DTOs;
using Ris2022.Data.Models;

namespace RIS_API.Configurations
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, CreatePatientDTO>().ReverseMap();

            CreateMap<HL7Message, HL7MessageDTO>().ReverseMap();
            CreateMap<HL7Message, CreateHL7MessageDTO>().ReverseMap();

            CreateMap<Modality, ModalityDTO>().ReverseMap();
            CreateMap<Modality, CreateModalityDTO>().ReverseMap();

            CreateMap<Modalitytype, ModalitytypeDTO>().ReverseMap();
            CreateMap<Modalitytype, CreateModalitytypeDTO>().ReverseMap();

            CreateMap<Proceduretype, ProceduretypeDTO>().ReverseMap();
            CreateMap<Proceduretype, CreateProceduretypeDTO>().ReverseMap();
        }
    }
}
