using CuaHangTienLoi.Web.Models;
using CuaHangTienLoi.Web.Models.ChiTietHoaDonModel;
using CuaHangTienLoi.Web.Models.HoaDonModel;
using CuaHangTienLoi.Web.Models.SanPhamModel;
using CuaHangTienLoi.Web.Models.TaiKhoanModel;
using CuaHangTienLoi.Web.Models.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web;
using Newtonsoft.Json.Linq;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace CuaHangTienLoi.Controllers
{
    public class ThanhToanController : Controller
    {
        public int tong;

        //
        // GET: /ThanhToan/
        public ActionResult Index()
        {
            if (Session["nguoidung"] != null)
            {
                CartModel model = new CartModel();
                model.Cart = (Cart)Session["Cart"];

                return View(model);
            }
            else
            {
                return RedirectToAction("index", "DangNhap");
            }
        }
 
        public ActionResult DonDatHang()
        {
            try
            {
                if (Session["NguoiDung"] != null)
                {
                    if (Request["thanhtoan"] != null)
                    {
                        HoaDon hd = new HoaDon();
                        string tendn = Session["nguoidung"].ToString();
                        int iduser = TaiKhoanDAO.getUserIdTenDangNhap(Session["NguoiDung"].ToString()).MaTaiKhoan;
                        hd.MaTaiKhoan = iduser;
                        hd.HoTenNguoiMua = Request["hoten"];
                        hd.DiaChi = Request["diachi"];
                        hd.DienThoai = Request["sodienthoai"];
                        hd.NgayDat = DateTime.Now;
                        hd.TinhTrangDonHang = 1;
                        hd.GhiChu = Request["ghichu"];
                        //hd.GiaTien = 0;
                        HoaDonDAO.addHoaDon(hd);

                        int idlast = HoaDonDAO.getAllHoaDon().LastOrDefault().MaHoaDon;
                        CartModel model = new CartModel();
                        model.Cart = (Cart)Session["Cart"];
                        if (model.Cart != null)
                        {
                            foreach (var item in model.Cart.ListItem)
                            {
                                ChiTietHoaDon tmp = new ChiTietHoaDon();
                                tmp.MaHoaDon = idlast;
                                tmp.MaSanPham = item.MaGioHang;
                                tmp.SoLuong = item.SoLuong;
                                tmp.DonGia = Convert.ToInt32(item.DonGia);
                                tmp.ThanhTien = tmp.SoLuong * tmp.DonGia;
                                tong += tmp.ThanhTien;
                                ChiTietHoaDonDAO.addCTHoaDon(tmp);

                            }

                            HoaDon hdtmp = HoaDonDAO.getByIdHoaDon(idlast);
                            hd.TongHoaDon = tong;
                            HoaDonDAO.saveHoaDon(hdtmp);
                        }
                        Session["Cart"] = null;

                    }

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
            return View();
        }

        public ActionResult Payment()
        {
            HoaDon hd = new HoaDon();
            string tendn = Session["nguoidung"].ToString();
            int iduser = TaiKhoanDAO.getUserIdTenDangNhap(Session["NguoiDung"].ToString()).MaTaiKhoan;

            try
            {
                if (Session["NguoiDung"] != null)
                {
                    if (Request["thanhtoan"] != null)
                    {
                        hd.MaTaiKhoan = iduser;
                        hd.HoTenNguoiMua = Request["hoten"];
                        hd.DiaChi = Request["diachi"];
                        hd.DienThoai = Request["sodienthoai"];
                        hd.NgayDat = DateTime.Now;
                        hd.TrangThai = 2;
                        hd.GhiChu = Request["ghichu"];
                        hd.Email = Request["email"];
                        hd.TinhTrangDonHang = 1;
                        //hd.GiaTien = 0;
                        HoaDonDAO.addHoaDon(hd);

                        int idlast = HoaDonDAO.getAllHoaDon().LastOrDefault().MaHoaDon;
                        CartModel model = new CartModel();
                        model.Cart = (Cart)Session["Cart"];

                        if (model.Cart != null)
                        {
                            foreach (var item in model.Cart.ListItem)
                            {
                                ChiTietHoaDon tmp = new ChiTietHoaDon();
                                tmp.MaHoaDon = idlast;
                                tmp.MaSanPham = item.MaGioHang;
                                tmp.SoLuong = item.SoLuong;
                                tmp.DonGia = Convert.ToInt32(item.DonGia);
                                tmp.ThanhTien = tmp.SoLuong * tmp.DonGia;
                                tong += tmp.ThanhTien;
                                ChiTietHoaDonDAO.addCTHoaDon(tmp);

                            }

                            HoaDon hdtmp = HoaDonDAO.getByIdHoaDon(idlast);
                            hd.TongHoaDon = tong;
                            HoaDonDAO.saveHoaDon(hdtmp);
                        }
                        Session["Cart"] = null;

                    }

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOITOC20220610";
            string accessKey = "DUojk4uwcHOc1aHF";
            string serectkey = "rQtO6EWW5oYideV4dtDF71nApr2YzZwb";
            string orderInfo = "Thanh toán hoá đơn";
            string returnUrl = "https://localhost:44399/ThanhToan/ReturnUrl";
            string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = tong.ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        
        public ActionResult ReturnUrl()
        {
            /*string param = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature"));
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            string serectkey = "rQtO6EWW5oYideV4dtDF71nApr2YzZwb";
            string signature = crypto.signSHA256(param, serectkey);

            if (signature != Request["signature"].ToString())
            {
                ViewBag.message = "Thông tin Request không hợp lệ!";
                return View();
            }*/

            if (Request.QueryString["errorCode"].Equals("0"))
            {
                ViewBag.message = "0";

                int idlast = HoaDonDAO.getAllHoaDon().LastOrDefault().MaHoaDon;
                HoaDon hdtmp = HoaDonDAO.getByIdHoaDon(idlast);
                hdtmp.TrangThai = 1;
                HoaDonDAO.saveHoaDon(hdtmp);
            }
            else
            {
                ViewBag.message = null;
            }

            return View();
        }

    }
}
