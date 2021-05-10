using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class StaffCategoryCRUD
    {
        public static List<StaffCategory> ReadAll(string connStr)
        {
            List<StaffCategory> sc = new List<StaffCategory>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.staff_category;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sc.Add(new StaffCategory {
                        sc_id = (int)dr["sc_id"],
                        sc_name = (string)dr["sc_name"],
                        sc_desc = (string)dr["sc_desc"]
                    });
                }
            }
            _conn.Close();
            return sc;
        }
 
        public static StaffCategory Read(string connStr, int sc_id)
        {
            StaffCategory sc = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM `db_kampus`.`staff_category` WHERE sc_id = '"+sc_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                sc = new StaffCategory();
                sc.sc_id = (int)dt.Rows[0]["sc_id"];
                sc.sc_name = (string)dt.Rows[0]["sc_name"];
                sc.sc_desc = (string)dt.Rows[0]["sc_desc"];
            }
            
            _conn.Close();
            return sc;
        }

        public static int Create(string connStr, StaffCategory sc)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "INSERT INTO `db_kampus`.`staff_category` (`sc_id`,`sc_name`,`sc_desc`) "+
                            "VALUES ('"+sc.sc_id+"', '"+sc.sc_name+"', '"+sc.sc_desc+"');";

            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int Update(string connStr, int sc_id, StaffCategory sc)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "UPDATE `db_kampus`.`staff_category` SET `sc_name` = '"+sc.sc_name+"', `sc_desc` = '"+sc.sc_desc+"' "+
                            "WHERE (`sc_id` = '"+sc_id+"');";
            
            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int Delete(string connStr, int sc_id)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "DELETE FROM `db_kampus`.`staff_category` WHERE (`sc_id` = '"+sc_id+"');";

            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
    }
}