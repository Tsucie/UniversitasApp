using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class RoleCRUD
    {
        public static List<Role> ReadAll(string connStr)
        {
            List<Role> roles = new List<Role>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT r_id, rt_name, r_name, rt_desc, r_c_id, r_s_id "+
                            "FROM `db_kampus`.`role` "+
                            "INNER JOIN db_kampus.role_type ON r_rt_id = rt_id;";
            
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while (_data.Read())
            {
                roles.Add(new Role {
                    r_id = _data.GetInt32(0),
                    rt_name = _data.GetString(1),
                    r_name = _data.GetString(2),
                    rt_desc = _data.GetString(3),
                    r_c_id = (_data.IsDBNull(4)) ? (int?)null : _data.GetInt32(4),
                    r_s_id = (_data.IsDBNull(5)) ? (int?)null : _data.GetInt32(5)
                });
            }
            _conn.Close();
            return roles;
        }
    }
}