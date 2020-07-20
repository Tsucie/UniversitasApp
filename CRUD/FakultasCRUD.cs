using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;
using UniversitasApp.Controllers;

namespace UniversitasApp.CRUD
{
    public sealed class FakultasCRUD
    {
        public static List<Fakultas> ReadAll(string connStr)
        {
            List<Fakultas> fks = new List<Fakultas>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.fakultas;";
            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _dtrdr = _command.ExecuteReader();
            while(_dtrdr.Read())
            {
                fks.Add(new Fakultas {
                    fks_id = _dtrdr.GetInt32(0),
                    fks_name = _dtrdr.GetString(1),
                    fks_desc = _dtrdr.GetString(2)
                });
            }
            _conn.Close();
            return fks;
        }
    }
}