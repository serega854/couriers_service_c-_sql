using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using laaba7;
using MySql;
using MySql.Data.MySqlClient;
using laba7;

namespace laba7
{
    class MySqlClass
    {
        public static CourierAndService[] GetCouriers()
        {
            // вывод пойдет на консоль и в лист виджет по классу
            var couriers = new List<CourierAndService>(); // LIST

            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

             var connection = new MySqlConnection(connectionString);

            connection.Open();

             var commamd = connection.CreateCommand();

            commamd.CommandText = "select * from couriers join delivery_services on couriers.iddelivery_services = delivery_services.iddelivery_services;";

             var reader = commamd.ExecuteReader();

            while (reader.Read())
            {
               // Console.WriteLine($"id курьера: {reader.GetInt32(0)} имя курьера: {reader.GetString(1)} телефон курьера: {reader.GetString(2)} id службы доставки: {reader.GetInt32(3)}");

                // паралельно загружаю лист виджет данными
               couriers.Add(new CourierAndService(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(5)));
            }    
            //using не работает
            connection.Close();
            commamd.Dispose();
            reader.Close();

            return couriers.ToArray();
        }




        public static Delivery_service[] GetServices()
        {
            var delivery_services = new List<Delivery_service>();

             var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

             var connection = new MySqlConnection(connectionString);

            connection.Open();

             var commamd = connection.CreateCommand();

            commamd.CommandText = "select * from delivery_services";

             var reader = commamd.ExecuteReader();

            while (reader.Read())
            {
                delivery_services.Add(new Delivery_service(reader.GetInt32(0), reader.GetString(1)));
            }
            connection.Close();
            commamd.Dispose();
            reader.Close();

            return delivery_services.ToArray();
        }

