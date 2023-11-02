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
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<WalletDTO, Wallet>().ReverseMap();
                cfg.CreateMap<ExpenseEntryDTO, Expense>()
                .ReverseMap();
                cfg.CreateMap<Expense, ExpenseDTO>();

                cfg.CreateMap<ReminderDTO, Reminder>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
