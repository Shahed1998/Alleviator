﻿using Microsoft.AspNetCore.Mvc;
using Web.Models.Business_Entities;
using Web.Services.Interfaces;

namespace Web.Controllers
{
    public class TrackingController : Controller
    {
        private readonly ITrackerService _trackerService;

        public TrackingController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        public async Task<IActionResult> Index([FromBody] bool? IsSaved, int pageNumber=1, int pageSize=5, int count = 0, bool prevPage = false) 
        
        {

            if (prevPage)
            {
                count = count - pageSize - 1;
            }

            if (pageNumber <= 1) 
            {
                pageNumber = 1;
                count = 0;
            }

           
            var trackingList = await _trackerService.GetAllTrackers(pageNumber, pageSize);

            CompositeTrackerViewModel model = new CompositeTrackerViewModel();

            model.Pager = trackingList.Item1;

            var end = model.Pager.Count();

            ViewBag.IsSaved = TempData["isSaved"];
            ViewBag.Achievements = trackingList.Item2;
            ViewBag.Count = count;
            ViewBag.PageNumber = pageNumber;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CompositeTrackerViewModel model)
        {
            bool ts = await _trackerService.AddTracker(model.TrackerViewModel!);

            TempData["isSaved"] = ts;

            return RedirectToAction("Index");
        }

        [Route("Tracking/Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool isSaved = await _trackerService.Delete(Id);

            TempData["isSaved"] = isSaved;

            return RedirectToAction("Index");
        }

        [Route("Tracking/Edit/{Id}")]
        public IActionResult Edit(string Id)
        {
            throw new NotImplementedException();
        }


    }
}
