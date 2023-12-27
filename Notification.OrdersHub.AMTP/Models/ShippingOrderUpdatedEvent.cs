﻿namespace Notification.OrdersHub.API.Models;

public class ShippingOrderUpdatedEvent
{
	public string? TrackingCode { get; set; }
	public string? ContactEmail { get; set; }
	public string? Description { get; set; }
}