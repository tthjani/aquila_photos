using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Gallery
{
    public uint Id { get; set; }
    [MaxLength(100)]
    public string Url { get; set; }
}