using System;
using System.Collections.Generic;

namespace GetImmigration.Models;

public partial class GlobalCountry
{
    public int Id { get; set; }

    public string CountryCode { get; set; }

    public string Country { get; set; }
}
