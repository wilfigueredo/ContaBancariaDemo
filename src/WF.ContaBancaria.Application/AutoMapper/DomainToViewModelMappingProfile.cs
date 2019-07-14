using AutoMapper;
using WF.ContaBancaria.Application.ViewModels;
using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
            CreateMap<ContaViewModel, Conta>().ReverseMap();
            CreateMap<ContaViewModel, SaqueViewModel > ().ReverseMap();
            CreateMap<SaqueViewModel, Conta>().ReverseMap();
            CreateMap<ContaViewModel, DepositoViewModel>().ReverseMap();
            CreateMap<DepositoViewModel, Conta>().ReverseMap();
            CreateMap<TransacoesViewModel, Transacoes>().ReverseMap();
            CreateMap<ExtratoViewModel, Transacoes>().ReverseMap();
            CreateMap<ExtratoPeriodoViewModel, Transacoes>().ReverseMap();
        }
        
    }
}
