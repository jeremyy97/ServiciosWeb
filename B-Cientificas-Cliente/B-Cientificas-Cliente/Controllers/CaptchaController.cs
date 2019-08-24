using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft;

namespace B_Cientificas_Cliente.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        public ActionResult Index()
        {
            return View();
        }

        // GET: Captcha/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Captcha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Captcha/Create
        [HttpPost]
        public ActionResult FormSubmit()
        {
            //Validate Google recaptcha below

            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lc6a7MUAAAAACtiokHPd0-PYvvZX7K6uwECkGTQ";
            var client = new WebClient();

            ViewData["Message"] = "Google reCaptcha validation success";


            //Here I am returning to Index view: 

            return View("Index");
        }
        // GET: Captcha/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Captcha/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Captcha/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Captcha/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
