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
    public class ProducerMngController : Controller
    {
        public ActionResult Index()
        {
            var ds = NhaSanXuatBUS.DanhSachFull();
            return View(ds);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NHASANXUAT nsx, HttpPostedFileBase imgLogo)
        {
            string mainImgName = SaveImg(imgLogo);

            if (!string.IsNullOrEmpty(mainImgName))
                nsx.Logo = mainImgName;

            NhaSanXuatBUS.Add(nsx);
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
                var path = System.IO.Path.Combine(Server.MapPath("~/Content/images/brands/"), name);
                img.SaveAs(path);
            }
            return name;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var nsx = NhaSanXuatBUS.ChiTiet(id.Value);
            return View(nsx);
        }

        [HttpPost]
        public ActionResult Edit(NHASANXUAT nsx, HttpPostedFileBase imgLogo)
        {
            string mainImgName = SaveImg(imgLogo);

            if (!string.IsNullOrEmpty(mainImgName))
                nsx.Logo = mainImgName;

            NhaSanXuatBUS.Update(nsx);
            return View(nsx);
        }
    }
}