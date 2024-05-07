namespace APhoto.Api.Requests
{
    public class UpdateHolidayRequestV1
    {
        public uint HolidayId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Comment { get; set; }

        public bool AllowOrders { get; set; } = false;
    }
}
