using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.bus
{
    public class BinhLuanBUS
    {
        static ShopConnectionDB db = new ShopConnectionDB();

        public static IEnumerable<dynamic> DanhSach(int spid)
        {
            var sql = string.Format("select bl.*, isnull(tv.fullname,'') as HoTen from binhluan bl left join aspnetusers tv on bl.makhachhang = tv.id where masanpham = {0}", spid);
            return db.Query<dynamic>(sql);
        }
    }
}