using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.GrandPrixDtos
{
    public class GrandPrixUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime GrandPrixDate { get; set; }
        public int SeasonId { get; set; }
        public bool IsActive { get; set; }
    }
}
