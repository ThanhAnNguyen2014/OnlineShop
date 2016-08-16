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
	public class FooterDao
	{
		OnlineShopDbContext db = null;
		public FooterDao()
		{
			db = new OnlineShopDbContext();

		}
		public Footer GetFooter()
		{
			return db.Footers.SingleOrDefault(x => x.Status == true);
		}
	}
}
