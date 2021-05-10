using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
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
        public static async Task<List<Users>> ReadAllActivityAsync(string connStr)
        {
            List<Users> u = new List<Users>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT * FROM db_kampus.users u " +
                            "INNER JOIN db_kampus.user_type ut ON u.u_ut_id = ut.ut_id;";
            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _dtrdr = await Task.Run(() => _command.ExecuteReader());
            while(_dtrdr.Read())
            {
                u.Add(new Users {
                    u_id = _dtrdr.GetInt32("u_id"),
                    u_username = _dtrdr.GetString("u_username"),
                    u_login_time = _dtrdr.GetDateTime("u_login_time").ToString("dd/MM/yyyy HH:mm:ss"),
                    u_logout_time = _dtrdr.GetDateTime("u_logout_time").ToString("dd/MM/yyyy HH:mm:ss"),
                    u_login_status = _dtrdr.GetInt16("u_login_status"),
                    //user_type
                    ut_name = _dtrdr.GetString("ut_name")
                });
            }
            _conn.Close();
            return u;
        }

        public static Users ReadRole(string connStr, int u_id)
        {
            Users u = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT * FROM db_kampus.users WHERE (`u_id`='"+u_id+"')";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();

            if (_data.Read() && !_data.IsDBNull("u_r_id"))
            {
                u = new Users();
                u.u_id = _data.GetInt32("u_id");
                u.u_r_id = _data.GetInt32("u_r_id");
            }

            _conn.Close();
            return u;
        }

        public static Object ReadTotalUser(string connStr)
        {
            Object users = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT COUNT(*) AS total_users, " +
                            "(SELECT COUNT(*) FROM db_kampus.users WHERE u_ut_id = 2) AS total_rektor, " +
                            "(SELECT COUNT(*) FROM db_kampus.users WHERE u_ut_id = 3) AS total_staff, " +
                            "(SELECT COUNT(*) FROM db_kampus.users WHERE u_ut_id = 4) AS total_mhs " +
                            "FROM db_kampus.users WHERE u_ut_id < 5;";
            
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();

            if (_data.Read())
            {
                users = new {
                    total_users = _data.GetInt32("total_users"),
                    total_rektor = _data.GetInt32("total_rektor"),
                    total_staff = _data.GetInt32("total_staff"),
                    total_mhs = _data.GetInt32("total_mhs")
                };
            }

            _conn.Close();
            return users;
        }

        // ===============================================================================================
        // Login CRUD
        // ===============================================================================================
        #region Login
        ///<summary>
        /// Login Page Read
        ///</summary>
        public static async Task<Users> ReadAsync(string connStr, string u_username)
        {
            Users u = new Users();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT * FROM db_kampus.users "+
            "INNER JOIN user_type ON user_type.ut_id = u_ut_id "+
            "WHERE (u_username = '@"+u_username+"')";

            using var _command = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _datareader = await Task.Run(() => _command.ExecuteReader());
            if (!_datareader.HasRows) throw new Exception("Username Tidak ada!");

            if (_datareader.ReadAsync().Result == true)
            {
                u.u_id = _datareader.GetInt32("u_id");
                u.ut_name = _datareader.GetString("ut_name");
                u.u_username = _datareader.GetString("u_username").Replace("@", "");
                u.u_password = _datareader.GetString("u_password");
                u.u_login_time = _datareader.GetDateTime("u_login_time").ToString("dd/MM/yyyy HH:mm:ss");
                u.u_logout_time = _datareader.GetDateTime("u_logout_time").ToString("dd/MM/yyyy HH:mm:ss");
                u.u_login_status = _datareader.GetInt16("u_login_status");
                u.u_r_id = _datareader.IsDBNull("u_r_id") ? (int?)null :_datareader.GetInt32("u_r_id");
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

            using var _cmd = new MySqlCommand(sqlStr, _conn);
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
        #endregion
        // ===============================================================================================

        // Add user_type Combo Box
        // public static List<Users> ReadList(string connStr)
        // {
        //     List<Users> u = new List<Users>();
        //     using var _conn = new MySqlConnection(connStr);
        //     _conn.Open();
        //     string sqlStr = "SELECT * FROM db_kampus.user_type;";

        //     using var _command = new MySqlCommand(sqlStr, _conn);
        //     using MySqlDataReader _data = _command.ExecuteReader();
        //     while (_data.Read())
        //     {
        //         u.Add(new Users {
        //             ut_id = _data.GetInt32(0),
        //             ut_name = _data.GetString(1),
        //             ut_desc = _data.GetString(2)
        //         });
        //     }
        //     _conn.Close();
        //     return u;
        // }

        // Create users
        public static int Create(string connStr, Users u)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            
            string sqlRoleCol = string.Empty, sqlRoleVal = string.Empty;
            if(u.u_r_id != null)
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
            if(u.u_r_id != null)
            {
                sqlRoleCol = "`u_r_id`,";
                sqlRoleVal = "'"+u.u_r_id+"',";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`users`"+
            " (`u_id`, `u_ut_id`,"+sqlRoleCol+" `u_username`, `u_password`, `u_login_time`, `u_logout_time`, `u_login_status`, `u_rec_status`, `u_rec_creator`, `u_rec_created`)"+
            " VALUES ('"+u.u_id+"', '"+u.u_ut_id+"',"+sqlRoleVal+" '@"+u.u_username+"', '"+u.u_password+"', '"+u.u_login_time+"', '"+u.u_logout_time+"', '"+u.u_login_status+"', '"+u.u_rec_status+"', '"+u.u_rec_creator+"', '"+u.u_rec_created+"');";
            // Console.WriteLine("\n User Create : {0}", sqlStr);
            
            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static int ReadUsername(string connStr, string username)
        {
            int rowReturned = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT u_username FROM db_kampus.users WHERE u_username = '@"+username+"';";
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();

            if (_data.HasRows) rowReturned = 1;

            _conn.Close();
            return rowReturned;
        }

        public static int? ReadPhoto(string connStr, int up_u_id)
        {
            int? photoId = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT up_id FROM db_kampus.user_photo WHERE up_u_id = '"+up_u_id+"'";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();

            if(_data.Read()) photoId = _data.GetInt32("up_id");

            _conn.Close();
            return photoId;
        }

        public static int CreatePhoto(string connStr, UserPhoto up)
        {
            int affectedRow = 0;
            Random rand = new Random();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr =
                "INSERT INTO `db_kampus`.`user_photo` (`up_id`,`up_u_id`,`up_photo`,`up_filename`,`up_rec_status`) "+
                "VALUES ('"+rand.Next(int.MinValue, int.MaxValue)+"','"+up.up_u_id+"','@photo','"+up.up_filename+"','"+up.up_rec_status+"')";
            
            using var _cmd = new MySqlCommand();
            _cmd.Connection = _conn;
            _cmd.Parameters.Add("@photo", MySqlDbType.Blob, up.up_photo.Length).Value = up.up_photo;
            _cmd.CommandText = sqlStr;

            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int CreatePhotoAlive(MySqlConnection _conn, UserPhoto up)
        {
            int affectedRow = 0;
            string sqlStr = 
                "INSERT INTO `db_kampus`.`user_photo` "+
                "(`up_id`,`up_u_id`,`up_photo`,`up_filename`,`up_rec_status`) "+
                "VALUES ('"+up.up_id+"','"+up.up_u_id+"','"+up.up_photo+"','"+up.up_filename+"','"+up.up_rec_status+"')";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            if(affectedRow == 1) affectedRow = UpdatePhotoAlive(_conn, (int)up.up_u_id, up);
            return affectedRow;
        }

        public static int UpdatePhotoAlive(MySqlConnection _conn, int u_id, UserPhoto up)
        {
            int affectedRow = 0;
            string sqlStr =
                "UPDATE `db_kampus`.`user_photo` SET "+
                "`up_photo` = '"+up.up_photo+"', `up_filename` = '"+up.up_filename+"' "+
                "WHERE up_u_id = '"+u_id+"'";
            
            using var _cmd = new MySqlCommand();
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            _cmd.CommandText = sqlStr;
            affectedRow = _cmd.ExecuteNonQuery();

            if(affectedRow == 1)
            {
                sqlStr = "UPDATE `db_kampus`.`user_photo` SET `up_photo` = @photo" +
                            " WHERE up_u_id = "+ u_id.ToString();
                _cmd.Parameters.Add("@photo", MySqlDbType.Blob, up.up_photo.Length).Value = up.up_photo;
                _cmd.CommandText = sqlStr;
                affectedRow = _cmd.ExecuteNonQuery();
                _cmd.Parameters.Clear();
            }
            return affectedRow;
        }

        public static int DeletePhotoAlive(MySqlConnection _conn, int u_id, int up_id)
        {
            int affectedRow = 0;
            string sqlStr =
                "DELETE FROM `db_kampus`.`user_photo` WHERE up_u_id = " + u_id.ToString() + " AND up_id = " + up_id.ToString();

            using var _cmd = new MySqlCommand();
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            _cmd.CommandText = sqlStr;
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
            if(u.u_r_id != null) sqlRole = "`u_r_id` = '"+u.u_r_id+"', ";
            if(u.u_password != null) sqlPass = ", `u_password` = '"+u.u_password+"'";

            string sqlStr = "UPDATE `db_kampus`.`users` SET "+sqlRole+"`u_username` = '@"+u.u_username+"'"+sqlPass+", `u_rec_updator` = '"+u.u_rec_updator+"', `u_rec_updated` = '"+u.u_rec_updated+"' WHERE (`u_id` = '"+u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int UpdateAlive(MySqlConnection _conn, int u_id, Users u)
        {
            int affectedRow = 0;
            
            string sqlPass = "", sqlRole = "";
            if(u.u_r_id != null) sqlRole = "`u_r_id` = '"+u.u_r_id+"', ";
            if(u.u_password != null) sqlPass = ", `u_password` = '"+u.u_password+"'";

            string sqlStr = "UPDATE `db_kampus`.`users` SET "+sqlRole+"`u_username` = '@"+u.u_username+"'"+sqlPass+", `u_rec_updator` = '"+u.u_rec_updator+"', `u_rec_updated` = '"+u.u_rec_updated+"' WHERE (`u_id` = '"+u_id+"');";
            
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