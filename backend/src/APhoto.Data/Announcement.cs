using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Announcement
{
    public uint Id { get; set; }
    [MaxLength(1000)]
    public string Message { get; set; }
    [MaxLength(100)]
    public string ImageUrl { get; set; }
}