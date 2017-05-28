using WebApplication1.Models.bus;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryMngController : Controller
    {
        public ActionResult Index()
        {
            var ds = LoaiSanPhamBUS.DanhSachFull();
            return View(ds);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Parent = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            return View();
        }

        [HttpPost]
        public ActionResult Add(LOAISANPHAM lsp)
        {
            LoaiSanPhamBUS.Add(lsp);
            ViewBag.Parent = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var lsp = LoaiSanPhamBUS.ChiTiet(id.Value);
            ViewBag.Parent = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            return View(lsp);
        }

        [HttpPost]
        public ActionResult Edit(LOAISANPHAM lsp)
        {
            LoaiSanPhamBUS.Update(lsp);
            ViewBag.Parent = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            return View();
        }
    }
}