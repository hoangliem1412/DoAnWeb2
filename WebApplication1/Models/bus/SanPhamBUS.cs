using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.bus
{
    public class SanPhamBUS
    {
        static ShopConnectionDB db = new ShopConnectionDB();

        public static PetaPoco.Page<dynamic> DanhSachFull(int pgNumb = 1, int itemsPerPg = 20)
        {
            var sql = "select sp.*, lsp.Ten as TenLoai, nsx.Ten as TenNSX from sanpham sp join LOAISANPHAM lsp on sp.Loai = lsp.ID join NHASANXUAT nsx on sp.NhaSX = nsx.ID";
            return db.Page<dynamic>(pgNumb, itemsPerPg, sql);
        }

        public static PetaPoco.Page<SANPHAM> DanhSach(int pgNumb=1, int itemsPerPg=20)
        {
            var sql = "select * from sanpham where khoa=0 order by ngaycapnhat desc";
            return db.Page<SANPHAM>(pgNumb, itemsPerPg, sql);
        }

        public static PetaPoco.Page<SANPHAM> TimKiem(string key, string order, int pgNumb=1, int itemsPerPg=20)
        {
            var sql = string.Format("select * from sanpham where khoa=0 {0} order by ngaycapnhat desc {1}", string.IsNullOrEmpty(key) ? "" : " and " + key, string.IsNullOrEmpty(order) ? "" : ", " + order);
            return db.Page<SANPHAM>(pgNumb, itemsPerPg, sql);
        }

        public static dynamic ChiTiet(int id)
        {
            var sql = string.Format(";exec up_getProductFull {0}", id);
            return db.FirstOrDefault<dynamic>(sql);
        }

        public static SANPHAM ChiTietOri(int id)
        {
            var sql = string.Format("select * from sanpham where id = {0}", id);
            return db.FirstOrDefault<SANPHAM>(sql);
        }

        public static void Add(SANPHAM sp)
        {
            db.Insert("sanpham", sp);
        }

        public static void Update(SANPHAM sp)
        {
            db.Update("sanpham", "ID", sp);
        }
    }
}