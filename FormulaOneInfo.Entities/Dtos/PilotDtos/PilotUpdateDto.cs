using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.PilotDtos
{
    public class PilotUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Thumbnail { get; set; }
        public string Nationality { get; set; }
        public bool IsActive { get; set; }
    }
}
