﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expected_Interfaces
{
    public interface IServiceSunsetCalculator
    {
        DateTime GetSunset(DateTime date);
        DateTime GetSunrise(DateTime date);

    }
}
