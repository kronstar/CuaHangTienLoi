using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.TinTucModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            List<TinTuc> tintucs = new List<TinTuc>();
            tintucs = TinTucDAO.getAllTinTuc();
            return View(tintucs);
        }
    }
}