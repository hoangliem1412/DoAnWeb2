using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.bus
{
    public class LoaiSanPhamBUS
    {
        static ShopConnectionDB db = new ShopConnectionDB();

        public static IEnumerable<LOAISANPHAM> DanhSach()
        {
            var sql = "select * from loaisanpham where khoa=0";
            return db.Query<LOAISANPHAM>(sql);
        }

        public static IEnumerable<dynamic> DanhSachFull()
        {
            var sql = "select lsp1.*, lsp2.Ten as ParentName from loaisanpham lsp1 left join loaisanpham lsp2 on lsp1.Parent = lsp2.ID";
            return db.Query<dynamic>(sql);
        }
        
        public static LOAISANPHAM ChiTiet(int id)
        {
            var sql = string.Format("select * from loaisanpham where id = {0}", id);
            return db.FirstOrDefault<LOAISANPHAM>(sql);
        }

        public static void Add(LOAISANPHAM lsp)
        {
            db.Insert("loaisanpham", lsp);
        }

        public static void Update(LOAISANPHAM lsp)
        {
            db.Update("loaisanpham", "ID", lsp);
        }
    }
}