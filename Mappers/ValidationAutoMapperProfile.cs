using AutoMapper;
using id_validation_app.ApiModels;
using IdValidation.Domain.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace id_validation_app.Mappers
{
    public class ValidationAutoMapperProfile : Profile
    {
        public ValidationAutoMapperProfile()
        {
            CreateMap<ValidationResultModel, ValidationResult>();

            CreateMap<IList<ValidationResultModel>, FileValidationResult>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src));
        }
    }
}
