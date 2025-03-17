using System;
using System.Collections.Generic;
using ListView;

namespace DataGrid_SqLite;

public partial class Track
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? Length { get; set; }

    public long? ArtistId { get; set; }
    
    public virtual Artist? Artist { get; set; }

    public Track() { }

    public Track(string? name, long? length, Artist? artist)
    {
        Name = name;
        Length = length;
        Artist = artist;
    }
}
