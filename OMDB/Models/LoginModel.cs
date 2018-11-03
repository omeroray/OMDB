using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class LoginModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage ="*")]
        public string Username { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}