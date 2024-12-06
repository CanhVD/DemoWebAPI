using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class RoleDisplay
{
    public int RoleId { get; set; }

    public int DisplayId { get; set; }

    public string? Note { get; set; }
}
