namespace APhoto.Data;

public class DeclinedOrder
{
    public uint Id { get; set; }
    public uint OrderId { get; set; }
    public DateTime DecDate { get; set; }
    public string Reason { get; set; }
}