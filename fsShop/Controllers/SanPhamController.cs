using fsShop.Models;
using HomeBi.Libraries.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace fsShop.Controllers
{
    public class SanPhamController : Controller
    {
        fsShopDataContext data = new fsShopDataContext();
        // GET: SanPham
        public ActionResult Index(int? page)
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
        }

        public ActionResult Details(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.SanPhams where n.MaSanPham == id select n;
                return View(nxb.Single());
            } 
            else
                return RedirectToAction("Dangnhap", "User");
        }

        public ActionResult Delete(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var tl = from n in data.SanPhams where n.MaSanPham == id select n;
                return View(tl.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");
           
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            SanPham nxb = data.SanPhams.SingleOrDefault(n => n.MaSanPham == id);
            data.SanPhams.DeleteOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "SanPham");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.SanPhams where n.MaSanPham == id select n;
                return View(nxb.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");        
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            SanPham nxb = data.SanPhams.SingleOrDefault(n => n.MaSanPham == id);
            UpdateModel(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "SanPham");
        }
    }
}