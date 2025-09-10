using System;
using System.Collections.Generic;

namespace GetImmigration.Models;

public partial class GlobalCity
{
    public int Id { get; set; }

    public string CountryCode { get; set; }

    public string CityAbbrCode { get; set; }

    public string City { get; set; }

    public string LongLatCode { get; set; }
}
