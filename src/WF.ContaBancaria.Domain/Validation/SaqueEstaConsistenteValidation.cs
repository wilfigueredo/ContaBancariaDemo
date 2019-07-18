using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Specification;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Validation
{
    public class SaqueEstaConsistenteValidation : Validator<Transacoes>
    {
        public SaqueEstaConsistenteValidation(IContaRepository contaRepository,ITransacoesRepository transacoesRepository)
        {
            var contaLimiteDiario = new ContaDeveTerLimiteSaqueDiarioSpecification(transacoesRepository);
            var contaSaldo = new ContaDeveTerSaldoParaSaqueSpecification(contaRepository);            

            base.Add("contaLimiteDiario", new Rule<Transacoes>(contaLimiteDiario, "Limite diario para saque excedido"));
            base.Add("contaSaldo", new Rule<Transacoes>(contaSaldo, "Saldo para saque indisponivel"));            
        }
    }
}
