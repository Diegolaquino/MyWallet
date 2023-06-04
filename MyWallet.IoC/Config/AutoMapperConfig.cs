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
                // Mapeamentos aqui
                 cfg.CreateMap<CategoryEntryDTO, Category>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
