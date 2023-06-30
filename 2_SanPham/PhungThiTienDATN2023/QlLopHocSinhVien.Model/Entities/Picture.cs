using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class Picture
{
    public string PictureName { get; set; } = null!;

    public string? PicFileName { get; set; }

    public byte[]? PictureData { get; set; }
}
