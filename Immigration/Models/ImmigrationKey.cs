using System;
using System.Collections.Generic;

namespace Immigration.Models;

public partial class ImmigrationKey
{
    public int Id { get; set; }

    public int? PersonKey { get; set; }

    public int? OccupationKey { get; set; }

    public int? VesselKey { get; set; }

    public int? OriginCountryKey { get; set; }

    public int? OriginCityKey { get; set; }

    public int? SettlementStateKey { get; set; }

    public int? SettlementCityKey { get; set; }
}
