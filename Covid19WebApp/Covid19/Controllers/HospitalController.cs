using Covid19.Entities;
using Covid19.Models;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;
        private readonly ICityService _cityService;
        private readonly ILogger<HospitalController> _logger;

        public HospitalController(IHospitalService hospitalService,
            ICityService cityService,
            ILogger<HospitalController> logger)
        {
            _hospitalService = hospitalService;
            _cityService = cityService;
            _logger = logger;
        }

        // GET: HospitalController
        public ActionResult Index()
        {
            var hospital = _hospitalService.GetHospitals();
            _logger.LogInformation("All hospitals were listed!");
            return View(hospital);
        }

        // GET: HospitalController/Details/5
        public ActionResult Details(int id)
        {
            var hospital = _hospitalService.GetHospitalByID(id);
            return View(hospital);
        }

        // GET: HospitalController/Create
        public ActionResult Create()
        {
            var cities = _cityService.GetCities();
            var dropdown = _hospitalService.cityList(cities);
            ViewBag.cityList = dropdown;

            return View();
        }

        // POST: HospitalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hospital hospital)
        {
            //Hospital hospital = new Hospital();
            //hospital.city = model.city;
            //hospital.cityID = model.cityID;
            //hospital.currentCapacity = model.currentCapacity;
            //hospital.hospitalID = model.hospitalID;
            //hospital.hospitalName = model.hospitalName;
            //hospital.maxCapacity = model.maxCapacity;
            //hospital.cityName = model.cityName;

            if (hospital != null)
            {
                if (!string.IsNullOrEmpty(hospital.hospitalName) || !string.IsNullOrWhiteSpace(hospital.hospitalName))
                {
                    _hospitalService.Add(hospital);
                    _logger.LogInformation("New City was added!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HospitalController/Edit/5
        public ActionResult Edit(int id)
        {
            var hospital = _hospitalService.GetHospitalByID(id);
            return View(hospital);
        }

        // POST: HospitalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hospital hospital)
        {
            if (hospital != null)
            {
                if (!string.IsNullOrEmpty(hospital.hospitalName) || !string.IsNullOrWhiteSpace(hospital.hospitalName))
                {
                    _hospitalService.Edit(hospital);
                    _logger.LogInformation("The hospital was updated!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HospitalController/Delete/5
        public ActionResult Delete(int id)
        {
            var hospital = _hospitalService.GetHospitalByID(id);
            return View(hospital);
        }

        // POST: HospitalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hospital hospital)
        {
            _hospitalService.Delete(hospital);
            _logger.LogInformation("The hospital was deleted!");
            return RedirectToAction(nameof(Index));
        }

    }
}
