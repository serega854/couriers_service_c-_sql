using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using laba7;


// осталось : удалить лишнее        , узнать что такое статик       ,сделать логику кнопок    и лейблов чтобы ненужные становились прозрачными     , кнопки изменения недоступны если записей ноль,
// при выводе таблиц по умолчанию выбирается первая



namespace laaba7
{
    

    public partial class Form1 : Form
    {
         int button_1 = 0; //вывод курьеров
         int button_2 = 0; //вывод сервисов
         int button_10 = 0; //цена самого дорого продукта
        
         int lastIDCouriers = 0; //последний выбранный курьер
         int lastIDService = 0; //последний выбранный сервис



        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_10 = 0;  // значит что магазины НЕ выведены в грид

            dataGridView1.DataSource = MySqlClass.GetCouriers(); // вывод курьеров
            dataGridView1.Columns[0].Visible = false;
            label1.Text = "Выведены курьеры";
            button_1 = 1; //вывод курьеров
            button_2 = 0; //вывод сервисов
            if (dataGridView1.Rows.Count > 0) //если записи есть кнопка удалить доступна
            {
                button4.Enabled = true;
            }
            if (dataGridView1.Rows.Count <= 0) //если записей нет кнопка удалить недоступна
            {
                button4.Enabled = false;
            }

            //все кнопки и поля, связанные с сервисами недоступны
            
            label5.Enabled = false;
            textBox4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;

            //все кнопка и поля, связанные с курьерами доступны
            button5.Enabled = true;
            button8.Enabled = true;
            label2.Enabled = true;
            textBox1.Enabled = true;
            label3.Enabled = true;
            textBox2.Enabled = true;
            label4.Enabled = true;
            textBox3.Enabled = true;

            //поле с текстом, связанные с сервисами очищаются 
            textBox4.Text = "";

            //убираю автовыбор с первой ячейки, так как она скрыта и не учитывается пользователем
            if (dataGridView1.Rows.Count > 0) //если записи есть 
            {
                dataGridView1.Rows[0].Cells[0].Selected = false;
                button8.Enabled = true; // кнопка изменить курьера доступна
            }
            if (dataGridView1.Rows.Count <= 0) //если записей нет
            {
                button8.Enabled = false; // кнопка изменить курьера недоступна
            }
        }


        private void button2_Click(object sender, EventArgs e) // вывод сервисов
        {
            button_10 = 0;  // значит что магазины НЕ выведены в грид
            button_1 = 0; //вывод курьеров
            button_2 = 1; //вывод сервисов

            dataGridView1.DataSource = MySqlClass.GetServices();
            dataGridView1.Columns[0].Visible = false;

            label1.Text = "Выведены службы доставки";

            if (dataGridView1.Rows.Count > 0) //если записи есть кнопка удалить доступна
            {
                button4.Enabled = true;
            }
            if (dataGridView1.Rows.Count <= 0) //если записей нет кнопка удалить недоступна
            {
                button4.Enabled = false;
            }

            //все кнопки и поля, связанные с сервисами недоступны

            label5.Enabled = true;
            textBox4.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            //все кнопка и поля, связанные с курьерами доступны
            button5.Enabled = false;
            button8.Enabled = false;
            label2.Enabled = false;
            textBox1.Enabled = false;
            label3.Enabled = false;
            textBox2.Enabled = false;
            label4.Enabled = false;
            textBox3.Enabled = false;

            //поле с текстом, связанные с сервисами очищаются 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            //убираю автовыбор с первой ячейки, так как она скрыта и не учитывается пользователем
            if (dataGridView1.Rows.Count > 0) //если записи есть 
            {
                dataGridView1.Rows[0].Cells[0].Selected = false;
                button7.Enabled = true; // кнопка изменить службу доставки доступна
            }
            if (dataGridView1.Rows.Count <= 0) //если записей нет
            {
                button7.Enabled = false; // кнопка изменить службу доставки недоступна
            }
        }
 
