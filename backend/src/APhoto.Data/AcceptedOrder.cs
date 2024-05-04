namespace APhoto.Data;

public class AcceptedOrder
{
    public uint Id { get; set; }
    public uint OrderId { get; set; }
    public DateTime AcceptanceDate { get; set; }
    public bool IsFinished { get; set; }
}