using AutoMapper;
using MyWallet.Domain.Models;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.IoC.Config
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryEntryDTO, Category>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<ExpenseEntryDTO, Expense>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Condition(src => src.CreatedDate != null))
                .ReverseMap();
                cfg.CreateMap<Expense, ExpenseDTO>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
