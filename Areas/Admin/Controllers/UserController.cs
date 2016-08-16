using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
		// GET: Admin/User
		public ActionResult Index(string searchString, int page = 1, int pageSize = 10)// trang hiện tại và số dòng hiện trong 1 trang của bản quản lý người dùng
        {
			var dao = new UserDao();
			var model = dao.ListAllPaging(searchString, page, pageSize);
			// giữ giá trị tìm kiếm khi chuyển các phân trang
			ViewBag.SearchString = searchString;
			if(model.Count()==0)
			{
				SetAlert("Kết quả tìm kiếm không tồn tại.", "warning");
				//ModelState.AddModelError("", "Kết quả tìm kiếm không tồn tại.");
			}
            return View(model);
        }
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				var dao = new UserDao();
				
				var encrytMD5Hash = Encryptor.MD5Hash(user.Password);
				user.Password = encrytMD5Hash;
				long id = dao.Insert(user);
				if (id > 0)
				{
					SetAlert("Thêm user thành công!","success");
					return RedirectToAction("Index", "User");
				}
				else
				{
					//ModelState.AddModelError("", "Thêm User không  thành công!");
					SetAlert("Lỗi! Thêm user không thành công!", "error");
				}
			}
			return View("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var user = new UserDao().ViewDetail(id);
			
		
			return View(user);
		}

		[HttpPost]
		public ActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				var dao = new UserDao();
				// kiem tra nguoi dung co nhap password k nếu nhập sẽ thực hiện update
				if(!string.IsNullOrEmpty(user.Password))
				{
					var encrytMD5Hash = Encryptor.MD5Hash(user.Password);
					user.Password = encrytMD5Hash;
				}
				var result = dao.Update(user);
				if (result)
				{
					SetAlert("Cập nhật user thành công!", "success");
					return RedirectToAction("Index", "User");
				}
				else
				{
					SetAlert("Lỗi!, Cập nhật user không thành công!", "error");
					//ModelState.AddModelError("", "Cập nhật User thành công!");
				}
			}
			return View("Index");
		}
		[HttpDelete]
		public ActionResult Delete(int id)
		{
			new UserDao().Delete(id);
			SetAlert("Xoá user thành công!", "success");
			return RedirectToAction("Index", "User");
		}
		[HttpGet]
		public ActionResult Details(int id)
		{
			var user = new UserDao().ViewDetail(id);
			return View(user);
		}
		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var result = new UserDao().ChangeStatus(id);
			return Json(new
			{
				status = result
			});
		}
	}
}