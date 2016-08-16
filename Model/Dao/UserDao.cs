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
	public class UserDao
	{
		OnlineShopDbContext db = null;
		public UserDao()
		{
			db = new OnlineShopDbContext();
		}
		public long Insert(User entity)
		{
			entity.CreatedDate = DateTime.Now;
			db.Users.Add(entity);
			db.SaveChanges();
			return entity.ID;
		}
		public bool Update(User entity)
		{
			try
			{
				var user = db.Users.Find(entity.ID);
				user.Name = entity.Name;
				if(!string.IsNullOrEmpty(entity.Password))
				{
					user.Password = entity.Password;
				}
				user.Address = entity.Address;
				user.Email = entity.Email;
				user.ModifiedBy = entity.ModifiedBy;
				user.ModifiedDate = DateTime.Now;
				user.Status = entity.Status;
				user.Phone = entity.Phone;
				db.SaveChanges();

				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
		public bool Delete(int id)
		{
			try
			{
				var user = db.Users.Find(id);
				db.Users.Remove(user);
				db.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
		public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
		{
			IQueryable<User> model = db.Users;
			// kiểm tra xem có chuỗi nhập vào hay k. sau đó thực hiện tìm kiếm
			// sắp xếp theo thứ tự giảm dần
			if(!string.IsNullOrEmpty(searchString))
			{
				model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
				
			}
			return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
		}
		public User getById(string username)
		{
			return db.Users.SingleOrDefault(x=>x.UserName== username);
		}
		public User ViewDetail(int id)
		{
			return db.Users.Find(id);
		}


		public int Login(string userName, string passWord)
		{
			var result = db.Users.SingleOrDefault(x => x.UserName == userName);
			if (result ==null)
			{
				return 0; // tài khoản không tồn tại
			}
			else
			{
				if(result.Status==false)
				{
					return -1; // tài khoản đã bị khoá
				}
				else
				{
					if (result.Password == passWord)
					{
						return 1;// tài khoản hợp lệ
					}
					else
						return -2;	// mật khẩu nhập không đúng
				}
			}
		}
		public bool ChangeStatus(long id)
		{
			var user = db.Users.Find(id);
			user.Status = !user.Status;
			db.SaveChanges();
			return user.Status;
		}
	}

}
