using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

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

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    fks.Add(new Fakultas {
                        fks_id = (int)dr["fks_id"],
                        fks_name = (string)dr["fks_name"],
                        fks_desc = (string)dr["fks_desc"]
                    });
                }
            }
            _conn.Close();
            return fks;
        }

        public static Fakultas Read(string connStr, int fks_id)
        {
            Fakultas fks = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT * FROM db_kampus.fakultas WHERE (`fks_id` = '"+fks_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                fks = new Fakultas();
                fks.fks_id = (int)dt.Rows[0]["fks_id"];
                fks.fks_name = (string)dt.Rows[0]["fks_name"];
                fks.fks_desc = (string)dt.Rows[0]["fks_desc"];
            }
            _conn.Close();
            return fks;
        }

        public static int Create(string connStr, Fakultas fks)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "INSERT INTO `db_kampus`.`fakultas`"+
            " (`fks_name`, `fks_desc`)"+
            " VALUES ('"+fks.fks_name+"','"+fks.fks_desc+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int CreateAlive(MySqlConnection _conn, Fakultas fks)
        {
            int affectedRow = 0;
            string sqlStr = "INSERT INTO `db_kampus`.`fakultas`"+
            " (`fks_name`, `fks_desc`)"+
            " VALUES ('"+fks.fks_name+"','"+fks.fks_desc+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static int Update(string connStr, int fks_id, Fakultas fks)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "UPDATE `db_kampus`.`fakultas` SET "+
            "`fks_name` = '"+fks.fks_name+"', `fks_desc` = '"+fks.fks_desc+"' "+
            "WHERE (`fks_id` = '"+fks_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int UpdateAlive(MySqlConnection _conn, int fks_id, Fakultas fks)
        {
            int affectedRow = 0;

            string sqlStr = "UPDATE `db_kampus`.`fakultas` SET "+
            "`fks_name` = '"+fks.fks_name+"', `fks_desc` = '"+fks.fks_desc+"' "+
            "WHERE (`fks_id` = '"+fks_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static int Delete(string connStr, int fks_id)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "DELETE FROM `db_kampus`.`fakultas` WHERE (`fks_id` = '"+fks_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int DeleteAlive(MySqlConnection _conn, int fks_id)
        {
            int affectedRow = 0;
            string sqlStr = "DELETE FROM `db_kampus`.`fakultas` WHERE (`fks_id` = '"+fks_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();
            
            return affectedRow;
        }
    }
}