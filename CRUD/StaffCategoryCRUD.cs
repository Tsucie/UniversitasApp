using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;
using UniversitasApp.Controllers;

namespace UniversitasApp.CRUD
{
    public sealed class StaffCategoryCRUD
    {
        public static async Task<List<StaffCategory>> ReadAllAsync(string connStr)
        {
            List<StaffCategory> sc = new List<StaffCategory>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.staff_category;";

            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _dtrdr = await Task.Run(() => _command.ExecuteReader());
            while (_dtrdr.ReadAsync().Result)
            {
                sc.Add(new StaffCategory {
                    sc_id = _dtrdr.GetInt32(0),
                    sc_name = _dtrdr.GetString(1),
                    sc_desc = _dtrdr.GetString(2)
                });
            }
            _conn.Close();
            return sc;
        }
 
        public static StaffCategory Read(string connStr, int sc_id)
        {
            StaffCategory sc = new StaffCategory();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM `db_kampus`.`staff_category` WHERE sc_id = '"+sc_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read().Equals(true))
            {
                sc.sc_id = _data.GetInt32(0);
                sc.sc_name = _data.GetString(1);
                sc.sc_desc = _data.GetString(2);
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