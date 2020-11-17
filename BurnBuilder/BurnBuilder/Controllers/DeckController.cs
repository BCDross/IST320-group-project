﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurnBuilder.Controllers
{
    public class DeckController : Controller
    {
        // GET: DeckController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeckController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeckController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeckController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeckController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeckController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeckController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeckController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
