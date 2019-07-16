using WF.ContaBancaria.Domain.Validation;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Models
{
    public class Conta : Entity
    {
        public Conta()
        {
            Saldo = 0.0;
            TipoConta = 0;
            Ativar();
        }
        public double Saldo { get; set; }
        public double LimiteSaqueDiario { get; set; }
        public bool Ativo { get; private set; }
        public int TipoConta { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Guid? ClienteId { get; set; }        
        public virtual Cliente Cliente { get; set; }
        public ValidationResult ValidationResult { get; set; }        

        public bool IsValid()
        {
            ValidationResult = new ContaAptaParaTransacoesValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public void Ativar()
        {
            Ativo = true;
        }

        public void Bloquear()
        {
            Ativo = false;
        }

        public void Depositar(Transacoes transacoes)
        {            
            ValidationResult = new ContaAptaParaTransacoesValidation().Validate(this);
            if (ValidationResult.IsValid && transacoes.IsValid())
            {
                this.Saldo += transacoes.Valor;
                ValidationResult.Message = "Deposito realizado com sucesso";
            }           
        }

        public void Sacar(Transacoes transacoes)
        {            
            ValidationResult = new ContaAptaParaTransacoesValidation().Validate(this);

            if (ValidationResult.IsValid && transacoes.IsValid())
            {
                this.Saldo += transacoes.Valor;
                ValidationResult.Message = "Saque realizado com sucesso";
            }
        }        
    }
}
