using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data; // Для возможности использования типа данных DataSet
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    internal class DBWork
    {
        static private string dbname = "Servis.db";
        static private string path = $"Data Source={dbname};";

        static public bool MakeDB(string _dbname = "Servis.db")
        {
            bool result = false;
            string path = $"Data Source={_dbname};";
            string create_table_mechanic = "CREATE TABLE IF NOT EXISTS " +
                        "Mechanic " +
                        " (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        " number INTEGER," +
                        " name VARCHAR);";
            string init_data_mechanic = "INSERT INTO Mechanic (number, name) " +
                        "VALUES " +
                        "(1, 'Иванов')," +
                        "(2, 'Петров')," +
                        "(3, 'Сидоров')," +
                        "(4, 'Стрельцов');";
            string create_table_jobs = "CREATE TABLE IF NOT EXISTS " +
                        "Jobs " +
                        "(Jobs_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "number INTEGER," +
                        "name VARCHAR," +
                        "standartHours REAL," +
                        "cost DECIMAL," +
                        "client VARCHAR," +
                        "Mechanic_ID INTEGER," +
                        "FOREIGN KEY(Mechanic_ID) REFERENCES Mechanic(id));";
            string init_data_jobs = "INSERT INTO Jobs " + " (number,name,standartHours,cost," +
                        " client, Mechanic_id) " +
                        "VALUES " +
                        " (1,'Прокачака тормозной системы', 1.5, 3000, 'а001мр',1)," +
                        " (2,'Замена масла', 1, 3000, 'а004мр',3)," +
                        " (3,'Консультация', 0.5, 3000, 'а003мр',2)," +
                        " (4,'Замена лампочки', 0.7, 3000, 'а002мр',4);";
            SQLiteConnection conn = new SQLiteConnection(path);
            SQLiteCommand cmd01 = conn.CreateCommand();
            SQLiteCommand cmd02 = conn.CreateCommand();
            SQLiteCommand cmd03 = conn.CreateCommand();
            SQLiteCommand cmd04 = conn.CreateCommand();
            cmd01.CommandText = create_table_mechanic;
            cmd02.CommandText = init_data_mechanic;
            cmd03.CommandText = create_table_jobs;
            cmd04.CommandText = init_data_jobs;
            conn.Open();
            cmd01.ExecuteNonQuery();
            cmd02.ExecuteNonQuery();
            cmd03.ExecuteNonQuery();
            cmd04.ExecuteNonQuery();
            conn.Close();
            result = true;
            return result;
        }
        // Метод для получения из базы набора имён мастеров
        static public List<string> GetMechanics()
        {
            List<string> result = new List<string>();
            string get_mechanics = "SELECT name  FROM Mechanic";
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = get_mechanics;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) // Если reader имеет поля
                {
                    while (reader.Read()) // Читает значения и переходит на следующие                    
                        result.Add(reader.GetString(0)); // Добавляет по строчке                    
                }
            }
            return result;
        }
        static public void AddData(string _newCategoryInsert, string _dbname = "Servis.db")
        {
            string path = $"Data Source={_dbname};";
            // Выделяем ресурс, который должен финализироваться по завершении
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand cmd = new SQLiteCommand(conn); // cmd - это ссылка
                //conn.ConnectionString = path;
                cmd.CommandText = _newCategoryInsert;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        static public DataSet Refresh(string _dbname = "Servis.db")
        {
            DataSet result = new DataSet();
            string path = $"Data Source={_dbname};";
            string show_all_data = "SELECT * FROM Category;"; // SQL-запрос для вывода всех данных
            // Описываем время существования соединения (создаём соединение и финализируем его)
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                conn.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(show_all_data, conn); // Создаём адаптер и наполняем его данными
                adapter.Fill(result);
            }
            return result;

        }
        static public void Save(DataTable dt, out string _query, string _dbname = "Servis.db")
        {
            // Описание запросов (как раздел var в Pascale)
            string path = $"Data Source={_dbname};";
            string show_all_data = "SELECT * FROM Category;";
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                conn.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(show_all_data, conn);
                SQLiteCommandBuilder commandBulder = new SQLiteCommandBuilder(adapter); // Берёт инфу о структуре таблицы
                adapter.Update(dt); // Обновляем данные
                _query = commandBulder.GetUpdateCommand().CommandText; // Обновлённый текст
            }
        }
    }
}
