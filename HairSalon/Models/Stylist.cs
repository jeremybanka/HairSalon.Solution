using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      StylistId = Guid.NewGuid().ToString();
      Clients = new HashSet<Client>();
    }
    public virtual ICollection<Client> Clients { get; set; }
    public string StylistId { get; set; }
    public string Name { get; set; }
  }
}