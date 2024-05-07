using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Holiday
{
    public uint HolidayId { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    [MaxLength(250)]
    public string? Comment { get; set; }
    public bool AllowOrders { get; set; }
}