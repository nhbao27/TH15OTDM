using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using TH15OTDM.Models;

namespace TH15OTDM.Controllers
{
    public class BaiThiController : Controller
    {
        private readonly QltaiSanContext db;

        public BaiThiController(QltaiSanContext db)
        {
            this.db = db;
        }
        private List<TaiSan> taiSans;

        public IActionResult Index()
        {
            taiSans = db.TaiSans.Where(x => x.NguyenGia >= 20).ToList();
            return View(taiSans);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TenLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai");
            return View(taiSans);
        }
        [HttpPost]
        public IActionResult Create(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                db.TaiSans.Add(taiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSans);
        }
        [HttpGet]
        public IActionResult FilterByCategory(int maloai)
        {
            var dsHang = db.TaiSans.AsQueryable();
            if (maloai > 0)
            {
                dsHang = dsHang.Where(h => h.MaLoai == maloai);
            }
            return PartialView("PartialList", dsHang.ToList());
        }
        [HttpGet]
       public IActionResult Edit(int mats)
        {
            var taiSan = db.TaiSans.Find(mats);
            if(taiSan == null)
            {
                return NotFound();
            }
            ViewBag.TenLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }
        public IActionResult Edit(TaiSan taisan)
        {
            if (ModelState.IsValid)
            {
                db.TaiSans.Update(taisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai", taisan.MaLoai);
            return View(taisan);
        }
    }
}
