using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Entities
{
    public class BusStations
    {
        [Key]
        public int StationId { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
