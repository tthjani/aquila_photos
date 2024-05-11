namespace APhoto.Infrastructure.Utility
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Sets the time on a DateTime object to 0:00:00.000000
        /// </summary>
        /// <param name="dateTime">The DateTime object</param>
        /// <returns>A new DateTime object with the same date as the input object, but with time of 0:00:00.000000</returns>
        public static DateTime ClearTime(this DateTime dateTime)
        {
            return dateTime
                .AddHours(-dateTime.Hour)
                .AddMinutes(-dateTime.Minute)
                .AddSeconds(-dateTime.Second)
                .AddMilliseconds(-dateTime.Millisecond)
                .AddMicroseconds(-dateTime.Microsecond);
        }
    }
}
