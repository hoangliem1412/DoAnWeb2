using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.bus
{
    public class NhaSanXuatBUS
    {
        static ShopConnectionDB db = new ShopConnectionDB();

        public static IEnumerable<NHASANXUAT> DanhSachFull()
        {
            var sql = "select * from nhasanxuat";
            return db.Query<NHASANXUAT>(sql);
        }

        public static IEnumerable<NHASANXUAT> DanhSach()
        {
            var sql = "select * from nhasanxuat where khoa=0";
            return db.Query<NHASANXUAT>(sql);
        }

        public static NHASANXUAT ChiTiet(int id)
        {
            var sql = string.Format("select * from nhasanxuat where id = {0}", id);
            return db.FirstOrDefault<NHASANXUAT>(sql);
        }

        public static void Add(NHASANXUAT nsx)
        {
            db.Insert("nhasanxuat", nsx);
        }

        public static void Update(NHASANXUAT nsx)
        {
            db.Update("nhasanxuat", "ID", nsx);
        }
    }
}