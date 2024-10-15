using System;

namespace App.Entities;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Theme { get; set; }
}
