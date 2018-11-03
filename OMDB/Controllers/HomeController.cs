using OMDB.BLL;
using OMDB.DAL.EntityFramework;
using OMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Movies", new { id = (int?)null });
        }

        public ActionResult Actors(int? id)
        {
            {
                CategoryService cservice = new CategoryService();
                List<Category> listcategory = cservice.List();
                ViewBag.CategoryListSource = listcategory;

                // return View();

                ListActorsModel model = new ListActorsModel();
                ActorService aservice = new ActorService();
                if (id == null)
                {
                    model.People = aservice.List();
                }
                //else
                //{
                //    model.People = aservice.ListByCategoryId(id.Value);
                //}


                return View(model);
            }
        }

        public ActionResult Movies(int? id)
        {
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;

            // return View();

            ListMoviesModel model = new ListMoviesModel();
            MovieService mservice = new MovieService();
            if (id == null)
            {
                model.MovieList = mservice.List();
            }
            else
            {
                model.MovieList = mservice.ListByCategoryId(id.Value);
            }

            return View(model);
        }

        public ActionResult MovieDetail(int id)
        {
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;

            MovieDetailModel model = new MovieDetailModel();

            MovieService mservice = new MovieService();
            Movie movie = mservice.GetMovieById(id);

            model.PosterFileName = movie.PosterPicture;
            model.Name = movie.Name;
            model.Description = movie.Description;
            model.ReleaseDate = movie.ReleaseDate;
            model.Runtime = movie.Runtime;
            model.Actors = mservice.GetMovieCastCrewByMovieId(id);

            return View(model);
        }

        public ActionResult ActorDetail(int id)
        {
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;

            ActorDetailModel model = new Models.ActorDetailModel();

            ActorService aservice = new ActorService();
            CastCrew actor = aservice.GetActorById(id);

            model.ProfilePictureFileName = actor.ProfilePicture;
            model.FirstName = actor.FirstName;
            model.LastName = actor.LastName;
            model.Bio = actor.Bio;
            model.BirthDate = actor.BirthDate;
            model.Movies = aservice.GetMovieCastCrewByActorId(id);

            return View(model);
        }
    }
}