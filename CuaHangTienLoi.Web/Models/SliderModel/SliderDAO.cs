using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangTienLoi.Web.Models.SliderModel
{
    public class SliderDAO
    {
        public static List<Slider> getAllSlide()
        {
            List<Slider> Slides = (from sl in DBModels.Instance.Sliders select sl).ToList();
            if (Slides.Any())
                return Slides;
            return null;
        }

        public static Slider getByIdSlide(int id)
        {
            Slider slides = (from sl in DBModels.Instance.Sliders where sl.MaSider == id select sl).FirstOrDefault();
            return slides;
        }
        public static bool addSlide(Slider slide)
        {
            DBModels.Instance.Sliders.Add(slide);
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool saveSlide(Slider slide)
        {
            Slider tmp = SliderDAO.getByIdSlide(slide.MaSider);
            tmp.TieuDe = slide.TieuDe;
            tmp.HinhAnh = slide.HinhAnh;
            tmp.NgayDang = slide.NgayDang;
            tmp.ThuTu = slide.ThuTu;
            tmp.LienKet = slide.LienKet;
            int result = DBModels.Instance.SaveChanges();
            return result == 1 ? true : false;
        }

        public static bool removeAllSlide(Slider slide)
        {
            DBModels.Instance.Sliders.Remove(slide);
            int resul = DBModels.Instance.SaveChanges();
            return resul == 1 ? true : false;
        }

        public static bool removeSlide(int id)
        {
            Slider rm = SliderDAO.getByIdSlide(id);
            if (removeAllSlide(rm))
                return true;
            return false;
        }
    }
}