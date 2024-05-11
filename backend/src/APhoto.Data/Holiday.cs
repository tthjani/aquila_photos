using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Holiday
{
    public uint HolidayId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [MaxLength(250)]
    public string? Comment { get; set; }
    public bool AllowOrders { get; set; }
}