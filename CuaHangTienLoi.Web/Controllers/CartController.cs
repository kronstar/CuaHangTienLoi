using CuaHangTienLoi.Web.Models;
using CuaHangTienLoi.Web.Models.CartModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CuaHangTienLoi.Web.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            CartModel model = new CartModel();
            model.Cart = (Cart)Session["Cart"];
            return View(model);
        }

        /// <summary>
        /// Them san pham vao gio hang
        /// </summary>
        /// <param name="id">ID san pham can them</param>
        /// <returns>Tra ve json theo dinh dang {Code: ReturnCode, Msg: "Return message"}</returns>

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            var response = new { code = 1, Msg = "Fail" };
            //SanPham objSanpham = GetProductById(id);
            SanPham objSanpham = SanPhamDAO.getSanPhamByID(id);
            if (objSanpham != null)
            {
                Cart objCart = (Cart)Session["Cart"];
                if (objCart == null)
                {
                    objCart = new Cart();
                }

                CartItem item = new CartItem();
                item.MaGioHang = objSanpham.MaSanPham;
                item.TenSanPham = objSanpham.TenSanPham;
                item.AnhSanPham = objSanpham.LinkAnh;
                item.DonGia = objSanpham.DonGia;
                item.PhanTramGiamGia = Convert.ToInt32(objSanpham.PhanTramGiamGia);
                item.SoLuong = 1;
                item.TongDon = objSanpham.DonGia * item.SoLuong;
                objCart.AddToCart(item);
                Session["Cart"] = objCart;
                response = new { code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        /// <summary>
        /// Xoa san pham khoi gio hang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            var response = new { Code = 1, Msg = "Fail" };
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.RemoveFromCart(id);
                Session["Cart"] = objCart;
                response = new { Code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        /// <summary>
        /// Cap nhat so luong san pham can mua trong gio hang
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateQuantity(int id, int quantity)
        {
            var response = new { Code = 1, Msg = "Fail" };
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.UpdateQuantity(id, quantity);
                Session["Cart"] = objCart;
                response = new { Code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        public JsonResult EmptyShoppingCart()
        {
            var response = new { Code = 1, Msg = "Fail" };
            Session["Cart"] = null;
            response = new { Code = 0, Msg = "Success" };
            return Json(response);
        }


        /// <summary>
        /// Gia lap method lay thong tin san pham tu DB dua vao ID san pham
        /// </summary>
        /// <param name="id">ID san pham can lay thong tin</param>
        /// <returns></returns>

        //public SanPham GetProductById(int id)
        //{
        //    return new SanPham()
        //    {

        //        IdSanPham = id,
        //        TenSanPham = String.Format("Product {0}", id),
        //        LinkHinh= String.Format("/Images/imgweb{0}.png", id),
        //        DonGia = 10000 * id
        //    };
        //}

    }
}
