namespace APhoto.Api.Requests
{
    public record FinishOrderRequestV1
    {
        public required uint AcceptedOrderId { get; set; }
    }
}
