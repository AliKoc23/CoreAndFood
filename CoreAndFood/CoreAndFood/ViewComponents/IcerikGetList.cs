using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class IcerikGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            IcerikRepository icerikRepository = new IcerikRepository();
            var iceriklist = icerikRepository.TList();
            return View(iceriklist);
        }
    }
}
