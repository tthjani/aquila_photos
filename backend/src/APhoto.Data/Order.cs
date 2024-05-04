namespace APhoto.Data;

public class Order
{
    public uint Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string FbUrl { get; set; }
    public string Message { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsDeclined { get; set; }
}