using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class Order
{
    public uint Id { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    [MaxLength (50)]
    public string ClientName { get; set; }
    [MaxLength(50)]
    public string ClientEmail { get; set; }
    [MaxLength(100)]
    public string FbUrl { get; set; }
    [MaxLength(250)]
    public string Message { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsDeclined { get; set; }
}