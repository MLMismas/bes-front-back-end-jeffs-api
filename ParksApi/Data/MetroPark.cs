using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksApi.Data
{
    public class MetroPark
    {
        public int Id { get; set; }
        public string Reservation { get; set; }
        public string Acreage { get; set; }
        public string Notes { get; set; }
    }
}
