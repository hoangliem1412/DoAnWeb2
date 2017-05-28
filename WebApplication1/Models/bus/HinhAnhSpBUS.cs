using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.bus
{
	public class HinhAnhSpBUS
	{
        static ShopConnectionDB db = new ShopConnectionDB();

        public static IEnumerable<HINHANHSP> DanhSach(int spid)
        {
            var sql = string.Format("select * from hinhanhsp where masanpham = {0}", spid);
            return db.Query<HINHANHSP>(sql);
        }

        public static void Add(int spid, string img)
        {
            var item = new HINHANHSP() { MaSanPham = spid, Ten = img };
            db.Insert("hinhanhsp", item);
        }

        public static void Delete(int spid, string img)
        {
            var sql = string.Format("delete from hinhanhsp where masanpham = {0} and ten = N'{1}'", spid, img);
            db.Execute(sql);
        }
	}
}