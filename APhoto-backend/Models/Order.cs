namespace APhoto_backend.Models;

public class Order
{
    public uint Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string FbUrl { get; set; }
    public string Message { get; set; }
    public bool IsAccepted { get; } = false;
    public bool IsDeclined { get; } = false;
}