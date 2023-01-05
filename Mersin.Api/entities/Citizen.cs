using System;
using System.Collections.Generic;

namespace Mersin.Api.entities;

public partial class Citizen
{
    public long Uid { get; set; }

    public string NationalIdentifier { get; set; } = null!;

    public string First { get; set; } = null!;

    public string Last { get; set; } = null!;

    public string MotherFirst { get; set; } = null!;

    public string FatherFirst { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string BirthCity { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string IdRegistrationCity { get; set; } = null!;

    public string IdRegistrationDistrict { get; set; } = null!;

    public string AddressCity { get; set; } = null!;

    public string AddressDistrict { get; set; } = null!;

    public string AddressNeighborhood { get; set; } = null!;

    public string StreetAddress { get; set; } = null!;

    public string DoorOrEntranceNumber { get; set; } = null!;

    public string Misc { get; set; } = null!;
}
