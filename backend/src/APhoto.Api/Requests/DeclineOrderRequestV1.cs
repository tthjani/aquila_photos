namespace APhoto.Api.Requests
{
    public record DeclineOrderRequestV1
    {
        public required uint OrderId { get; set; }

        public required string Reason { get; set; }
    }
}
