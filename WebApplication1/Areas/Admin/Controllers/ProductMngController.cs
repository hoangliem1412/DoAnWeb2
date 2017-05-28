using WebApplication1.Models.bus;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    //[Authorize(Roles="Admin")]
    public class ProductMngController : Controller
    {
        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            var ds = SanPhamBUS.DanhSachFull(page.Value, 25);
            return View(ds);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Loai = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            ViewBag.NhaSX = new SelectList(NhaSanXuatBUS.DanhSach(), "ID", "Ten");
            return View();
        }

        [HttpPost]
        public ActionResult Add(SANPHAM sp, HttpPostedFileBase HinhAnhChinh, IEnumerable<HttpPostedFileBase> HinhAnhPhu)
        {
            sp.NgayCapNhat = DateTime.Now;
            string mainImgName = SaveImg(HinhAnhChinh);

            if (!string.IsNullOrEmpty(mainImgName))
                sp.HinhAnh = mainImgName;

            SanPhamBUS.Add(sp);

            if (HinhAnhPhu != null && HinhAnhPhu.Count() > 0)
            {
                foreach (var img in HinhAnhPhu)
                {
                    string imgName = SaveImg(img);
                    if (!string.IsNullOrEmpty(imgName))
                        HinhAnhSpBUS.Add(sp.ID, imgName);
                }
            }

            ViewBag.Loai = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            ViewBag.NhaSX = new SelectList(NhaSanXuatBUS.DanhSach(), "ID", "Ten");
            return View();
        }

        [NonAction]
        public string SaveImg(HttpPostedFileBase img, string origin = "")
        {
            string name = "";
            if (img != null && img.ContentLength > 0)
            {
                if (string.IsNullOrEmpty(origin))
                    name = Guid.NewGuid().ToString() + img.FileName.Substring(img.FileName.LastIndexOf('.'));
                else
                    name = origin;
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/images/products/"), name);
                img.SaveAs(path);
            }
            return name;
        }
        
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var sp = SanPhamBUS.ChiTietOri(id.Value);
            ViewBag.Loai = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            ViewBag.NhaSX = new SelectList(NhaSanXuatBUS.DanhSach(), "ID", "Ten");
            ViewBag.HinhAnhPhu = HinhAnhSpBUS.DanhSach(id.Value);

            return View(sp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase HinhAnhChinh, IEnumerable<HttpPostedFileBase> HinhAnhPhu, string[] delHinhAnhPhu)
        {
            sp.NgayCapNhat = DateTime.Now;
            string mainImgName = SaveImg(HinhAnhChinh, sp.HinhAnh);

            if (!string.IsNullOrEmpty(mainImgName))
                sp.HinhAnh = mainImgName;

            SanPhamBUS.Update(sp);

            if (HinhAnhPhu != null && HinhAnhPhu.Count() > 0)
            {
                foreach (var img in HinhAnhPhu)
                {
                    string imgName = SaveImg(img);
                    if (!string.IsNullOrEmpty(imgName))
                        HinhAnhSpBUS.Add(sp.ID, imgName);
                }
            }

            if (delHinhAnhPhu != null && delHinhAnhPhu.Count() > 0)
            {
                foreach (var img in delHinhAnhPhu)
                {
                    if (!string.IsNullOrEmpty(img))
                        HinhAnhSpBUS.Delete(sp.ID, img);
                }
            }

            ViewBag.Loai = new SelectList(LoaiSanPhamBUS.DanhSach(), "ID", "Ten");
            ViewBag.NhaSX = new SelectList(NhaSanXuatBUS.DanhSach(), "ID", "Ten");
            ViewBag.HinhAnhPhu = HinhAnhSpBUS.DanhSach(sp.ID);
            return View(sp);
        }
    }
}