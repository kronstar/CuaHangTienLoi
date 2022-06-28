using CuaHangTienLoi.Web.Models.ChucVuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangTienLoi.Web.Controllers
{
    public class QuanTriChucVuController : Controller
    {
        // GET: ChucVu
        public ActionResult Index()
        {
            if (Session["nguoidung"] != null)
            {
                List<ChucVu> chucvus = new List<ChucVu>();

                chucvus = ChucVuDAO.getAllChucVu();

                return View(chucvus);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditChucVu()
        {
            if (Session["nguoidung"] != null)
            {
                ChucVu cd = new ChucVu();

                if (Request["saveclose"] != null)
                {
                    ChucVu tmp = new ChucVu();
                    tmp.MaChucVu = int.Parse(Request["machucvu"]);
                    tmp.TenChucVu = Request["tenchucvu"];

                    ChucVuDAO.saveChucVu(tmp);
                    return RedirectToAction("Index", "QuanTriChucVu");
                }
                else if (Request["cancel"] != null)
                {
                    return RedirectToAction("Index", "QuanTriChucVu");
                }
                else
                {
                    cd = ChucVuDAO.getChucVuByID(int.Parse(Request.Params["t"]));
                }
                return View(cd);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public ActionResult CreateChucVu()
        {
            if (Session["nguoidung"] != null)
            {
                if (Request["save"] != null)
                {
                    ChucVu cd = new ChucVu();
                    cd.TenChucVu = Request["tenchucvu"];

                    ChucVuDAO.addChucVu(cd);
                }
                else if (Request["saveclose"] != null)
                {
                    ChucVu cd = new ChucVu();
                    cd.TenChucVu = Request["tenchucvu"];

                    ChucVuDAO.addChucVu(cd);
                    Response.Redirect("Index");
                }
                else if (Request["cancel"] != null)
                {
                    Response.Redirect("Index");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public ActionResult DeleteChucVu()
        {
            ChucVuDAO.removeChucVu(int.Parse(Request.Params["t"]));
            return RedirectToAction("Index", "QuanTriChucVu");
        }
    }
}