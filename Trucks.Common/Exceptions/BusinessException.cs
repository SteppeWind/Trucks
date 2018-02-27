﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}