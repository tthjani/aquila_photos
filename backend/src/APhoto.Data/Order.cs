using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Order
{
    public uint OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    [MaxLength(50)]
    public string OrderType { get; set; }
    [MaxLength(50)]
    public string ClientName { get; set; }
    [MaxLength(50)]
    public string ContactInformation { get; set; }
    [MaxLength(250)]
    public string FbUrl { get; set; }
    [MaxLength(250)]
    public string Message { get; set; }
    [MaxLength(25)]
    public string OrderStatus { get; set; }
    public DateTime LastModifiedAt { get; set; }
    [MaxLength(250)]
    public string? RefusalReason { get; set; }
}