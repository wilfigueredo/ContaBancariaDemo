using WF.ContaBancaria.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Validation;

namespace WF.ContaBancaria.Domain.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            if (!pessoa.IsValid())
                return pessoa;

            pessoa.ValidationResult = new PessoaAptoParaCadastroValidation(_pessoaRepository).Validate(pessoa);

            return !pessoa.ValidationResult.IsValid ? pessoa :  _pessoaRepository.Adicionar(pessoa);
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {

            if (!pessoa.IsValid())
                return pessoa;

            return !pessoa.ValidationResult.IsValid ? pessoa : _pessoaRepository.Atualizar(pessoa);
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }
    }
}