        public void button4_Click(object sender, EventArgs e) // удаление по выбранной строке
        {

            if (dataGridView1.Rows.Count > 0)// если записи есть
            {

                if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0) //если выбрано больше 0 ячеек
                    {

                    if (button_1 == 1 && button_2 == 0) // до этого была нажата кнопка курьеры
                    {
                        lastIDCouriers = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                        MySqlClass.DelCouriers(lastIDCouriers);

                        button1_Click(sender, e); //для моментального обновления таблицы делаю повторное нажатие
                        label1.Text = "Курьер по выбранной строке удален";

                    }
                    if (button_1 == 0 && button_2 == 1) // до этого была нажата доставки
                    {
                        lastIDService = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                        int t = 0;
                        t = MySqlClass.DelDelivery(lastIDService);
                        if (t == 2)
                        {
                            button2_Click(sender, e); //для моментального обновления таблицы делаю повторное нажатие
                            label1.Text = "Служба доставки удалена";
                        }
                        if (t == 1)
                        {
                            button2_Click(sender, e); //для моментального обновления таблицы делаю повторное нажатие
                            label1.Text = "Не удалось удалить, в службе доставки курьер";
                        }
                    }
                }
                else
                {
                    label1.Text = "Ни одна ячейка не выбрана";
                }
            }



