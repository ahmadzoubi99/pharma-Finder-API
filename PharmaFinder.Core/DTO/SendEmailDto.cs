﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class SendEmailDto
    {
        public string To { get; set; } = string.Empty;
        public string PlainText { get; set; } = string.Empty;
        public string Html { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
