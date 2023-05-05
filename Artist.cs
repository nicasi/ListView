using System;
using System.Collections.Generic;

namespace DataGrid_SqLite;

public partial class Artist
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; } = new List<Track>();

    public override string ToString()
    {
        return Name;
    }
}
