﻿using EpistleLibrary.Models;
using EpistleLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace epistle_app.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            ViewBag.Username = user.Username;

            return View(new NoteModel
            {
                Content = ""
            });
        }

        [HttpPost]
        public IActionResult CreateNote(NoteModel note)
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            note.User = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));

            if (note.Content == "" || note.Content is null)
            {
                return RedirectToAction("Index");
            }

            NoteService.AddNote(note);

            ViewBag.Username = user.Username;

            return RedirectToAction("Index");
        }
    }
}