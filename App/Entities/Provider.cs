using System;

namespace App.Entities;

public class Provider
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Game>? Games { get; set; }
}
