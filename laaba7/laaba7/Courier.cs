using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laaba7
{
    public class Courier
    {
        public int Id_Couriers { get; set; }

        public string Name_Couriers { get; set; }

        public string Telephone_number_Couriers { get; set; }

        public int IdS_Couriers { get; set; }


        public Courier(int id, string name, string telephone_number,int ids) 
        {
            Id_Couriers = id;
            Name_Couriers = name;
            Telephone_number_Couriers = telephone_number;
            IdS_Couriers = ids;
        }
    }
}
