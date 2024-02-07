using ShareHere.Repository.Interfaces;
using static ShareHere.Database.Models.Enums;

namespace ShareHere.Repository.ObserverClasses
{
    public class ObserverClass
    {
        public string? Name { get; set; } 
        public string NotifyObsevers(BlogTypes blogType)
        {
            return $"Hey {this.Name} a {blogType} blog has been created";
        }
    }
}
