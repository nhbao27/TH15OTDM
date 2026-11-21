using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TH15OTDM.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    public string TenTs { get; set; } = null!;
    [Range(1,2000, ErrorMessage ="Gia phai tu 1 den 2000")]
    public decimal? NguyenGia { get; set; }
    [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$", ErrorMessage ="Nhap dung dinh dang png, jpg,webp, jpeg")]

    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; } = null!;
}
