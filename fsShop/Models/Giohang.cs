using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using fsShop.Models;

namespace fsShop.Models
{
    public class Giohang
    {
        fsShopDataContext data = new fsShopDataContext();
        public int Id { get; set; }
        public string TenSP { get; set; }
        public string AnhBia { get; set; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        public Giohang(int MaSP)
        {
            Id = MaSP;
            SanPham sach = data.SanPhams.Single(n => n.MaSanPham == Id);
            TenSP = sach.TenSanPham;
            AnhBia = sach.VideoSanPham;
            dDongia = double.Parse(sach.Gia.ToString());
            iSoluong = 1;
        }
    }
}