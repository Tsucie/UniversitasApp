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
    public sealed class UserCRUD
    {
        //Activity Table
        public static List<Users> ReadAllActivity(string connStr)
        {
            List<Users> u = new List<Users>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT u.u_id, u.u_username, u.u_login_time, u.u_logout_time, u.u_login_status, ut.ut_name FROM db_kampus.users u " +
                            "INNER JOIN db_kampus.user_type ut ON u.u_ut_id = ut.ut_id;";
            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _dtrdr = _command.ExecuteReader();
            while(_dtrdr.Read())
            {
                u.Add(new Users {
                    u_id = _dtrdr.GetInt32(0),
                    u_username = _dtrdr.GetString(1),
                    u_login_time = _dtrdr.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss"),
                    u_logout_time = _dtrdr.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss"),
                    u_login_status = _dtrdr.GetInt16(4),
                    //user_type
                    ut_name = _dtrdr.GetString(5)
                });
            }
            _conn.Close();
            return u;
        }
        // ===============================================================================================
        // Login CRUD
        // ===============================================================================================
        ///<summary>
        /// Login Page Read
        ///</summary>
        public static Users Read(string connStr, string u_username)
        {
            Users u = new Users();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT u_id, ut_name, u_username, u_password, u_login_time, u_logout_time, u_login_status, u_r_id FROM db_kampus.users "+
            "INNER JOIN user_type ON user_type.ut_id = u_ut_id "+
            "WHERE (u_username = '@"+u_username+"')";

            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _datareader = _command.ExecuteReader();
            if(_datareader.Read().Equals(true))
            {
                u.u_id = _datareader.GetInt32(0);
                u.ut_name = _datareader.GetString(1);
                u.u_username = _datareader.GetString(2).Replace("@", "");
                u.u_password = _datareader.GetString(3);
                u.u_login_time = _datareader.GetDateTime(4).ToString("dd/MM/yyyy HH:mm:ss");
                u.u_logout_time = _datareader.GetDateTime(5).ToString("dd/MM/yyyy HH:mm:ss");
                u.u_login_status = _datareader.GetInt16(6);
                u.u_r_id = _datareader.IsDBNull(7) ? (int?)null :_datareader.GetInt32(7);
            }
            _conn.Close();
            return u;
        }
        ///<summary>
        /// User Login
        ///</summary>
        public static int LoginUpdate(string connStr, int u_id)
        {
            int edited = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "UPDATE `db_kampus`.`users` SET `u_login_time` = '"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"', `u_login_status` = '1' WHERE (`u_id` = '"+u_id+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;
            edited = _cmd.ExecuteNonQuery();

            _conn.Close();
            return edited;
        }
        ///<summary>
        /// User Logout
        ///</summary>
        public static int LogoutUpdate(string connStr, int u_id)
        {
            int edited = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "UPDATE `db_kampus`.`users` SET `u_logout_time` = '"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"', `u_login_status` = '0' WHERE (`u_id` = '"+u_id+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;
            edited = _cmd.ExecuteNonQuery();

            _conn.Close();
            return edited;
        }
        // ===============================================================================================

        // Add user_type Combo Box
        public static List<Users> ReadList(string connStr)
        {
            List<Users> u = new List<Users>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.user_type;";

            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _command.ExecuteReader();
            while (_data.Read())
            {
                u.Add(new Users {
                    ut_id = _data.GetInt32(0),
                    ut_name = _data.GetString(1),
                    ut_desc = _data.GetString(2)
                });
            }
            _conn.Close();
            return u;
        }

        // Create users
        public static int Create(string connStr, Users u)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            
            string sqlRoleCol = string.Empty, sqlRoleVal = string.Empty;
            if(!u.u_r_id.Equals(null))
            {
                sqlRoleCol = "`u_r_id`,";
                sqlRoleVal = "'"+u.u_r_id+"',";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`users`"+
            " (`u_id`, `u_ut_id`,"+sqlRoleCol+" `u_username`, `u_password`, `u_login_time`, `u_logout_time`, `u_login_status`, `u_rec_status`, `u_rec_creator`, `u_rec_created`)"+
            " VALUES ('"+u.u_id+"', '"+u.u_ut_id+"',"+sqlRoleVal+" '@"+u.u_username+"', '"+u.u_password+"', '"+u.u_login_time+"', '"+u.u_logout_time+"', '"+u.u_login_status+"', '"+u.u_rec_status+"', '"+u.u_rec_creator+"', '"+u.u_rec_created+"');";
            
            using var _command = new MySqlCommand(sqlStr, _connection);
            affectedRow = _command.ExecuteNonQuery();

            _connection.Close();
            return affectedRow;
        }

        public static int CreateAlive(MySqlConnection _conn, Users u)
        {
            int affectedRow = 0;
            string sqlRoleCol = string.Empty, sqlRoleVal = string.Empty;
            if(!u.u_r_id.Equals(null))
            {
                sqlRoleCol = "`u_r_id`,";
                sqlRoleVal = "'"+u.u_r_id+"',";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`users`"+
            " (`u_id`, `u_ut_id`,"+sqlRoleCol+" `u_username`, `u_password`, `u_login_time`, `u_logout_time`, `u_login_status`, `u_rec_status`, `u_rec_creator`, `u_rec_created`)"+
            " VALUES ('"+u.u_id+"', '"+u.u_ut_id+"',"+sqlRoleVal+" '@"+u.u_username+"', '"+u.u_password+"', '"+u.u_login_time+"', '"+u.u_logout_time+"', '"+u.u_login_status+"', '"+u.u_rec_status+"', '"+u.u_rec_creator+"', '"+u.u_rec_created+"');";
            
            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }
        // Update users table
        public static int Update(string connStr, int u_id, Users u)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            
            string sqlPass = "", sqlRole = "";
            if(!u.u_r_id.Equals(null)) sqlRole = "`u_r_id` = '"+u.u_r_id+"', ";
            if(!u.u_password.Equals(null)) sqlPass = ", `u_password` = '"+u.u_password+"'";

            string sqlStr = "UPDATE `db_kampus`.`users` SET "+sqlRole+"`u_username` = '"+u.u_username+"'"+sqlPass+", `u_rec_updator` = '"+u.u_rec_updator+"', `u_rec_updated` = '"+u.u_rec_updated+"' WHERE (`u_id` = '"+u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
        public static int UpdateAlive(MySqlConnection _conn, int u_id, Users u)
        {
            int affectedRow = 0;
            
            string sqlPass = "", sqlRole = "";
            if(!u.u_r_id.Equals(null)) sqlRole = "`u_r_id` = '"+u.u_r_id+"', ";
            if(!u.u_password.Equals(null)) sqlPass = ", `u_password` = '"+u.u_password+"'";

            string sqlStr = "UPDATE `db_kampus`.`users` SET "+sqlRole+"`u_username` = '"+u.u_username+"'"+sqlPass+", `u_rec_updator` = '"+u.u_rec_updator+"', `u_rec_updated` = '"+u.u_rec_updated+"' WHERE (`u_id` = '"+u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        // Delete users table
        public static int Delete(string connStr, int u_id)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            string sqlStr = "DELETE FROM `db_kampus`.`users` WHERE (`u_id` = '"+u_id+"');";

            using var _command = new MySqlCommand(sqlStr, _connection);
            affectedRow = _command.ExecuteNonQuery();

            _connection.Close();
            return affectedRow;
        }
        public static int DeleteAlive(MySqlConnection _conn, int u_id)
        {
            int affectedRow = 0;

            string sqlStr = "DELETE FROM `db_kampus`.`users` WHERE (`u_id` = '"+u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }
    }
}