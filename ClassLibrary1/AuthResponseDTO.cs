﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Authmodels
{
    public class AuthResponseDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public bool IsAuthSuccessful { get; set; }

    }
}
