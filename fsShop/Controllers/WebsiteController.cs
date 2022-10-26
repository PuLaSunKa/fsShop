using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fsShop.Models;
using PagedList;

namespace fsShop.Controllers
{
    public class WebsiteController : Controller
    {
        fsShopDataContext data = new fsShopDataContext();
        // GET: Website
        private List<SanPham> LaySPMoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.SanPhams.OrderByDescending(a => a.NgayTao).Take(count).ToList();
        }
        //int ? page nghĩa là tham số null hoặc tham số là số nguyên
        public ActionResult Index(int? page)
        {
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = LaySPMoi(15);
            //Số mẫu tin trên 1 trang
            int pagesize = 4;
            //Thứ tự trang truy xuất
            int pageNum = (page ?? 1);
            return View(sachmoi.ToPagedList(pageNum, pagesize));
        }
        public ActionResult TheLoai()
        {
            var tl = from cd in data.TheLoais select cd;
            return PartialView(tl);
        }

        public ActionResult NhanHang()
        {
            var nh = from nxb in data.NhanHangs select nxb;
            return PartialView(nh);
        }
        public ActionResult SPtheoTheLoai(int id)
        {
            var sach = from s in data.SanPhams where s.MaTheLoai == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNhanHang(int id)
        {
            var sach = from s in data.SanPhams where s.MaNhanHang == id select s;
            return View(sach);
        }

        public ActionResult ChitietSP(int id)
        {
            var sach = from s in data.SanPhams
                       where s.MaSanPham == id
                       select s;
            return View(sach.Single());
        }
        private List<BaiDang> LayBaiVietMoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.BaiDangs.OrderByDescending(a => a.NgayTao).Take(count).ToList();
        }
        //int ? page nghĩa là tham số null hoặc tham số là số nguyên
        public ActionResult BaiViet(int? page)
        {
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = LayBaiVietMoi(15);
            //Số mẫu tin trên 1 trang
            int pagesize = 4;
            //Thứ tự trang truy xuất
            int pageNum = (page ?? 1);
            return View(sachmoi.ToPagedList(pageNum, pagesize));
        }
    }
}