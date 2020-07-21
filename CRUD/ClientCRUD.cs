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
    public sealed class ClientCRUD
    {
        public static List<Client> ReadAll(string connStr)
        {
            List<Client> clients = new List<Client>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT c.c_u_id, c.c_code, u.u_username, c.c_name, c.c_remark"+
            " FROM `db_kampus`.`client` c INNER JOIN `db_kampus`.`users` u ON u.u_id = c.c_u_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while(_data.Read())
            {
                clients.Add(new Client {
                    c_u_id = _data.GetInt32(0),
                    c_code = _data.GetString(1),
                    u_username = _data.GetString(2),
                    c_name = _data.GetString(3),
                    c_remark = _data.GetString(4)
                });
            }
            _conn.Close();
            return clients;
        }

        public static Client Read(string connStr, int c_u_id)
        {
            Client c = new Client();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT c.c_id, c.c_u_id, u.u_username, c.c_name, c.c_remark"+
            " FROM `db_kampus`.`client` c INNER JOIN `db_kampus`.`users` u ON u.u_id = c.c_u_id"+
            " WHERE (`c_u_id` = '"+c_u_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read().Equals(true))
            {
                c.c_id = _data.GetInt32(0);
                c.c_u_id = _data.GetInt32(1);
                c.u_username = _data.GetString(2);
                c.c_name = _data.GetString(3);
                c.c_remark = _data.GetString(4);
            }
            _conn.Close();
            return c;
        }

        public static int CreateAlive(MySqlConnection _conn, Client c)
        {
            int affectedRow = 0;
            string sqlStr = "INSERT INTO `db_kampus`.`client` (`c_id`,`c_u_id`,`c_code`,`c_name`,`c_remark`)"+
            " VALUES ('"+c.c_id+"','"+c.c_u_id+"','"+c.c_code+"','"+c.c_name+"','"+c.c_remark+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool CreateClientAndUser(string connStr, Client c, Users u)
        {
            bool result = false;
            MySqlConnection _conn = null;
            MySqlCommand _cmd = null;
            MySqlTransaction sqlTrans = null;
            try
            {
                _cmd = new MySqlCommand();
                _conn = new MySqlConnection(connStr);
                _conn.Open();
                sqlTrans = _conn.BeginTransaction();
                _cmd.Transaction = sqlTrans;

                int affectedRow = 0;
                affectedRow += UserCRUD.CreateAlive(_conn, u);
                affectedRow += CreateAlive(_conn, c);

                if(affectedRow != 2) throw new Exception();

                sqlTrans.Commit();
                result = true;
            }
            catch (Exception e)
            {
                sqlTrans.Rollback();
                throw e;
            }
            finally
            {
                if(sqlTrans != null)
                {
                    sqlTrans.Dispose();
                    sqlTrans = null;
                }

                if(_conn != null)
                {
                    _conn.Close();
                    _conn = null;
                    _cmd = null;
                }
            }
            return result;
        }

        public static int UpdateAlive(MySqlConnection _conn, Client c)
        {
            int affectedRow = 0;
            string sqlStr = "UPDATE `db_kampus`.`client` SET `c_code` = '"+c.c_code+"', `c_name` = '"+c.c_name+"', `c_remark` = '"+c.c_remark+"' "+
            "WHERE (`c_id` = '"+c.c_id+"' AND `c_u_id` = '"+c.c_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool UpdateClientAndUser(string connStr, Client c, Users u)
        {
            bool result = false;
            MySqlConnection _conn = null;
            MySqlCommand _cmd = null;
            MySqlTransaction sqlTrans = null;
            try
            {
                _cmd = new MySqlCommand();
                _conn = new MySqlConnection(connStr);
                _conn.Open();
                sqlTrans = _conn.BeginTransaction();
                _cmd.Transaction = sqlTrans;

                int affectedRow = 0;
                affectedRow += UserCRUD.UpdateAlive(_conn, (int)u.u_id, u);
                affectedRow += UpdateAlive(_conn, c);

                if(affectedRow != 2) throw new Exception();

                sqlTrans.Commit();
                result = true;
            }
            catch (Exception e)
            {
                sqlTrans.Rollback();
                throw e;
            }
            finally
            {
                if(sqlTrans != null)
                {
                    sqlTrans.Dispose();
                    sqlTrans = null;
                }

                if(_conn != null)
                {
                    _conn.Close();
                    _conn = null;
                    _cmd = null;
                }
            }
            return result;
        }

        public static int DeleteAlive(MySqlConnection _conn, int c_u_id)
        {
            int affectedRow = 0;
            string sqlStr = "DELETE FROM `db_kampus`.`client` WHERE (`c_u_id` = '"+c_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool DeleteClientAndUser(string connStr, Client c, Users u)
        {
            bool result = false;
            MySqlConnection _conn = null;
            MySqlCommand _cmd = null;
            MySqlTransaction sqlTrans = null;
            try
            {
                _cmd = new MySqlCommand();
                _conn = new MySqlConnection(connStr);
                _conn.Open();
                sqlTrans = _conn.BeginTransaction();
                _cmd.Transaction = sqlTrans;

                int affectedRow = 0;
                affectedRow += DeleteAlive(_conn, (int)c.c_u_id);
                affectedRow += UserCRUD.DeleteAlive(_conn, (int)u.u_id);

                if(affectedRow != 2) throw new Exception();

                sqlTrans.Commit();
                result = true;
            }
            catch (Exception e)
            {
                sqlTrans.Rollback();
                throw e;
            }
            finally
            {
                if(sqlTrans != null)
                {
                    sqlTrans.Dispose();
                    sqlTrans = null;
                }

                if(_conn != null)
                {
                    _conn.Close();
                    _conn = null;
                    _cmd = null;
                }
            }
            return result;
        }
    }
}