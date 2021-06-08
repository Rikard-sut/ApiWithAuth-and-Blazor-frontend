using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.AuthModels
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
