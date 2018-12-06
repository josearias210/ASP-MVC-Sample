using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Wonder.Core.Interfaces;
using Wonder.Core.Models;

namespace WonderMoon.Web.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository userRepository;
        private IRolRepository rolRepository;

        public UsersController(IUserRepository userRepository, IRolRepository rolRepository)
        {
            this.userRepository = userRepository;
            this.rolRepository = rolRepository;
        }

        // GET: Users
        public ActionResult Index(int? page, string query)
        {
            var resultado=new Resultado<List<User>>(); 

            if (!String.IsNullOrEmpty(query))
            {
                 resultado = userRepository.FullSearch(query);
            }
            else {
                 resultado = userRepository.GetAllUser();
            }
            
            if (resultado.IsSuccess)
            {
                var users = resultado.Data.OrderBy(x => x.FirstName);
                int pageSize = int.Parse(ConfigurationManager.AppSettings["ItemByPage"]);
                int pageNumber = (page ?? 1);
                ViewBag.query = query;
                return View(users.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, resultado.Message);
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resultado = userRepository.GetUser(id.Value);
            if (resultado.IsSuccess)
            {
                var user = resultado.Data;
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, resultado.Message);
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(rolRepository.GetAll(), "RolId", "Name");
            return View();
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,SecondName,MobilePhone,HomePhone,EmailAddress,PrimaryAddress,RolId")] User user)
        {
            if (ModelState.IsValid)
            {
                var resultado = userRepository.RegisterUser(user);
                if (resultado.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, resultado.Error);
                }
            }

            ViewBag.RolId = new SelectList(rolRepository.GetAll(), "RolId", "Name");
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var resultado = userRepository.GetUser(id.Value);
            if (resultado.IsSuccess)
            {
                var user = resultado.Data;
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.RolId = new SelectList(rolRepository.GetAll().ToList(), "RolId", "Name", user.RolId);
                return View(user);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,SecondName,MobilePhone,HomePhone,EmailAddress,PrimaryAddress,RolId")] User user)
        {
            if (ModelState.IsValid)
            {
                var resultado = userRepository.EditUser(user);
                if (resultado.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, resultado.Error);
                }
            }

            ViewBag.RolId = new SelectList(rolRepository.GetAll().ToList(), "RolId", "Name",user.RolId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var resultado = userRepository.GetUser(id.Value);
            if (resultado.IsSuccess)
            {
                var user = resultado.Data;
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}
