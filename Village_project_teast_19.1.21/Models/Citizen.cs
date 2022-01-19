using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Village_project_teast_19._1._21.Models
{
    public class Citizen
    {
        int id;
        string fathrName;
        string gender;
        bool isBornInTheVillage;
        DateTime dateBith;

        public int Id { get => id; set => id = value; }
        public string FathrName { get => fathrName; set => fathrName = value; }
        public string Gender { get => gender; set => gender = value; }
        public bool IsBornInTheVillage { get => isBornInTheVillage; set => isBornInTheVillage = value; }
        public DateTime DateBith { get => dateBith; set => dateBith = value; }
    }
}