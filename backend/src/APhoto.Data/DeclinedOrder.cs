using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class DeclinedOrder
{
    public uint Id { get; set; }
    public uint OrderId { get; set; }
    public DateTime DecDate { get; set; }
    [MaxLength(250)]
    public string Reason { get; set; }
}