using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Infra.Data.Context;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Interface.Repository;
using Dapper;

namespace WF.ContaBancaria.Infra.Data.Repository
{
    public class TransacoesRepository : Repository<Transacoes>, ITransacoesRepository
    {
        public TransacoesRepository(ContaContext context) : base(context)
        {
        }

        public IEnumerable<Transacoes> ObterExtrato(Guid Id)
        {
            var sql = @"SELECT * FROM dbo.Transacoes T " +
                       "INNER JOIN dbo.Contas C ON T.ContaId = C.Id " +
                       "LEFT JOIN dbo.Clientes P ON C.ClienteId = P.Id " +
                       "WHERE ContaId = @sid";

            var transacoesList = new List<Transacoes>();

            Db.Database.Connection.Query<Transacoes, Conta, Cliente, List<Transacoes>>(sql, (t, c, p) =>
            { c.Cliente = p; t.Contas = c; transacoesList.Add(t); return transacoesList.ToList(); }, new { @sid = Id });

            return transacoesList;            
        }

        public IEnumerable<Transacoes> ObterExtratoPeriodo(Guid Id, DateTime dataInicial, DateTime dataFinal)
        {
            var sql = @"SELECT * FROM dbo.Transacoes T " +
                       "INNER JOIN dbo.Contas C ON T.ContaId = C.Id " +
                       "LEFT JOIN dbo.Clientes P ON C.ClienteId = P.Id " +
                       "WHERE ContaId = @sid AND T.DataCadastro >= @sdataIni " +
                       "AND T.DataCadastro <= @sdataFim";

            var transacoesList = new List<Transacoes>();

            Db.Database.Connection.Query<Transacoes, Conta, Cliente, List<Transacoes>>(sql, (t, c, p) =>
            { c.Cliente = p; t.Contas = c; transacoesList.Add(t); return transacoesList.ToList(); }, new { @sid = Id, @sdataIni = dataInicial, @sdataFim = dataFinal });

            return transacoesList;
        }

        public bool TemSaldoParaSaque(Transacoes transacoes)
        {
            var sql = @"SELECT C.Saldo FROM dbo.Contas C " +
                       "WHERE C.Id = @sid";

            var saldo = Db.Database.Connection.Query<double>(sql, new { @sid = transacoes.ContaId });

            if (saldo.FirstOrDefault() >= transacoes.Valor)
                return true;
            else
                return false;
        }

        public bool TemLimiteSaqueDiario(Transacoes transacoes)
        {
            var sql = @"SELECT Valor FROM dbo.Transacoes " +
                       "WHERE Valor < 0 AND ContaId = @sid AND DataCadastro = @sdata";

            var saques = Db.Database.Connection.Query<double>(sql, new { sdata = DateTime.Today, @sid = transacoes.ContaId });

            var sqlLimite = @"SELECT C.LimiteSaqueDiario FROM dbo.Contas C " +
                             "WHERE C.Id = @sid";

            var limiteSaqueDiario = Db.Database.Connection.Query<double>(sqlLimite, new { @sid = transacoes.ContaId });

            double TotalSaque = 0.0;
            double limite = limiteSaqueDiario.FirstOrDefault();
            foreach (var item in saques)
            {
                TotalSaque += item * -1;
            }

            
            double total = TotalSaque + transacoes.Valor;
            if (total > limite)
                return false;
            else            
                return true;
                       
        }        
    }
}
