using System;

namespace HairSalon.Models
{
  public class Client
  {
    public Client()
    {
      ClientId = Guid.NewGuid().ToString();
    }
    public string ClientId { get; set; }
    public string Name { get; set; }
    public string StylistId { get; set; }
    public virtual Stylist Stylist { get; set; }
  }
}