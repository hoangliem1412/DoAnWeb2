using WebApplication1.Models.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(int? id, int? page)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            else
            {
                page = page ?? 1;
                ViewBag.ChiTiet = LoaiSanPhamBUS.ChiTiet(id.Value);
                ViewBag.DSLsp = LoaiSanPhamBUS.DanhSach().ToList();
                ViewBag.DSNsx = NhaSanXuatBUS.DanhSach();
                var dssp = SanPhamBUS.TimKiem("loai = " + id.Value, "", page.Value, 20);
                return View(dssp);
            }
        }
    }
}