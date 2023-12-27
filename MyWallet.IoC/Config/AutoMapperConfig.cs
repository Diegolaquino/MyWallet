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
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<WalletDTO, Wallet>().ReverseMap();
                cfg.CreateMap<ExpenseEntryDTO, Expense>()
                .ReverseMap();
                cfg.CreateMap<IncomeEntryDTO, Income>()
                .ReverseMap();

                cfg.CreateMap<Expense, ExpenseDTO>();

                cfg.CreateMap<Income, IncomeDTO>();

                cfg.CreateMap<ReminderDTO, Reminder>().ReverseMap();

                cfg.CreateMap<Health, HealthDTO>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
