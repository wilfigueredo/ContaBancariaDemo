using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using WF.ContaBancaria.Domain.Models;
using Xunit;

namespace WF.ContaBancaria.Domain.Teste.Contas.Saque
{
    [Binding]
    public class SaqueEmContaCorrenteSteps
    {
        Conta conta = new Conta(1000, 500);        
        Transacoes transacao;        

        [When(@"For efetuado um saque")]
        public void QuandoForEfetuadoUmSaque()
        {
            transacao = new Transacoes(200, Enuns.TipoTransacao.Saque, conta.Id);
            conta.Sacar(transacao);
        }

        [When(@"O valor do saque e superior a zero")]
        public void QuandoOValorESuperiorAZero()
        {
            conta.Ativar();
            transacao = new Transacoes(200, Enuns.TipoTransacao.Saque, conta.Id);
            conta.Sacar(transacao);
        }

        [Then(@"Receberei uma mensagem de saque realizado com sucesso")]
        public void EntaoRecebereiUmaMensagemDeSaqueRealizadoComSucesso()
        {            
            Assert.Equal("Saque realizado com sucesso", conta.ValidationResult.Message);
        }
    }
}
