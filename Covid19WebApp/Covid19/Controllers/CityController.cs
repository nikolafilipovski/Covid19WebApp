using Covid19.Entities;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        // GET: CityController
        public ActionResult Index()
        {
            var city = _cityService.GetCities();
            _logger.LogInformation("All Cities were listed!");
            
            return View(city);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            var city = _cityService.GetCityByID(id);
            return View(city);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (city != null)
            {
                if (!string.IsNullOrEmpty(city.cityName) || !string.IsNullOrWhiteSpace(city.cityName))
                {
                    _cityService.Add(city);
                    _logger.LogInformation("New City was added!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            var city = _cityService.GetCityByID(id);
            return View(city);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, City city)
        {
            if (city != null)
            {
                if (!string.IsNullOrEmpty(city.cityName) || !string.IsNullOrWhiteSpace(city.cityName))
                {
                    _cityService.Edit(city);
                    _logger.LogInformation("The City was updated!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            var city = _cityService.GetCityByID(id);
            return View(city);
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, City city)
        {
            _cityService.Delete(city);
            _logger.LogInformation("The City was deleted!");
            return RedirectToAction(nameof(Index));
        }
    }
}
