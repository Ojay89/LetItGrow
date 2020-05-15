    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryDB.Model
{
    public class Plant
    {


        public Plant(int userId, string plantAPIid)
        {
            UserId = userId;
            PlantAPIid = plantAPIid;
           
        }




        public int UserId { get; set; }

        public User user { get; set; }

        [Key]
        public int Id { get; set; }

        public string PlantAPIid { get; set; }

    }
}