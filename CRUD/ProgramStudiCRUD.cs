using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class ProgramStudiCRUD
    {
        public static List<ProgramStudi> ReadListByFks(string connStr, int ps_fks_id)
        {
            List<ProgramStudi> ps = new List<ProgramStudi>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM `db_kampus`.`program_studi` WHERE (ps_fks_id = '"+ps_fks_id+"');";
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while (_data.Read())
            {
                ps.Add(new ProgramStudi {
                    ps_id = _data.GetInt32(0),
                    // ps_fks_id = _data.GetInt32(1),
                    ps_name = _data.GetString(2),
                    ps_desc = _data.GetString(3)
                });
            }
            _conn.Close();
            return ps;
        }
    }
}