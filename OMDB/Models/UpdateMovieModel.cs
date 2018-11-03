using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class UpdateMovieModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Film Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Yayın Tarihi")]
        public string ReleaseDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Film Süresi")]
        public int Runtime { get; set; }

        [Display(Name = "Kategori")]
        public List<int> SelectedCategories { get; set; }

        [Display(Name = "Afiş")]
        public string PosterPicture { get; set; }
    }
}