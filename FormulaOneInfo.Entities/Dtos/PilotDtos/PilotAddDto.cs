using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.PilotDtos
{
    public class PilotAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActive { get; set; }

    }
}
