using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class IcerikController : Controller
    {

        CommentRepository commentRepository = new CommentRepository();
        IcerikRepository icerikRepository = new IcerikRepository();
        Context c = new Context();

        public IActionResult Index(int page=1)
        {
            return View(icerikRepository.TList().ToPagedList(page, 3));
        }

        

        [HttpGet]
        public IActionResult IcerikAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IcerikAdd(icerikekle p)
        {
            Icerik f = new Icerik();
            if (p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }

            f.IcerikName = p.IcerikName;
            f.IcerikConn = p.IcerikConn;
            f.IcerikDescription = p.IcerikDescription;

            icerikRepository.TAdd(f);

            return RedirectToAction("Index");
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult IcerikDelete(int id)
        {
            icerikRepository.TDelete(new Icerik { IcerikId = id });
            return RedirectToAction("Index");
        }
        

        public IActionResult BlogDetails(int id)
        {
            Icerik icerik = icerikRepository.TGet(id);

            if (icerik != null)
            {
                return View(icerikRepository.List(x => x.IcerikId == id));
            }
            return View(icerikRepository.TList());
     
        }

        public IActionResult CommentGetList(int id)
        {
            Comment comment = commentRepository.TGet(id);

            if (comment != null)
            {
                return View(commentRepository.List(x => x.IcerikId == id));
            }
            return View(commentRepository.TList());
        }

    }
}
