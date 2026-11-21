using Microsoft.AspNetCore.Mvc;
using TH15OTDM.Models;

namespace TH15OTDM.ViewComponents
{
    public class MenuHeaderViewComponent:ViewComponent
    {
        private readonly QltaiSanContext db;
        private List<LoaiTaiSan>loaiTaiSans;

        public MenuHeaderViewComponent(QltaiSanContext db)
        {
            loaiTaiSans=db.LoaiTaiSans.ToList();
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Menu", loaiTaiSans);
        }
    }
}
