﻿using Microsoft.AspNetCore.Mvc;

namespace TestDataBase1to1toMany.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFservice ft;

        public FeatureController(IFservice ft)
        {
            this.ft = ft;
        }

        public IActionResult Index()
        {
            var Feature = ft.GetAllFeature();
            return View(Feature);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Feature feature)
        {
            if (ModelState.IsValid) return View();

            await ft.AddFeature(feature);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var feature = await ft.GetFeature(id);
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Feature feature)
        {
            if (ModelState.IsValid) return View();

            await ft.UbdateFeature(feature);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var feature = await ft.GetFeature(id);
            if (feature == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                await ft.DeleteFeature(feature);
            }
            return RedirectToAction("Index");
        }
    }
}
