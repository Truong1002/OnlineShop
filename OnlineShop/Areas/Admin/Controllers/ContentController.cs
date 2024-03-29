﻿using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pagesize = 3)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            setViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetById(id);
            setViewBag(content.CategoryID);
            return View(content);
        }
         
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            setViewBag(model.CategoryID);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] 
        public ActionResult Create(Content model)
        {
            if(ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                model.CreatedBy = session.UserName;
                var culture = Session[CommonConstants.CurrentCulture];
                model.Language = culture.ToString();
                new ContentDao().Create(model);
                return RedirectToAction("Index");
            }
            setViewBag();
            return View();
        }

        
        public void setViewBag(long? SelectedId = null) 
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", SelectedId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}