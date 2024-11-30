﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.SeasonDtos
{
    public class SeasonAddDto
    {
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}