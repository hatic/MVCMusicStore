using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore_Hatice.Models;
using System.Data.Entity;


namespace MVCMusicStore_Hatice.Controllers
{
    public class StoreController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //We’re using the HttpUtility.HtmlEncode utility method to sanitize the user input. 
        //This prevents users from injecting Javascript into our View with a link 
        //like /Store/Browse?Genre=<script>window.location=’http://hackersite.com’</script>.
        //zararlı kod çalışmasının önüne geçmek için  HttpUtility.HtmlEncode metodunu kulladık
        public ActionResult Browse(string genre)
        {// Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
            .Single(g => g.Name == genre);
            return View(genreModel);
        }
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

    }
}
