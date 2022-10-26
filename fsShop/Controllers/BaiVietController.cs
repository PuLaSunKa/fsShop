using fsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fsShop.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        fsShopDataContext data = new fsShopDataContext();
        public ActionResult Index()
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                return View(data.BaiDangs.ToList());
            }
            else
                return RedirectToAction("Dangnhap", "User");
        }
        public ActionResult Details(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.BaiDangs where n.MaBaiViet == id select n;
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
        public ActionResult Create(BaiDang nxb)
        {
            data.BaiDangs.InsertOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "BaiViet");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var tl = from n in data.BaiDangs where n.MaBaiViet == id select n;
                return View(tl.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DXacnhanxoa(int id)
        {
            BaiDang nxb = data.BaiDangs.SingleOrDefault(n => n.MaBaiViet == id);
            data.BaiDangs.DeleteOnSubmit(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "BaiViet");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["TaikhoanAdmin"] != null)
            {
                var nxb = from n in data.BaiDangs where n.MaBaiViet == id select n;
                return View(nxb.Single());
            }
            else
                return RedirectToAction("Dangnhap", "User");

        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            BaiDang nxb = data.BaiDangs.SingleOrDefault(n => n.MaBaiViet == id);
            UpdateModel(nxb);
            data.SubmitChanges();
            return RedirectToAction("Index", "BaiViet");
        }
    }
}