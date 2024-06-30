using AutoMapper;
using MyWallet.Domain.Models;
using MyWallet.Shared.DTO;

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
                cfg.CreateMap<WalletMonthDTO, WalletMonth>().ReverseMap();
                cfg.CreateMap<ExpenseEntryDTO, Expense>()
                .ReverseMap();

                cfg.CreateMap<Expense, ExpenseDTO>();

                cfg.CreateMap<FixedEntry, ExpenseDTO>();

                cfg.CreateMap<Invoice, InvoiceDTO>();

                cfg.CreateMap<Balance, BalanceDTO>();

                cfg.CreateMap<ReminderDTO, Reminder>().ReverseMap();

                cfg.CreateMap<Health, HealthDTO>().ReverseMap();

                cfg.CreateMap<Goal, GoalDTO>().ReverseMap();

                cfg.CreateMap<Exercise, ExerciseDTO> ().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
