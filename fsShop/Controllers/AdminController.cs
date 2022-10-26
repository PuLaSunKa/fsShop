using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fsShop.Models;
using HomeBi.Libraries.PagedList;

namespace fsShop.Controllers
{
    public class AdminController : Controller
    {
        fsShopDataContext data = new fsShopDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPham(int? page)
        {
            int pagesize = 7;
            int pagenum = (page ?? 1);
            if (Session["TaikhoanAdmin"] != null)
                return View(data.SanPhams.ToList().ToPagedList(pagenum, pagesize));
            else
                return RedirectToAction("Dangnhap", "User");

        }
        [HttpGet]
        public ActionResult Themmoisanpham()
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                //Dua du lieu vao dropdownList
                //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
                ViewBag.MaCD = new SelectList(data.NhanHangs.ToList().OrderBy(n => n.Ten), "MaNhanHang", "TenNhanHang");
                ViewBag.MaNXB = new SelectList(data.TheLoais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
                return View();
            }
            else
                return RedirectToAction("Dangnhap", "User");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoisanpham(SanPham sp)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaCD = new SelectList(data.NhanHangs.ToList().OrderBy(n => n.Ten), "MaNhanHang", "TenNhanHang");
            ViewBag.MaNXB = new SelectList(data.TheLoais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            //Kiem tra duong dan file
            data.SanPhams.InsertOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("SanPham", "Admin");
            //áđâsd
        }
    }

}