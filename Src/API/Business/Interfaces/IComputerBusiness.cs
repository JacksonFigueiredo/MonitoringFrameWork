using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business.Interfaces
{
    public interface IComputerBusiness
    {
        Capture Create(Capture computer);
        List<Capture> FindAll();
        Capture FindById(long id);
    }
}
