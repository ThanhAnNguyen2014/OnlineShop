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
	public class ContentDao
	{
		OnlineShopDbContext db = null;
		public ContentDao()
		{
			db = new OnlineShopDbContext();
		}

		public Content getByID(long id)
		{
			return db.Contents.Find(id);
		}
	}
}
