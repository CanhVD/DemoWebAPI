using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class Display
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Note { get; set; }
}
