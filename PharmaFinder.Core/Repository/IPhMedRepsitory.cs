﻿using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IPhMedRepsitory
    {
        public void CreatephMed(Phmed phmed);
    }
}
