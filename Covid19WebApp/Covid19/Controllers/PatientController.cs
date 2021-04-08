using Covid19.Entities;
using Covid19.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: PatientController
        public ActionResult Index()
        {
            var patient = _patientService.GetPatients();
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
            return RedirectToAction(nameof(Index));
        }

    }
}