            else
            {
                label1.Text = "Строка для удаления не выбрана";
            }

 
        }

        
        public void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//добавить курьера
        {
            button_10 = 0;  // значит что магазины НЕ выведены в грид
            try
            {
                if (textBox1.Text.Length != 0)
                {
                    if (textBox2.Text.Length != 0)
                    {
                        if (textBox3.Text.Length != 0)
                        {
                            
                            Convert.ToInt64(textBox2.Text);

                            
                            string name = textBox1.Text; //здесь получим имя курьера
                            string number = textBox2.Text;

                            int id = MySqlClass.GetIdService(textBox3.Text);
                            int rez = MySqlClass.AddCouriers(name, number, id);

                            if (rez == 2)
                            {
                                button1_Click(sender, e); // повторное нажатие вывода курьеров
                                label1.Text = "Курьер добавлен";
                            }

                            if (rez == 1)
                            {
                                label1.Text = "Службы доставки с указанным названием нет";
                            }
                        }
                    }
                }
                if (textBox1.Text.Length == 0)
                {
                    label1.Text = "Введите имя курьера";
                }
                if (textBox2.Text.Length == 0)
                {
                    label1.Text = "Введите номер телефона курьера";
                }
                if (textBox3.Text.Length == 0)
                {
                    label1.Text = "Введите название службы доставки";
                }
            }
            catch
            {
                label1.Text = "Номер телефона должен состоять из цифр";
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) // добавление службы доставки
        {
            if (button_10 == 0)
            {
                if (textBox4.Text.Length != 0)
                {
                    label1.Text = "";

                    string name = textBox4.Text;

                    // сравниваю нейм со всеми запясями в грид 

                    int rez = MySqlClass.AddDeliveryService(name);
                    if (rez == 2)
                    {
                        button2_Click(sender, e); // повторное нажатие вывода курьеров

                    }

                    if (rez == 1)
                    {
                        label1.Text = "Введенное имя занято";
                    }
                }

                if (textBox4.Text.Length == 0)
                {
                    label1.Text = "Введите название службы доставки";
                }
            }
            else
                label1.Text = "Тут нельзя изменять службу доставки";


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)//Изменить данные служб доставки
        {
            if (button_10 == 0)
            {
                if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0) //если выбрано больше 0 ячеек
                {
                    int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); // выбранная строка для изменения

                    if (textBox4.Text.Length == 0)
                    {
                        label1.Text = "Напишите новое название";
                    }
                    if (textBox4.Text.Length != 0)
                    {
                        string new_name = textBox4.Text;

                        int rez = MySqlClass.UpdateDeliveryService(i, new_name);

                        if (rez == 2)//получилось
                        {
                            button2_Click(sender, e); // повторное нажатие вывода курьеров
                            label1.Text = "Служба доставки изменена ";
                        }
                        if (rez == 1)//получилось
                        {
                            label1.Text = "Выбранное имя занято";
                        }
                    }
                }
                else
                {
                    label1.Text = "Служба доставки для изменения не выбрана";
                }
            }
            else
                label1.Text = "Тут нельзя изменять службу доставки";

        }

        private void button8_Click(object sender, EventArgs e) // изменить данные курьера
        {
            button_10 = 0;  // значит что магазины НЕ выведены в грид
            try
            {
                if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0) //если выбрано больше 0 ячеек
                {
                    if (textBox1.Text.Length != 0)
                    {
                        if (textBox2.Text.Length != 0)
                        {
                            if (textBox3.Text.Length != 0)
                            {
                                //Convert.ToInt64(textBox2.Text);
                                int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value); // выбранная строка для изменения


                                string name = textBox1.Text; //здесь получим имя курьера
                                string number = textBox2.Text;

                                string nameS = textBox3.Text; //НАЗВАНИЕ существуюшей службы доставки 


                                int id = MySqlClass.GetIdService(textBox3.Text); // получаем айди службы доставки
                                int rez = MySqlClass.UpdateCouriers(i, name, number, id);

                                if (rez == 2)
                                {
                                    button1_Click(sender, e); // повторное нажатие вывода курьеров
                                    label1.Text = "Курьер изменен ";
                                }

                                if (rez == 1)
                                {
                                    label1.Text = "Службы доставки с указанным названием нет";
                                }
                            }
                        }
                    }
                    if (textBox1.Text.Length == 0)
                    {
                        label1.Text = "Введите имя курьера";
                    }
                    if (textBox2.Text.Length == 0)
                    {
                        label1.Text = "Введите номер телефона курьера";
                    }
                    if (textBox3.Text.Length == 0)
                    {
                        label1.Text = "Введите навзвание службы доставки";
                    }
                }

                else
                {
                    label1.Text = "Выберите курьера для изменения";
                }

            }
            catch
            {
                label1.Text = "Номер телефона должен состоять из цифр";
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Вывод ячеек в текст боксы
        {
            if(button_2 == 1 && button_1 == 0) // вывод службы доставки
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }

            if (button_2 == 0 && button_1 == 1) // вывод курьеров
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = "";
            }

        }


        private void button9_Click(object sender, EventArgs e) // количество курьеров в выбранной службе доставки
        {
            if (dataGridView1.Rows.Count > 0)// если записи есть
            {
                if (button_10 == 0)
                {
                    if (dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0) //если выбрано больше 0 ячеек
                    {
                        int i = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

                        if (MySqlClass.CountCouriersInDeliveryService(i) != 1)
                        {
                            label1.Text = "В выбранной службе доставки работает " + MySqlClass.CountCouriersInDeliveryService(i) + " курьеров";
                        }
                        if (MySqlClass.CountCouriersInDeliveryService(i) == 1)
                        {
                            label1.Text = "В выбранной службе доставки работает " + MySqlClass.CountCouriersInDeliveryService(i) + " курьер";
                        }
                    }
                    else
                    {
                        label1.Text = "Выберите службу доставки";
                    }
                }
                else
                {
                    label1.Text = "Здесь нельзя посмотреть количество курьеров";
                }
            }
            else
            {
                label1.Text = "Служб доставки нет";
            }
        }


        private void button10_Click(object sender, EventArgs e) // цена самого дорого продукта
        {
            button_10 = 1;  // значит что магазины выведены в грид

            dataGridView1.DataSource = MySqlClass.GetMarkets();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            string name = textBox4.Text;

            if (name.Length > 0)
            {
                if (MySqlClass.CountOrders(name) != 0)
                {
                    label1.Text = "Цена самого дорого продукта в " + name + " = " + MySqlClass.CountOrders(name);
                }
                else
                    label1.Text = "Название магазина введено неверно";
            }
            if(name.Length <= 0)
            {
                label1.Text = "Напишите название магазина в поле <<название>>";
            }

            button4.Enabled = false;  // кнопка удаления здесь недоступна
        }
    }
}
