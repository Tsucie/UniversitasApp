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
    public sealed class MhsCRUD
    {
        // Read All
        // public static List<UserMahasiswa> ReadAll(string connStr)
        // {
        //     List<UserMahasiswa> um = new List<UserMahasiswa>();
        //     using var _conn = new MySqlConnection(connStr);
        //     _conn.Open();
        //     string sqlStr = "";

        //     _conn.Close();
        //     return um;
        // }

        // Create mahasiswa
        public static int CreateMhs(string connStr, UserMahasiswa mhs)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            
            string sqlStr = "INSERT INTO `db_kampus`.`mahasiswa`"+
            " (`mhs_id`, `mhs_u_id`,`mhs_fks_id`, `mhs_fullname`, `mhs_nim`, `mhs_kelas`, `mhs_address`, `mhs_province`, `mhs_city`, `mhs_birthplace`, `mhs_birthdate`, `mhs_gender`, `mhs_religion`, `mhs_state`, `mhs_email`, `mhs_stat`, `mhs_contact`)"+
            " VALUES ('"+mhs.mhs_id +"', '"+mhs.mhs_u_id+"','"+mhs.mhs_fks_id+"', '"+mhs.mhs_fullname+"', '"+mhs.mhs_nim+"', '"+mhs.mhs_kelas+"', '"+mhs.mhs_address+"', '"+mhs.mhs_province+"', '"+mhs.mhs_city+"', '"+mhs.mhs_birthplace+"', '"+mhs.mhs_birthdate+"', '"+mhs.mhs_gender+"', '"+mhs.mhs_religion+"', '"+mhs.mhs_state+"', '"+mhs.mhs_email+"', '"+mhs.mhs_stat+"', '"+mhs.mhs_contact+"');";
            
            using var _command = new MySqlCommand(sqlStr, _connection);
            using MySqlDataReader _datareader = _command.ExecuteReader();
            if (_datareader.RecordsAffected.Equals(1)) affectedRow = _datareader.RecordsAffected;

            _connection.Close();
            return affectedRow;
        }
    }
}