using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.NhanVienModel
{
    public class NhanVienDAO
    {
        public static List<NhanVien> getAllNhanVien()
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens select sp).ToList();
            if (nhanviens.Any())
                return nhanviens;
            return null;
        }
        public static int countNhanVien()
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens select sp).ToList();
            int tong = nhanviens.Select(x => x.MaNhanVien).Count();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static int tinhTongLuong()
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens select sp).ToList();
            int tong = nhanviens.Select(x => x.Luong).Sum();
            if (tong == 0)
            {
                return 0;
            }
            return tong;
        }
        public static List<NhanVien> getAllShipper()
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens where sp.MaChucVu == 1 select sp).ToList();
            if (nhanviens.Any())
                return nhanviens;
            return null;
        }
        public static List<NhanVien> getAllNhanVienById(int id)
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens where sp.MaNhanVien == id select sp).ToList();
            return nhanviens;
        }

        public static List<NhanVien> getAllNhanVienByIdDChucVu(int id)
        {
            List<NhanVien> nhanviens = (from sp in DBModels.Instance.NhanViens where sp.MaChucVu == id select sp).ToList();
            return nhanviens;
        }

        public static NhanVien getNhanVienByID(int id)
        {
            NhanVien nhanviens = (from sp in DBModels.Instance.NhanViens where sp.MaNhanVien == id select sp).FirstOrDefault();
            return nhanviens;
        }

        public static List<NhanVien> searchByName(string name)
        {
            bool existUnicodeCharacter = name.Any(c => c > 255);
            List<NhanVien> result;
            if (!existUnicodeCharacter)
                result = (from sp in DBModels.Instance.Set<NhanVien>().AsEnumerable() where Core.convertToUnsign(sp.HoTen).ToLower().Contains(name.ToLower()) select sp).ToList();
            else
                result = (from sp in DBModels.Instance.Set<NhanVien>().AsEnumerable()
                          where sp.HoTen.ToLower().Contains(name.ToLower())
                          select sp).ToList();
            return result;
        }

        public static bool remove(NhanVien nhanvien)
        {
            DBModels.Instance.NhanViens.Remove(nhanvien);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeNhanVien(int id)
        {
            NhanVien rm = NhanVienDAO.getNhanVienByID(id);
            if (remove(rm))
                return true;
            return false;
        }

        public static bool addNhanVien(NhanVien nhanvien)
        {
            DBModels.Instance.NhanViens.Add(nhanvien);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool saveNhanVien(NhanVien nhanvien)
        {
            NhanVien tmp = NhanVienDAO.getNhanVienByID(nhanvien.MaNhanVien);
            tmp.MaChucVu = nhanvien.MaChucVu;
            tmp.HoTen = nhanvien.HoTen;
            tmp.SoDienThoai = nhanvien.SoDienThoai;
            tmp.DiaChi = nhanvien.DiaChi;
            tmp.NgaySinh = nhanvien.NgaySinh;
            tmp.GioiTinh = nhanvien.GioiTinh;
            tmp.NgayThamGia = nhanvien.NgayThamGia;
            tmp.Luong = nhanvien.Luong;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }
    }
}