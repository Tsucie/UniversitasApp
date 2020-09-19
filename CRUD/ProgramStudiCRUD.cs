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
                    ps_fks_id = _data.GetInt32(1),
                    ps_name = _data.GetString(2),
                    ps_desc = _data.GetString(3)
                });
            }
            _conn.Close();
            return ps;
        }

        public static ProgramStudi Read(string connStr, int ps_id)
        {
            ProgramStudi ps = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.program_studi WHERE (`ps_id` = '"+ps_id+"');";
            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _command.ExecuteReader();
            if(_data.Read().Equals(true))
            {
                ps = new ProgramStudi();
                ps.ps_id = _data.GetInt32(0);
                ps.ps_fks_id = _data.GetInt32(1);
                ps.ps_name = _data.GetString(2);
                ps.ps_desc = _data.GetString(3);
            }
            _conn.Close();
            return ps;
        }

        public static int Create(string connStr, ProgramStudi ps)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "INSERT INTO `db_kampus`.`program_studi`"+
            " (`ps_id`, `ps_fks_id`, `ps_name`, `ps_desc`)"+
            " VALUES ('"+ps.ps_id+"','"+ps.ps_fks_id+"','"+ps.ps_name+"','"+ps.ps_desc+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int CreateAlive(MySqlConnection _conn, ProgramStudi ps)
        {
            int affectedRow = 0;
            string sqlStr = "INSERT INTO `db_kampus`.`program_studi`"+
            " (`ps_id`, `ps_fks_id`, `ps_name`, `ps_desc`)"+
            " VALUES ('"+ps.ps_id+"','"+ps.ps_fks_id+"','"+ps.ps_name+"','"+ps.ps_desc+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static int Update(string connStr, int ps_id, int ps_fks_id, ProgramStudi ps)
        {
            int affectedRow = 0;
            string sqlFks = "";
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            
            if(!ps.ps_fks_id.Equals(null)) sqlFks = "`ps_fks_id` = '"+ps.ps_fks_id+"', ";

            string sqlStr = "UPDATE `db_kampus`.`program_studi` SET "+ sqlFks +
            "`ps_name` = '"+ps.ps_name+"', `ps_desc` = '"+ps.ps_desc+"' "+
            "WHERE (`ps_id` = '"+ps_id+"' AND `ps_fks_id` = '"+ps_fks_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int UpdateAlive(MySqlConnection _conn, int ps_id, int ps_fks_id, ProgramStudi ps)
        {
            int affectedRow = 0;

            string sqlStr = "UPDATE `db_kampus`.`program_studi` SET "+
            "`ps_name` = '"+ps.ps_name+"', `ps_desc` = '"+ps.ps_desc+"' "+
            "WHERE (`ps_id` = '"+ps_id+"' AND `ps_fks_id` = '"+ps_fks_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static int Delete(string connStr, int ps_id)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "DELETE FROM `db_kampus`.`program_studi` WHERE (`ps_id` = '"+ps_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int DeleteAlive(MySqlConnection _conn, int ps_id, int ps_fks_id)
        {
            int affectedRow = 0;
            string sqlStr = "DELETE FROM `db_kampus`.`program_studi` WHERE (`ps_id` = '"+ps_id+"' AND `ps_fks_id` = '"+ps_fks_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();
            
            return affectedRow;
        }

    }
}