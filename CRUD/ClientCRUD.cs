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

            string sqlStr = "SELECT c.c_u_id, c.c_code, u.u_username, c.c_name, c.c_remark, "+
            " (SELECT up_photo FROM db_kampus.user_photo WHERE c.c_u_id = up_u_id) AS up_photo, "+
            " (SELECT up_filename FROM db_kampus.user_photo WHERE c.c_u_id = up_u_id) AS up_filename "+
            " FROM `db_kampus`.`client` c INNER JOIN `db_kampus`.`users` u ON u.u_id = c.c_u_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Client c = new Client();
                    if(dr["up_filename"] != DBNull.Value)
                    {
                        c.up_photo = (byte[])dr["up_photo"];
                        c.up_filename = (string)dr["up_filename"];
                    }
                    c.c_u_id = (int)dr["c_u_id"];
                    c.c_code = (string)dr["c_code"];
                    c.u_username = dr["u_username"].ToString().Replace("@","");
                    c.c_name = (string)dr["c_name"];
                    c.c_remark = (string)dr["c_remark"];
                    clients.Add(c);
                }
            }

            _conn.Close();
            return clients;
        }

        public static Client Read(string connStr, int c_u_id)
        {
            Client c = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT c.c_id, c.c_u_id, u.u_username, c.c_name, c.c_remark, "+
            " (SELECT up_photo FROM db_kampus.user_photo WHERE c.c_u_id = up_u_id) AS up_photo, "+
            " (SELECT up_filename FROM db_kampus.user_photo WHERE c.c_u_id = up_u_id) AS up_filename "+
            " FROM `db_kampus`.`client` c INNER JOIN `db_kampus`.`users` u ON u.u_id = c.c_u_id"+
            " WHERE (`c_u_id` = '"+c_u_id+"');";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            // using MySqlDataReader _data = _cmd.ExecuteReader();
            // if(_data.Read().Equals(true))
            // {
            //     c.c_id = _data.GetInt32(0);
            //     c.c_u_id = _data.GetInt32(1);
            //     c.u_username = _data.GetString(2);
            //     c.c_name = _data.GetString(3);
            //     c.c_remark = _data.GetString(4);
            // }
            DataTable dt = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                c = new Client();
                if(dt.Rows[0]["up_filename"] != DBNull.Value)
                {
                    c.up_photo = (byte[])dt.Rows[0]["up_photo"];
                    c.up_filename = (string)dt.Rows[0]["up_filename"];
                }
                c.c_id = (int)dt.Rows[0]["c_id"];
                c.c_u_id = (int)dt.Rows[0]["c_u_id"];
                c.u_username = dt.Rows[0]["u_username"].ToString().Replace("@","");
                c.c_name = (string)dt.Rows[0]["c_name"];
                c.c_remark = (string)dt.Rows[0]["c_remark"];
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

        public static bool CreateClientAndUser(string connStr, Client c, Users u, Role r, RolePreviledge rp, UserPhoto up = null)
        {
            bool result = false;
            MySqlConnection _conn = null;
            MySqlCommand _cmd = null;
            MySqlTransaction sqlTrans = null;
            Random rand = null;
            try
            {
                rand = new Random();
                _cmd = new MySqlCommand();
                _conn = new MySqlConnection(connStr);
                _conn.Open();
                sqlTrans = _conn.BeginTransaction();
                _cmd.Transaction = sqlTrans;

                int affectedRows = 0;

                u.u_id = rand.Next(int.MinValue, int.MaxValue);
                r.r_id = rand.Next(int.MinValue, int.MaxValue);
                u.u_r_id = r.r_id;
                c.c_id = rand.Next(int.MinValue, int.MaxValue);
                c.c_u_id = u.u_id;
                r.r_c_id = c.c_id;
                rp.rp_id = rand.Next(int.MinValue, int.MaxValue);
                rp.rp_r_id = r.r_id;

                Console.WriteLine("\nCreating Data :");
                affectedRows += RoleCRUD.CreateAlive(_conn, r);
                Console.WriteLine("\n Role : {0}", affectedRows);
                affectedRows += UserCRUD.CreateAlive(_conn, u);
                Console.WriteLine("\n Users : {0}", affectedRows);
                if (up != null)
                {
                    up.up_id = rand.Next(int.MinValue, int.MaxValue);
                    up.up_u_id = u.u_id;
                    affectedRows += UserCRUD.CreatePhotoAlive(_conn, up);
                    Console.WriteLine("\n Photo : {0}", affectedRows);
                }
                affectedRows += CreateAlive(_conn, c);
                Console.WriteLine("\n Client : {0}", affectedRows);
                affectedRows += RolePreviledgeCRUD.CreateAlive(_conn, rp);
                Console.WriteLine("\n RolePreviledge : {0}", affectedRows);

                if(affectedRows != 5-(up == null ? 1 : 0)) throw new Exception();

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
            string sqlStr = "UPDATE `db_kampus`.`client` SET `c_name` = '"+c.c_name+"', `c_remark` = '"+c.c_remark+"' "+
            "WHERE (`c_id` = '"+c.c_id+"' AND `c_u_id` = '"+c.c_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool UpdateClientAndUser(string connStr, Client c, Users u, UserPhoto up = null)
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
                if (up != null)
                {
                    // Create or Update
                    if (up.up_photo != null)
                    {
                        // Create
                        if (up.up_id == null)
                        {
                            Console.WriteLine("\n Image Create");
                            up.up_id = new Random().Next(int.MinValue, int.MaxValue);
                            up.up_u_id = u.u_id;
                            up.up_rec_status = 1;
                            affectedRow += UserCRUD.CreatePhotoAlive(_conn, up);
                            Console.WriteLine("\n Image Create Success");
                        }
                        // Update
                        else
                        {
                            Console.WriteLine("\n Image Update");
                            affectedRow += UserCRUD.UpdatePhotoAlive(_conn, (int)u.u_id, up);
                            Console.WriteLine("\n Image Update Success");
                        }
                    }
                    // Delete
                    else
                    {
                        // Console.WriteLine("\n Image Delete");
                        if (up.up_id == null) throw new Exception("Unknown operation of image because either photo data and ID is null");
                        // Console.WriteLine("\n Image Delete Success");
                    }
                }
                affectedRow += UserCRUD.UpdateAlive(_conn, (int)u.u_id, u);
                affectedRow += UpdateAlive(_conn, c);

                if(affectedRow != 3-(up == null ? 1 : 0)) throw new Exception();

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
                affectedRow += RoleCRUD.DeleteAlive(_conn, (int)u.u_r_id);

                if(affectedRow != 3) throw new Exception();

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