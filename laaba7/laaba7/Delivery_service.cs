using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laaba7
{
    public class Delivery_service
    {
        //0,1,2,3,8 столбцы
        public int Id_Service { get; set; }

        public string Name_Service { get; set; }

        public Delivery_service(int id, string name) 
        {
            Id_Service = id;
            Name_Service = name;
        }
    }
}
