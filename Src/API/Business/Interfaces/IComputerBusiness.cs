using API.Model;
using System.Collections.Generic;

namespace API.Business.Interfaces
{
    public interface IComputerBusiness
    {
        Capture Create(Capture computer);
        List<Capture> FindAll();
        Capture FindById(long id);
    }
}
