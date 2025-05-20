using System;
using System.Collections.Generic;

namespace Immigration.Models;

public partial class Travel
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? CountryId { get; set; }

    public string? City { get; set; }

    public string? CountryCode { get; set; }

    public string? CityAbbrCode { get; set; }

    public string? Country { get; set; }

    public DateTime? Departure { get; set; }

    public DateTime? Arrival { get; set; }

    public string? Profession { get; set; }

    public string? Vessel { get; set; }

    public decimal? AmountOfMoney { get; set; }

    public string? Relatives { get; set; }
}
