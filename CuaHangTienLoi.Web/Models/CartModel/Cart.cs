using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CuaHangTienLoi.Web.Models
{
    public class CartItem
    {
        //id giỏ hàng
        public int MaGioHang { get; set; }
        //tên sản phẩm
        public string TenSanPham { get; set; }
        //kích thước
        //ảnh sản phẩm
        public string AnhSanPham { get; set; }
        //giá tiền
        public decimal DonGia { get; set; }
        //số lượng
        public int SoLuong { get; set; }
        //thành tiền
        public decimal TongDon { get; set; }
        //sale off
        public int PhanTramGiamGia { get; set; }


    }

    public class Cart
    {
        public Cart()
        {
            ListItem = new List<CartItem>();
        }

        public List<CartItem> ListItem { get; set; }

        public bool AddToCart(CartItem item)
        {
            bool alreadyExists = ListItem.Any(x => x.MaGioHang == item.MaGioHang);
            if (alreadyExists)
            {
                CartItem existsItem = ListItem.Where(x => x.MaGioHang == item.MaGioHang).SingleOrDefault();
                if (existsItem != null)
                {
                    existsItem.SoLuong = existsItem.SoLuong + 1;
                    existsItem.TongDon = existsItem.SoLuong * existsItem.DonGia;
                }
            }
            else
            {
                ListItem.Add(item);
            }
            return true;
        }

        public bool RemoveFromCart(long lngProductSellID)
        {
            CartItem existsItem = ListItem.Where(x => x.MaGioHang == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                ListItem.Remove(existsItem);
            }
            return true;
        }

        public bool UpdateQuantity(long lngProductSellID, int intQuantity)
        {
            CartItem existsItem = ListItem.Where(x => x.MaGioHang == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                existsItem.SoLuong = intQuantity;
                existsItem.TongDon = existsItem.SoLuong * existsItem.DonGia;
            }
            return true;
        }

        public decimal GetTotal()
        {
            return ListItem.Sum(x => x.TongDon);
        }

        public decimal GetTotalQuantity()
        {
            return ListItem.Sum(x => x.SoLuong);
        }

        public bool EmptyCart()
        {
            ListItem.Clear();
            return true;
        }

    }
}