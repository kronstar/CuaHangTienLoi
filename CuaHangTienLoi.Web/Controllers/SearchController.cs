using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangTienLoi.Web.Models.SanPhamModel;

namespace CuaHangTienLoi.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: TimKiem
        public ActionResult Index()
        {
            List<SanPham> sanphams = new List<SanPham>();
            if (Request.Params["tim"] != null)
            {
                sanphams = SanPhamDAO.searchByName(Request.Params["tim"]);
            }

            return View(sanphams);
        }
    }
}