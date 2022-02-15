using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Market.Resources
{
    public class AuthUserResource
    {
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
