using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.WebAPI.Application.DTO
{
    public class LocalDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public float Speed { get; set; }
        public float Accuracy { get; set; }
        public float Bearing { get; set; }
        public DateTime Data { get; set; }
        public String Identificador { get; set; }
    }
}