        // удаление курьера
        public static int DelCouriers(int id)
        {

            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

            var connection = new MySqlConnection(connectionString);

            connection.Open();

            var commamd = connection.CreateCommand();
            try
            {
                var command = new MySqlCommand("delete from couriers where idcouriers = @id;", connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                connection.Close();
                commamd.Dispose();
                reader.Close();

                return 2;
            }
            catch
            {
                return 1;
            }
        }

        // удаление службы доставки
        public static int DelDelivery(int id)
        {
            try
            {

                var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

                var connection = new MySqlConnection(connectionString);

                connection.Open();

                var commamd = connection.CreateCommand();

                var command = new MySqlCommand("delete from delivery_services where iddelivery_services = @id;", connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                connection.Close();
                commamd.Dispose();
                reader.Close();
                return 2;
            }
            catch
            {
                return 1;
            }
        }

        public static int GetIdService(string name)
        {
            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

            var connection = new MySqlConnection(connectionString);

            connection.Open();

            var commamd = connection.CreateCommand();
            try
            {
                var command = new MySqlCommand("select iddelivery_services from delivery_services where `name` = @name;", connection);
                command.Parameters.AddWithValue("@name", name);
                var reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                connection.Close();
                commamd.Dispose();
                reader.Close();

                return count;
            }
            catch
            {
                return 0;
            }
        }

        // добавление курьеров
        public static int AddCouriers(string name,string telephone_number,int idS)
        {
            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            try
            {
                var commamd = connection.CreateCommand();
                //var command = new MySqlCommand("insert into couriers values("+id+",'" +name+"',"+ telephone_number + "," + id + ");", connection);
                //параметризация запроса:
                
                 var command = new MySqlCommand("insert into couriers  (`name`,telephon_number,iddelivery_services) values ( @name, @telephone_number,@idS); ", connection);
                
                MySqlParameter param2 = new MySqlParameter("@name", name);
                command.Parameters.Add(param2);
                MySqlParameter param3 = new MySqlParameter("@telephone_number", telephone_number);
                command.Parameters.Add(param3);
                MySqlParameter param4 = new MySqlParameter("@idS", idS);
                command.Parameters.Add(param4);
                //command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }
            catch
            {
                return 1; // 1 если не удалоось добавить курьера
            }
            return 2; //2 если удалось
        }




        public static int AddDeliveryService(string name)
        {
            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            try
            {
                using (var commamd = connection.CreateCommand())
                {
                    //var command = new MySqlCommand("insert into couriers values("+id+",'" +name+"',"+ telephone_number + "," + id + ");", connection);
                    //параметризация запроса:
                    var command = new MySqlCommand("insert into delivery_services(`name`) values (@name); ", connection);
                    
                    MySqlParameter param2 = new MySqlParameter("@name", name);
                    command.Parameters.Add(param2);

                    //command.Parameters.AddWithValue("id", id);
                    var reader = command.ExecuteReader();
                    connection.Close();
                    commamd.Dispose();
                    reader.Close();
                }
            }
            catch
            {
                return 1; // 1 если не удалоось добавить курьера
            }
            return 2; //2 если удалось
        }

        public static int UpdateDeliveryService(int id, string name)
        {
            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            try
            {
                var commamd = connection.CreateCommand();
                //var command = new MySqlCommand("insert into couriers values("+id+",'" +name+"',"+ telephone_number + "," + id + ");", connection);
                //параметризация запроса:
                var command = new MySqlCommand("update delivery_services set `name` = @name where iddelivery_services = @id; ", connection);
                MySqlParameter param1 = new MySqlParameter("@id", id);
                command.Parameters.Add(param1);
                MySqlParameter param2 = new MySqlParameter("@name", name);
                command.Parameters.Add(param2);

                //command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }
            catch
            {
                return 1; // 1 если не удалоось добавить курьера
            }
            return 2; //2 если удалось
        }

        public static int UpdateCouriers(int id, string name, string telephone_number, int idS)
        {
            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            try
            {
                var commamd = connection.CreateCommand();
                //var command = new MySqlCommand("insert into couriers values("+id+",'" +name+"',"+ telephone_number + "," + id + ");", connection);
                //параметризация запроса:
                var command = new MySqlCommand("update couriers set `name` = @name, telephon_number = @telephone_number , iddelivery_services = @idS where idcouriers = @id; ", connection);
                
                MySqlParameter param1 = new MySqlParameter("@name", name);
                command.Parameters.Add(param1);
                MySqlParameter param2 = new MySqlParameter("@telephone_number", telephone_number);
                command.Parameters.Add(param2);
                MySqlParameter param3 = new MySqlParameter("@idS", idS);
                command.Parameters.Add(param3);
                MySqlParameter param4 = new MySqlParameter("@id", id);
                command.Parameters.Add(param4);

                //command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                connection.Close();
                commamd.Dispose();
                reader.Close();
            }
            catch
            {
                return 1; // 1 если не удалоось добавить курьера
            }
            return 2; //2 если удалось
        }





        public static int CountCouriersInDeliveryService(int id)
        {
           

                var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

                var connection = new MySqlConnection(connectionString);

                connection.Open();

                var commamd = connection.CreateCommand();

                var command = new MySqlCommand("select count(idcouriers) from couriers where iddelivery_services = @id;", connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
               count = reader.GetInt32(0);
            }


            connection.Close();
                commamd.Dispose();
                reader.Close();

                return count;
            
        }
        public static int CountOrders(string name)
        {


            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

            var connection = new MySqlConnection(connectionString);

            connection.Open();

            var commamd = connection.CreateCommand();
            try
            {
                var command = new MySqlCommand("select max(groceries.price) from groceries join markets on groceries.idmarkets = markets.idmarkets where markets.`name` = @name;", connection);
                command.Parameters.AddWithValue("@name", name);
                var reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                connection.Close();
                commamd.Dispose();
                reader.Close();

                return count;
            }
            catch
            {
                return 0;
            }
        }
        
        public static Markets[] GetMarkets()
        {
            var markets = new List<Markets>();

            var connectionString = "Server=localhost;Database=delyvery_db14;Uid=root;Pwd=1234;";

            var connection = new MySqlConnection(connectionString);

            connection.Open();

            var commamd = connection.CreateCommand();

            commamd.CommandText = "select * from markets";

            var reader = commamd.ExecuteReader();

            while (reader.Read())
            {
                markets.Add(new Markets(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            connection.Close();
            commamd.Dispose();
            reader.Close();

            return markets.ToArray();
        }          
    }
}
