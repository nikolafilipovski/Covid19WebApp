using Covid19.Entities;
using Covid19.Models;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public HospitalController(IHospitalService hospitalService, ICityService cityService)
        {
            _hospitalService = hospitalService;
            _cityService = cityService;
        }

        // GET: HospitalController
        public ActionResult Index()
        {
            var hospital = _hospitalService.GetHospitals();
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
            //var hospital = _hospitalService.GetHospitals();
            //var cities = _cityService.GetCities();
            //ViewBag.cityList = cities;

            return View();
        }

        // POST: HospitalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HospitalViewModel model)
        {
            Hospital hospital = new Hospital();
            hospital.city = model.city;
            hospital.cityID = model.cityID;
            hospital.currentCapacity = model.currentCapacity;
            hospital.hospitalID = model.hospitalID;
            hospital.hospitalName = model.hospitalName;
            hospital.maxCapacity = model.maxCapacity;
            hospital.cityName = model.cityName;

            if (model != null)
            {
                if (!string.IsNullOrEmpty(hospital.hospitalName) || !string.IsNullOrWhiteSpace(hospital.hospitalName))
                {
                    _hospitalService.Add(hospital);
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
            return RedirectToAction(nameof(Index));
        }

    }
}
