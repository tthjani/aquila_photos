﻿namespace APhoto.Data;

public class FinishedOrder
{
    public uint Id { get; set; }
    public uint OrderId { get; set; }
    public uint AcceptedId { get; set; }
    public DateTime FinishDate { get; set; }
}