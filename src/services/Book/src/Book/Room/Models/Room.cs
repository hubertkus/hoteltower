
namespace Room.Models;

public class Room
{
 public Guid Id { get; init; } = Guid.NewGuid();
 public string ShortName { get; private set; } = string.Empty;
 public string Name { get; private set; } = string.Empty;
 public bool Reserved { get; set; } = false;

 public Room(string shortname, string name)
 {
  ShortName = shortname;
  Name = name;
 }
}