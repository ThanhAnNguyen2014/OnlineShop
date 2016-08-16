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
    public class UserGroupController : BaseController
    {
        // GET: Admin/UserGroup
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
			var dao = new GroupUserDao();
			var model = dao.ListAllPaging(searchString, page, pageSize);
			// giữ giá trị tìm kiếm khi chuyển các phân trang
			ViewBag.SearchString = searchString;
			if (model.Count() == 0)
			{
				SetAlert("Kết quả tìm kiếm không tồn tại.", "warning");
				//ModelState.AddModelError("", "Kết quả tìm kiếm không tồn tại.");
			}
			return View(model);
		}
    }
}