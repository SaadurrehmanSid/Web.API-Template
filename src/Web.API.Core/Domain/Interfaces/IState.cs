﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Domain.Interfaces
{
    public interface IState
    {
        public bool IsActive { get; set; }
    }
}
