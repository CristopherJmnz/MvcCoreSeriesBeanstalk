using Microsoft.AspNetCore.Mvc;
using MvcCoreSeriesBeanstalk.Models;
using MvcCoreSeriesBeanstalk.Repositories;

namespace MvcCoreSeriesBeanstalk.Controllers
{
    public class SeriesController : Controller
    {
        private SeriesRepository repo;
        public SeriesController(SeriesRepository repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Serie> series = await this.repo.GetSeriesAsync();
            return View(series);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Serie serie)
        {
            await this.repo.InsertSerie(serie.Nombre, serie.Imagen, serie.Year);
            return RedirectToAction("Index");
        }
    }
}
