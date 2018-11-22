using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Company
    {
        [Key]
        public string Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool MapChoice { get; set; }
        public bool TwitterChoice { get; set; }
        public bool ScheduleChoice { get; set; }
        public bool ContactChoice { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Twitter { get; set; }
        public string Theme { get; set; }
        public string Type { get; set; }
        public bool About { get; set; }
        public bool Contact { get; set; }
        public bool Scheduler { get; set; }
        public bool HomeSetupComplete { get; set; }
        public bool ContactSetupComplete { get; set; }
        public bool AboutSetupComplete { get; set; }
        public bool SetupComplete { get; set; }

        public string key = ApiKeys.GKey;
        public string srcKey = "https://maps.googleapis.com/maps/api/js?libraries=places&key=" + ApiKeys.GKey + "&callback=initMap";

        public static dynamic GetLatandLong(Company comp)
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + comp.Street.Replace(" ", "+") + comp.City.Replace(" ", "+") + ",+" + comp.State + ",+&key=" + ApiKeys.GeoKey;
            var result = new System.Net.WebClient().DownloadString(url);
            var items = JsonConvert.DeserializeObject<dynamic>(result);
            return items.results[0].geometry.location;
        }

        //public dynamic GetLatandLong(Company comp)
        //{
        //    string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + comp.Zip + ",+&key=" + ApiKeys.GeoKey;
        //    var result = new System.Net.WebClient().DownloadString(url);
        //    var items = JsonConvert.DeserializeObject<dynamic>(result);
        //    return items.results[0].geometry.location;
        //}
    }
}
