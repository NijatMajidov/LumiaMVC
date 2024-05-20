﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Business.Exceptions
{
    public class ImageFileNotFoundException : Exception
    {
        public ImageFileNotFoundException(string name,string? message) : base(message)
        {
            PropertyName = name;
        }

        public string PropertyName { get; set; }

    }
}
