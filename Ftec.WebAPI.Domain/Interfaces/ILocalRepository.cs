using Ftec.WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.WebAPI.Domain.Interfaces
{
    public interface ILocalRepository
    {
        String Insert(Local local);
        
    }
}
