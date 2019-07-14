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
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _ClienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }

        public Cliente Adicionar(Cliente Cliente)
        {
            if (!Cliente.IsValid())
                return Cliente;

            Cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_ClienteRepository).Validate(Cliente);

            return !Cliente.ValidationResult.IsValid ? Cliente :  _ClienteRepository.Adicionar(Cliente);
        }

        public Cliente Atualizar(Cliente Cliente)
        {

            if (!Cliente.IsValid())
                return Cliente;

            return !Cliente.ValidationResult.IsValid ? Cliente : _ClienteRepository.Atualizar(Cliente);
        }

        public void Dispose()
        {
            _ClienteRepository.Dispose();
        }
    }
}
