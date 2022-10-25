using fsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fsShop.Controllers
{
    public class NhanHangController : Controller
    {
        // GET: NhanHang
        fsShopDataContext data = new fsShopDataContext();
        public ActionResult Index()
        {
            return View(data.NhanHangs.ToList());
        }
        public ActionResult Details(int id)
        {
            var nxb = from n in data.NhanHangs where n.MaNhanHang == id select n;
            return View(nxb.Single());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanHang nxb)
        {
            data.NhanHangs.InsertOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "NhanHang");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tl = from n in data.NhanHangs where n.MaNhanHang == id select n;
            return View(tl.Single());
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DXacnhanxoa(int id)
        {
            NhanHang nxb = data.NhanHangs.SingleOrDefault(n => n.MaNhanHang == id);
            data.NhanHangs.DeleteOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "NhanHang");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nxb = from n in data.NhanHangs where n.MaNhanHang == id select n;
            return View(nxb.Single());
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            NhanHang nxb = data.NhanHangs.SingleOrDefault(n => n.MaNhanHang == id);
            UpdateModel(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "NhanHang");
        }
    }
}