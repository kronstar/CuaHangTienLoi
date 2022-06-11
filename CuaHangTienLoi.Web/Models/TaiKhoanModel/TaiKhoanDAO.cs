using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.TaiKhoanModel
{
    public class TaiKhoanDAO
    {

        /// <summary>
        /// Lấy tất cả danh sách user
        /// </summary>
        /// Đầu vào không có
        /// <returns>danh sách user</returns>
        public static List<TaiKhoan> getAllUser()
        {
            List<TaiKhoan> users = (from us in DBModels.Instance.TaiKhoans where us.DaXoa == false select us).ToList();
            if (users.Any())
                return users;
            return null;
        }
        /// <summary>
        /// lấy user theo iduser
        /// </summary>
        /// <param name="id">Đầu vào id</param>
        /// <returns>một user</returns>
        public static TaiKhoan getUserById(int id)
        {
            TaiKhoan user =
                (from us in DBModels.Instance.TaiKhoans where us.MaTaiKhoan == id && us.DaXoa == false select us)
                    .FirstOrDefault();
            return user;
        }

        /// <summary>
        /// lấy danh sách user từ tên đăng nhập và mật khẩu
        /// </summary>
        /// <param name="tendangnhap">ten dang nhap</param>
        /// <param name="matkhau">matkhau</param>
        /// <returns>danh sach user</returns>
        public static TaiKhoan getUserByTenDangNhapAndMatKhau(string tendangnhap, string matkhau)
        {
            TaiKhoan users = (from us in DBModels.Instance.TaiKhoans
                              where us.TenDangNhap == tendangnhap && us.MatKhau == matkhau && us.DaXoa == false
                              select us).FirstOrDefault();
            if (users != null)
                return users;
            return null;
        }

        public static bool saveKhachHang(TaiKhoan user)
        {
            TaiKhoan tmp = TaiKhoanDAO.getUserById(user.MaTaiKhoan);
            tmp.HoTen = user.HoTen;
            tmp.NgaySinh = user.NgaySinh;
            tmp.GioiTinh = user.GioiTinh;
            tmp.DiaChi = user.DiaChi;
            tmp.SoDienThoai = user.SoDienThoai;
            tmp.Email = user.Email;
            tmp.TenDangNhap = user.TenDangNhap;
            tmp.MatKhau = user.MatKhau;
            tmp.PhanQuyen = user.PhanQuyen;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;

        }

        public static bool Remove(TaiKhoan user)
        {
            DBModels.Instance.TaiKhoans.Remove(user);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeUserKhachHang(int id)
        {
            TaiKhoan rm = TaiKhoanDAO.getUserById(id);
            if (Remove(rm))
                return true;
            return false;

        }

        public static bool addKhachHang(TaiKhoan taikhoan)
        {
            DBModels.Instance.TaiKhoans.Add(taikhoan);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }


        public static TaiKhoan getUserByTenDangNhapAndMatKhauAdmin(string tendangnhap, string matkhau)
        {
            TaiKhoan users = (from us in DBModels.Instance.TaiKhoans
                              where us.TenDangNhap == tendangnhap && us.MatKhau == matkhau && us.PhanQuyen == true && us.DaXoa == false
                                   select us).FirstOrDefault();
            if (users != null)
                return users;
            return null;
        }

        public static TaiKhoan getUserIdTenDangNhap(string tendangnhap)
        {
            TaiKhoan user = (from us in DBModels.Instance.TaiKhoans
                             where us.TenDangNhap == tendangnhap
                                  select us).FirstOrDefault();
            if (user != null)
                return user;
            return null;
        }
    }
}