using OMDB.BLL;
using OMDB.DAL.EntityFramework;
using OMDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMDB.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateMovie()
        {
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;

            return View();
        }

        [HttpPost]
        public ActionResult CreateMovie(CreateMovieModel model, HttpPostedFileBase poster)
        {
            if (ModelState.IsValid)
            {
                var fullFileName = "";

                if (poster != null && poster.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var ext = Path.GetExtension(poster.FileName);
                    fullFileName = fileName + ext;
                    var fullPath = Path.Combine(Server.MapPath("~/documents/posters"), fullFileName);
                    poster.SaveAs(fullPath);
                }

                Movie movie = new Movie();
                movie.Name = model.Name;
                movie.Description = model.Description;
                movie.ReleaseDate = DateTime.Parse(model.ReleaseDate);
                movie.Runtime = model.Runtime;
                movie.PosterPicture = fullFileName;

                MovieService mservice = new MovieService();
                mservice.Create(movie, model.SelectedCategories);

            }
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;
            return View();
        }

        public ActionResult CreateActor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateActor(CreateActorModel model, HttpPostedFileBase actorPicture)
        {
            if (ModelState.IsValid)
            {
                var fullFileName = "";

                if (actorPicture != null && actorPicture.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var ext = Path.GetExtension(actorPicture.FileName);
                    fullFileName = fileName + ext;
                    var fullPath = Path.Combine(Server.MapPath("~/documents/actors"), fullFileName);
                    actorPicture.SaveAs(fullPath);
                }

                CastCrew actor = new CastCrew();
                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.BirthDate = DateTime.Parse(model.BirthDate);
                actor.Bio = model.Bio;
                actor.ProfilePicture = fullFileName;

                ActorService mservice = new ActorService();
                mservice.Create(actor);

            }
            return View();
        }

        public ActionResult ListActors()
        {
            ListActorsModel model = new ListActorsModel();
            ActorService mservice = new ActorService();
            model.People = mservice.List();

            return View(model);
        }

        public ActionResult ListMovies()
        {
            ListMoviesModel model = new ListMoviesModel();
            MovieService mservice = new MovieService();
            model.MovieList = mservice.List();

            return View(model);
        }

        public ActionResult DeleteActor(int id)
        {
            ActorService aservice = new ActorService();
            aservice.Remove(id);

            return RedirectToAction("ListActors");
        }

        public ActionResult DeleteMovie(int id)
        {
            MovieService mservice = new MovieService();
            mservice.Remove(id);

            return RedirectToAction("ListMovies");
        }

        public ActionResult UpdateActor(int id)
        {
            ActorService aservice = new ActorService();
            CastCrew actor = aservice.GetActorById(id);
            UpdateActorModel model = new UpdateActorModel();

            model.FirstName = actor.FirstName;
            model.LastName = actor.LastName;
            model.BirthDate = actor.BirthDate.ToString("dd.MM.yyyy"); //araştır
            model.Bio = actor.Bio;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateActor(int id, UpdateActorModel model, HttpPostedFileBase actorPicture)
        {
            if (ModelState.IsValid)
            {
                ActorService aservice = new ActorService();
                CastCrew actor = aservice.GetActorById(id);

                var fullFileName = "";

                if (actorPicture != null && actorPicture.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var ext = Path.GetExtension(actorPicture.FileName);
                    fullFileName = fileName + ext;
                    var fullPath = Path.Combine(Server.MapPath("~/documents/actors"), fullFileName);
                    actorPicture.SaveAs(fullPath);
                    actor.ProfilePicture = fullFileName;
                }
                
                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.BirthDate = DateTime.Parse(model.BirthDate);
                actor.Bio = model.Bio;

                aservice.UpdateActor(actor);

                return View(model);

            }
            return View(model);
        }

        public ActionResult UpdateMovie(int id)
        {
            MovieService mservice = new MovieService();
            Movie movie = mservice.GetMovieById(id);
            UpdateMovieModel model = new UpdateMovieModel();

            model.Name = movie.Name;
            model.Description = movie.Description;
            model.ReleaseDate = movie.ReleaseDate.ToString("dd.MM.yyyy");
            model.Runtime = movie.Runtime;

            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;
            model.SelectedCategories = cservice.GetSelectedCategoriesByMovieId(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateMovie(int id, UpdateMovieModel model, HttpPostedFileBase poster)
        {
            CategoryService cservice = new CategoryService();
            List<Category> listcategory = cservice.List();
            ViewBag.CategoryListSource = listcategory;

            if (ModelState.IsValid)
            {
                MovieService mservice = new MovieService();
                Movie movie = mservice.GetMovieById(id);

                var fullFileName = "";

                if (poster != null && poster.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var ext = Path.GetExtension(poster.FileName);
                    fullFileName = fileName + ext;
                    var fullPath = Path.Combine(Server.MapPath("~/documents/posters"), fullFileName);
                    poster.SaveAs(fullPath);
                    movie.PosterPicture = fullFileName;
                }
                
                movie.Name = model.Name;
                movie.Description = model.Description;
                movie.ReleaseDate = DateTime.Parse(model.ReleaseDate);
                movie.Runtime = model.Runtime;

                mservice.UpdateMovie(movie, model.SelectedCategories);


                return View(model);
            }

            return View();

        }

        public ActionResult ListUsers()
        {
            ListUsersModel model = new ListUsersModel();
            AccountService aservice = new AccountService();
            model.User = aservice.List();

            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            AccountService aservice = new AccountService();
            aservice.Remove(id);

            return RedirectToAction("ListUsers");
        }

        public ActionResult ManageMovieActorRelation(int id)
        {
            MovieService mservice = new MovieService();
            ActorService aservice = new ActorService();
            TitleService tservice = new TitleService();

            ViewBag.MovieId = id;
            ViewBag.ActorSelectListSource = new SelectList(aservice.List().Select(x => new { Text = (x.FirstName + " " + x.LastName), Value = x.Id }), "Value", "Text", null);
            ViewBag.TitleSelectListSource = new SelectList(tservice.List().Select(x => new { Text = x.Name, Value = x.Id }), "Value", "Text", null);
            ViewBag.Actors = mservice.GetMovieCastCrewByMovieId(id);
            return View();
        }

        [HttpPost]
        public ActionResult ManageMovieActorRelation(int id, CreateMovieCastCrewModel model)
        {
            MovieService mservice = new MovieService();
            ActorService aservice = new ActorService();
            TitleService tservice = new TitleService();

            MovieCastCrew movieActor = new MovieCastCrew();
            movieActor.MovieId = model.MovieId;
            movieActor.CastCrewId = model.CastCrewId;
            movieActor.TitleId = model.Title;

            mservice.CreateActorRelation(movieActor);

            ViewBag.MovieId = id;
            ViewBag.ActorSelectListSource = new SelectList(aservice.List().Select(x => new { Text = (x.FirstName + " " + x.LastName), Value = x.Id }), "Value", "Text", null);
            ViewBag.TitleSelectListSource = new SelectList(tservice.List().Select(x => new { Text = x.Name, Value = x.Id }), "Value", "Text", null);
            ViewBag.Actors = mservice.GetMovieCastCrewByMovieId(id);
            return View();
        }

        public ActionResult DeleteMovieActorRelation(int id, int movieId)
        {
            MovieService mservice = new MovieService();
            mservice.RemoveActorRelation(id);

            return RedirectToAction("ManageMovieActorRelation", new { id = movieId });
        }
    }
}