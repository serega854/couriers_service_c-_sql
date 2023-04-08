using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laaba7
{
    class CourierAndService
    {
        public int Id_C { get; set; }

       public string Name_Couriers { get; set; }

        public string Telephone_number_Couriers { get; set; }

        public string Name_s_Service { get; set; }

         public CourierAndService(int Id_c,string name, string telephone_number, string name_s)
        //public CourierAndService(string name, string telephone_number, string name_s)
        {
            Id_C = Id_c;   
            Name_Couriers = name;
            Telephone_number_Couriers = telephone_number;
            
            Name_s_Service = name_s;
        }
    }
}
