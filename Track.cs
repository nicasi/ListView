using System;
using System.Collections.Generic;

namespace DataGrid_SqLite;

public partial class Track
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? Length { get; set; }

    public long? ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }
}
