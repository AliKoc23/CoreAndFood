using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class CommentGetList : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {

            CommentRepository commentRepository = new CommentRepository();
            var comlist = commentRepository.List(x => x.CommentID == id);
            return View(comlist);
        }
    }
}
