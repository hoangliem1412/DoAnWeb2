using WebApplication1.Models.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        const int lLaptop = 1;
        const int lSmartPhone = 2;
        const int nsxApple = 1;

        public ActionResult Index()
        {
            ViewBag.DSSPMoi = SanPhamBUS.TimKiem("lasanphammoi=1", "", 1, 10).Items;
            ViewBag.DSSmartPhoneMoi = SanPhamBUS.TimKiem("lasanphammoi=1 and loai=" + lSmartPhone, "", 1, 10).Items;
            ViewBag.DSLaptopMoi = SanPhamBUS.TimKiem("lasanphammoi=1 and loai=" + lLaptop, "", 1, 10).Items;
            ViewBag.DSAppleMoi = SanPhamBUS.TimKiem("lasanphammoi=1 and nhasx=" + nsxApple, "", 1, 10).Items;
            ViewBag.DSSPHot = SanPhamBUS.TimKiem("lasanphamhot=1", "", 1, 10).Items;
            ViewBag.DSBestSeller = SanPhamBUS.TimKiem("", "luotmua desc", 1, 10).Items;
            return View();
        }

        public ActionResult PartialBrands()
        {
            var DSNsx = NhaSanXuatBUS.DanhSach();
            return PartialView(DSNsx);
        }

        public ActionResult PartialNavbar()
        {
            var DSLsp = LoaiSanPhamBUS.DanhSach().ToList();
            return PartialView(DSLsp);
        }
    }
}