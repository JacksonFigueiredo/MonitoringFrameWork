using System.Collections.Generic;
using API.Business.Interfaces;
using API.Model;
using API.Repository.Interfaces;

namespace API.Business
{
    public class ComputerBusinessImplementation : IComputerBusiness
    {
        private readonly IRepository<Capture> _repository;

        public ComputerBusinessImplementation(IRepository<Capture> repository)
        {
            _repository = repository;
        }

        public Capture Create(Capture computer)
        {
            return _repository.Create(computer);
        }

        public List<Capture> FindAll()
        {
            return _repository.FindAll();
        }

        public Capture FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}
