using System.Data;
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
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ps.Add(new ProgramStudi {
                        ps_id = (int)dr["ps_id"],
                        ps_fks_id = (int)dr["ps_fks_id"],
                        ps_name = (string)dr["ps_name"],
                        ps_desc = (string)dr["ps_desc"]
                    });
                }
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
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ps = new ProgramStudi();
                ps.ps_id = (int)dt.Rows[0]["ps_id"];
                ps.ps_fks_id = (int)dt.Rows[0]["ps_fks_id"];
                ps.ps_name = (string)dt.Rows[0]["ps_name"];
                ps.ps_desc = (string)dt.Rows[0]["ps_desc"];
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