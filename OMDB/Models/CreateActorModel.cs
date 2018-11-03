using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class CreateActorModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Doğum Tarihi")]
        public string BirthDate { get; set; }

        [Display(Name = "Biyografi")]
        public string Bio { get; set; }

        [Display(Name = "Profil Resmi")]
        public string ProfilePicture { get; set; }
    }
}