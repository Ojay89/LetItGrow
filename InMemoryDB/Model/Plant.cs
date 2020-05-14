    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryDB.Model
{
    public class Plant
    {

        public Plant(int id, string plantAPIid)
        {
            Id = id;
            PlantAPIid = plantAPIid;
        }

        public int Id { get; set; }
        public string PlantAPIid { get; set; }
    }
}