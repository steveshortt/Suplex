﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palladium.Security.DaclModel
{
    public interface ICloneable<T> : ICloneable
    {
        T Clone(bool shallow = true);
    }
}