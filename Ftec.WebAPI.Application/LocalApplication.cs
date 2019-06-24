using Ftec.WebAPI.Application.Adapter;
using Ftec.WebAPI.Application.DTO;
using Ftec.WebAPI.Domain.Entities;
using Ftec.WebAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.WebAPI.Application
{
    public class LocalApplication
    {

        ILocalRepository localRepository;

        public LocalApplication(ILocalRepository localRepository)
        {
            this.localRepository =  localRepository;
        }

        public String Insert(LocalDTO localDto)
        {
            var local = LocalAdapter.ToDomain(localDto);

            return localRepository.Insert(local);
        }
        

    }

}
