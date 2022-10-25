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
            return View(data.TheLoais.ToList());
        }
        public ActionResult Details(int id)
        {
            var nxb = from n in data.TheLoais where n.MaLoai == id select n;
            return View(nxb.Single());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
            var tl = from n in data.TheLoais where n.MaLoai == id select n;
            return View(tl.Single());
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
            var nxb = from n in data.TheLoais where n.MaLoai == id select n;
            return View(nxb.Single());
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