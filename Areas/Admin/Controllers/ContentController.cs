﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult Create()
		{
			SetViewBag();
			return View();
		}

		
		[HttpPost]
		public ActionResult Create(Content model)
		{
			if(ModelState.IsValid)
			{

			}
			return View();
		}
		[HttpGet]
		public ActionResult Edit(long id)
		{
			var dao = new ContentDao();
			var content = dao.getByID(id);
			SetViewBag(content.CategoryID);
			return View();
		}

		[HttpPost]
		public ActionResult Edit(Content model)
		{
			if (ModelState.IsValid)
			{

			}
			return View(model.CategoryID);
		}

		public void SetViewBag(long? selectedId=null)
		{
			var dao = new CategoryDao();
			ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
		}
    }
}