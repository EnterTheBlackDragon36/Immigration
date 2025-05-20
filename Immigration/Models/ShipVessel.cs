using System;
using System.Collections.Generic;

namespace Immigration.Models;

public partial class ShipVessel
{
    public int Id { get; set; }

    public string? Vessel { get; set; }

    public int? YearBuilt { get; set; }

    public string? Line { get; set; }

    public string? BuilderAndLocation { get; set; }

    public string? Dimensions { get; set; }

    public string? Equipment { get; set; }

    public string? MastsAndFunnels { get; set; }

    public string? Passengers { get; set; }

    public string? Routes { get; set; }

    public string? History { get; set; }
}
