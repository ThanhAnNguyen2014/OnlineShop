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
	public class CategoryDao
	{
		OnlineShopDbContext db = null;
		public CategoryDao()
		{
			db =new OnlineShopDbContext();
		}
		public Category getByID(long id)
		{
			return db.Categories.Find(id);
		}
		public List<Category>ListAll()
		{
			return db.Categories.Where(x => x.Status == true).ToList();
		}

		public ProductCategory ViewDetail(long id)
		{
			return db.ProductCategories.Find(id);
		}


	}
}
