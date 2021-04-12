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
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IHospitalService _hospitalService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService,
            IHospitalService hospitalService,
            ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _hospitalService = hospitalService;
            _logger = logger;
        }

        // GET: PatientController
        public ActionResult Index()
        {
            var patient = _patientService.GetPatients();
            _logger.LogInformation("All patients were listed!");
            return View(patient);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            var patient = _patientService.GetPatientByID(id);
            return View(patient);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            var hospitals = _hospitalService.GetHospitals();
            var dropdown = _patientService.hospitalList(hospitals);
            ViewBag.hospitalList = dropdown;

            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrEmpty(patient.patientName) || !string.IsNullOrWhiteSpace(patient.patientName))
                {
                    _patientService.Add(patient);
                    _logger.LogInformation("New patient was added!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            var patient = _patientService.GetPatientByID(id);
            return View(patient);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrEmpty(patient.patientName) || !string.IsNullOrWhiteSpace(patient.patientName))
                {
                    _patientService.Edit(patient);
                    _logger.LogInformation("The patient was updated!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetPatientByID(id);
            return View(patient);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Patient patient)
        {
            _patientService.Delete(patient);
            _logger.LogInformation("The patient was deleted!");
            return RedirectToAction(nameof(Index));
        }

    }
}
