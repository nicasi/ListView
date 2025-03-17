using System.Collections.Generic;
using DataGrid_SqLite;

namespace ListView;

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
