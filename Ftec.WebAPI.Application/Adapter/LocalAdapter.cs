using Ftec.WebAPI.Application.DTO;
using Ftec.WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.WebAPI.Application.Adapter
{
    public static class LocalAdapter
    {
        public static LocalDTO ToDTO(Local dl)
        {
            return new LocalDTO()
            {
                Identificador = dl.Identificador,
                Latitude = dl.Latitude,
                Longitude = dl.Longitude,
                Altitude = dl.Altitude,
                Speed = dl.Speed,
                Accuracy = dl.Accuracy,
                Bearing = dl.Bearing,
                Data = dl.Data

            };
        }

        public static Local ToDomain(LocalDTO dl)
        {
            return new Local()
            {
                Identificador = dl.Identificador,
                Latitude = dl.Latitude,
                Longitude = dl.Longitude,
                Speed = dl.Speed,
                Altitude = dl.Altitude,
                Accuracy = dl.Accuracy,
                Bearing = dl.Bearing,
                Data = dl.Data

            };
        }
    }
}
