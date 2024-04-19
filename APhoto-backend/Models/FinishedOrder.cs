namespace APhoto_backend.Models;

public class FinishedOrder
{
    public uint Id { get; set; }
    public uint AcceptedId { get; set; }
    public DateTime FinishDate { get; set; }
}