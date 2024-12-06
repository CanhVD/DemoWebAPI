using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Note { get; set; }
}
