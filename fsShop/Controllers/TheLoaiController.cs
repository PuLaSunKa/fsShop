using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fsShop.Models;
namespace fsShop.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        fsShopDataContext data = new fsShopDataContext();
        public ActionResult Index()
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                return View(data.TheLoais.ToList());
            }
            else
                return RedirectToAction("Dangnhap", "User");   
        }
        public ActionResult Details(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.TheLoais where n.MaLoai == id select n;
                return View(nxb.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Dangnhap", "User");
           
        }
        [HttpPost]
        public ActionResult Create(TheLoai nxb)
        {
            data.TheLoais.InsertOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "TheLoai");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var tl = from n in data.TheLoais where n.MaLoai == id select n;
                return View(tl.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");
            
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DXacnhanxoa(int id)
        {
            TheLoai nxb = data.TheLoais.SingleOrDefault(n => n.MaLoai == id);
            data.TheLoais.DeleteOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "TheLoai");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.TheLoais where n.MaLoai == id select n;
                return View(nxb.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");
           
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            TheLoai nxb = data.TheLoais.SingleOrDefault(n => n.MaLoai == id);
            UpdateModel(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "TheLoai");
        }
    }
}