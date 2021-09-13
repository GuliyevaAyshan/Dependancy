using Dependency.Model;
using Dependency.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamRepository _teams;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public HomeController(ITeamRepository teams, IHostingEnvironment hostingEnvironment)
        {
            _teams = teams;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Team> teams = _teams.GetTeams();
            return View(teams);

        }

        public IActionResult TeamAction()
        {
            List<Team> teams = _teams.GetTeams();

            return View(teams);
        }
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult AddTeam(Team model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {

                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/jpg")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;

                            _teams.AddTeam(model);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Can upload max 2MB");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Only .png, .jpeg types");
                    }

                }
                else //if no photo
                {

                    _teams.AddTeam(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int?id)
        {

            if (id== null)
            {
                return NotFound();
            }
            var teamm= _teams.GetTeams().FirstOrDefault(i => i.Id == id);
            return View(teamm);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Team model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                   
                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/jpg" || model.ImageFile.ContentType == "image/gif")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", model.Image);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _teams.Update(model);

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Only 2 Mb Please!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Only .jpg, .png, .gif Please!");
                    }
                }
                else
                {

                    _teams.Update(model);

                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
        public IActionResult Delete(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teamm = _teams.GetTeams().FirstOrDefault(i => i.Id == id);

            return View(teamm);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

           //Team team = _teams.GetTeams().FirstOrDefault(i => i.Id == id);
            _teams.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
