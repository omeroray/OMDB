using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class SingUpModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifre alanları eşleşmiyor!")]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Şifre Tekrar")]
        public string AgainPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Kullanıcı Tipi")]
        public int UserType { get; set; }

        [Display(Name = "Profil Fotoğrafı")]
        public string ProfilePicture { get; set; }
    }
}