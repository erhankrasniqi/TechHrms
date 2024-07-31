using AutoMapper;
using Microsoft.Extensions.Logging;
using TechHrms.Application.Response;
using TechHrms.Models;

namespace TechHrms.WebApp.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Training, TrainingResponse>();
        }
    }
}