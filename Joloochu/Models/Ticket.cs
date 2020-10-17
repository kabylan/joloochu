using Microsoft.AspNetCore.Routing;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Joloochu
{
    public class Ticket
    {

        public int id { get; set; }

        public string carMark { get; set; }
        public string model { get; set; }
        public string price { get; set; }

        public int FromId { get; set; }
        public Point From { get; set; }

        public int ToId { get; set; }
        public Point To { get; set; }

        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string carNumber { get; set; }
        public DateTime date { get; set; }
        public string placeMax { get; set; }
        public string placeNow { get; set; }
        public string suppliments { get; set; }
    }

    public class Point
    {

        public int Id { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? VillageId { get; set; }
        public Village Village { get; set; }

    }
}
