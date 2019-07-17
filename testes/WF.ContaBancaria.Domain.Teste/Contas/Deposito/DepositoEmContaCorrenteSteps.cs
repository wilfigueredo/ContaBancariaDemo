using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using WF.ContaBancaria.Domain.Models;
using Xunit;

namespace WF.ContaBancaria.Domain.Teste.Contas.Deposito
{
    [Binding]
    public class DepositoEmContaCorrenteSteps
    {
        Conta conta;
        Transacoes transacao;
        List<string> errors;

        [Given(@"Uma Conta Corrente Ativa")]
        public void DadoUmaContaCorrenteAtiva()
        {
            conta = new Conta(1000,500);
            conta.Ativar();
        }

        [When(@"Um valor for depositado")]
        public void QuandoUmValorForDepositado()
        {
            transacao = new Transacoes(200, Enuns.TipoTransacao.Deposito, conta.Id);
            conta.Depositar(transacao);
        }

        [When(@"O valor e superior a zero")]
        public void QuandoOValorESuperiorAZero()
        {
            transacao = new Transacoes(300, Enuns.TipoTransacao.Deposito, conta.Id);
            conta.Depositar(transacao);
        }

        [When(@"O valor é negativo")]
        public void QuandoOValorENegativo()
        {
            transacao = new Transacoes(-10, Enuns.TipoTransacao.Deposito, conta.Id);
            conta.Depositar(transacao);
        }

        [When(@"O valor é zero")]
        public void QuandoOValorEZero()
        {
            transacao = new Transacoes(0, Enuns.TipoTransacao.Deposito, conta.Id);
            conta.Depositar(transacao);
        }

        [Then(@"Receberei uma mensagem de deposito realizado com sucesso")]
        public void EntaoRecebereiUmaMensagemDeDepositoRealizadoComSucesso()
        {
            Assert.Equal("Deposito realizado com sucesso", conta.ValidationResult.Message);
        }

        [Then(@"Receberei uma mensagem de Valor deve ser positivo")]
        public void EntaoRecebereiUmaMensagemDeValorDeveSerPositivo()
        {
            PopularErros(transacao.ValidationResult);
            Assert.Equal("Valor deve ser positivo", errors[0]);
        }

        [Then(@"Receberei uma mensagem de Valor não pode ser igual a zero")]
        public void EntaoRecebereiUmaMensagemDeValorNaoPodeSerIgualAZero()
        {
            PopularErros(transacao.ValidationResult);
            Assert.Equal("Valor não pode ser igual a zero", errors[0]);
        }

        public void PopularErros(ValidationResult validationResult)
        {
            errors = new List<string>();
            foreach (var erro in validationResult.Erros)
            {
                 errors.Add(erro.Message);
            }
        }
    }
}
