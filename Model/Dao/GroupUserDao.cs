using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Collections;

namespace Model.Dao
{
	public class GroupUserDao
	{
		OnlineShopDbContext db = null;
		public GroupUserDao()
		{
			db = new OnlineShopDbContext();
		}
		public string Insert(UserGroup entity)
		{
			db.UserGroups.Add(entity);
			db.SaveChanges();
			return entity.ID;
		}

		public bool Delete(string id)
		{
			try
			{
				var userGroup = db.UserGroups.Find(id);
				db.UserGroups.Remove(userGroup);
				db.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
			
		}

		public bool Update(UserGroup entity)
		{
			try
			{
				var userGroup = db.UserGroups.Find(entity.ID);
				if(!string.IsNullOrEmpty(entity.Name))
				{
					userGroup.Name = entity.Name;
				}
				db.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
			
		}
		public IEnumerable<UserGroup> ListAllPaging(string searchString, int page, int pageSize)
		{
			IQueryable<UserGroup> model = db.UserGroups;
			// kiểm tra xem có chuỗi nhập vào hay k. sau đó thực hiện tìm kiếm
			// sắp xếp theo thứ tự giảm dần
			if (!string.IsNullOrEmpty(searchString))
			{
				model = model.Where(x => x.ID.Contains(searchString) || x.Name.Contains(searchString));

			}
			return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
		}
	}
}
