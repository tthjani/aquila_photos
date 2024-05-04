namespace APhoto.Api.Models;

public class FinishedOrder
{
    public uint Id { get; set; }
    public uint orderId { get; set; }
    public uint AcceptedId { get; set; }
    public DateTime FinishDate { get; set; }
}