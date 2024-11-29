using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.TeamDtos
{
    public class TeamAddDto
    {
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActive { get; set; }
    }
}
