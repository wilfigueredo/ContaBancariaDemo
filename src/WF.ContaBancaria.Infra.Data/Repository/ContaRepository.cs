using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Infra.Data.Context;
using Dapper;

namespace WF.ContaBancaria.Infra.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(ContaContext context) : base(context)
        {
        }

        //Consulta com Dapper
        public override IEnumerable<Conta> ObterTodos()
        {
            var sql = @"SELECT * FROM dbo.Contas C " +
                        "LEFT JOIN dbo.Pessoas P ON C.PessoaId = P.Id ";

            var contasList = new List<Conta>();

            Db.Database.Connection.Query<Conta, Pessoa, List<Conta>>(sql, (c, p) =>
               { c.Pessoa = p; contasList.Add(c); return contasList.ToList(); });
            
            return contasList;
        }

        public override Conta ObterPorId(Guid Id)
        {
            var sql = @"SELECT * FROM dbo.Contas C " +
                        "LEFT JOIN dbo.Pessoas P ON C.PessoaId = P.Id " +
                        "WHERE c.Id = @sid";

            var contasList = new List<Conta>();

            Db.Database.Connection.Query<Conta, Pessoa, List<Conta>>(sql, (c, p) =>
            { c.Pessoa = p; contasList.Add(c); return contasList.ToList(); }, new { sid = Id });

            return contasList.FirstOrDefault();
        }

        public IEnumerable<Conta> ObterPorSaldo(double valor)
        {
            var sql = @"SELECT * FROM dbo.Contas C " +
                        "LEFT JOIN dbo.Pessoas P ON C.PessoaId = P.Id " +
                        "WHERE c.Saldo = @svalor";

            var contasList = new List<Conta>();

            Db.Database.Connection.Query<Conta, Pessoa, List<Conta>>(sql, (c, p) =>
            { c.Pessoa = p; contasList.Add(c); return contasList.ToList(); }, new { svalor = valor });

            return contasList;
        }

        public Conta Sacar(Conta conta, double valor)
        {
            conta.Saldo -= valor;

            Atualizar(conta);

            return conta;
        }

        public Conta Depositar(Conta conta, double valor)
        {            
            
            conta.Saldo += valor;

            Atualizar(conta);

            return conta;
        }
        

        public void AtivarConta(Guid Id)
        {
            var conta = ObterPorId(Id);

            conta.Ativar();

            Atualizar(conta);
            
        }

        public void BloquearConta(Guid Id)
        {
            var conta = ObterPorId(Id);

            conta.Bloquear();

            Atualizar(conta);
        }        

        public void RemoverContaPessoa(Guid Id)
        {
            var sqlConta = @"SELECT C.Id FROM dbo.Contas C " +
                            "WHERE C.PessoaId = @sid";            

           IEnumerable<Guid> IdContas =  Db.Database.Connection.Query<Guid>(sqlConta, new { sid = Id });

            foreach(var id in IdContas)
            {
                Remover(id);
            }            
        }

        public override void Remover(Guid id)
        {
            var sqlTransact = @"DELETE FROM dbo.Transacoes " +
                               "WHERE ContaId = @sid";

            Db.Database.Connection.Query<Transacoes>(sqlTransact, new { sid = id });

            var sql = @"DELETE FROM dbo.Contas " +
                        "WHERE Id = @sid";

            Db.Database.Connection.Query<Conta>(sql, new { sid = id });
        }
    }
}
