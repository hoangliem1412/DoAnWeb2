using WebApplication1.Models.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            else
            {
                var sp = SanPhamBUS.ChiTiet(id.Value);
                ViewBag.DSKM = SanPhamBUS.TimKiem("gia > khuyenmai", "", 1, 5).Items;
                ViewBag.CungLoai = SanPhamBUS.TimKiem("loai = " + sp.Loai, "", 1, 7).Items;
                ViewBag.HinhAnh = HinhAnhSpBUS.DanhSach(id.Value);
                ViewBag.BinhLuan = BinhLuanBUS.DanhSach(id.Value);
                return View(sp);
            }
        }
    }
}