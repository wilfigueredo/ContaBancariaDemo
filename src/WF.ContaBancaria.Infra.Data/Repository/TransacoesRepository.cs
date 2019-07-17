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
            { c.Cliente = p; t.Conta = c; transacoesList.Add(t); return transacoesList.ToList(); }, new { @sid = Id });

            return transacoesList;            
        }

        public IEnumerable<Transacoes> ObterExtratoPeriodo(Guid Id, DateTime dataInicial, DateTime dataFinal)
        {
            var sql = @"SELECT * FROM dbo.Transacoes T " +
                       "INNER JOIN dbo.Contas C ON T.ContaId = C.Id " +
                       "LEFT JOIN dbo.Clientes P ON C.ClienteId = P.Id " +
                       "WHERE ContaId = @sid AND CONVERT(VARCHAR(10),T.DataCadastro,103) >= @sdataIni " +
                       "AND CONVERT(VARCHAR(10),T.DataCadastro,103) <= @sdataFim";

            var transacoesList = new List<Transacoes>();

            Db.Database.Connection.Query<Transacoes, Conta, Cliente, List<Transacoes>>(sql, (t, c, p) =>
            { c.Cliente = p; t.Conta = c; transacoesList.Add(t); return transacoesList.ToList(); }, new { @sid = Id, @sdataIni = dataInicial.ToString("dd/MM/yyyy"), @sdataFim = dataFinal.ToString("dd/MM/yyyy") });

            return transacoesList;
        }                
    }
}
