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
    public sealed class SiteCRUD
    {
        public static List<Site> ReadAll(string connStr)
        {
            List<Site> ust = new List<Site>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            
            string sqlStr = "SELECT ust.s_u_id, u.u_username, ust.s_fullname, ust.s_nik, ust.s_stat, "+
                            " (SELECT up_photo FROM db_kampus.user_photo WHERE ust.s_u_id = up_u_id) AS up_photo, "+
                            " (SELECT up_filename FROM db_kampus.user_photo WHERE ust.s_u_id = up_u_id) AS up_filename, "+
                            " (SELECT r_desc FROM db_kampus.role WHERE u.u_r_id = r_id) AS r_desc" +
                            " FROM `db_kampus`.`site` ust INNER JOIN `db_kampus`.`users` u ON u.u_id = ust.s_u_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Site s = new Site();
                    if(dr["up_filename"] != DBNull.Value)
                    {
                        s.up_photo = (byte[])dr["up_photo"];
                        s.up_filename = (string)dr["up_filename"];
                    }
                    s.s_u_id = (int)dr["s_u_id"];
                    s.u_username = dr["u_username"].ToString().Replace("@","");
                    s.s_fullname = (string)dr["s_fullname"];
                    s.s_nik = (string)dr["s_nik"];
                    s.r_desc = (string)dr["r_desc"];
                    s.s_stat = (short)dr["s_stat"];
                    ust.Add(s);
                }
            }

            _conn.Close();
            return ust;
        }

        public static Site Read(string connStr, int s_u_id)
        {
            Site ust = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT s.s_id, s.s_u_id, s.s_fullname, s.s_nik, s.s_address, s.s_province, s.s_city, s.s_birthplace, s.s_birthdate, s.s_gender, s.s_religion, s.s_state, s.s_email, s.s_stat, s.s_contact, u.u_ut_id, u.u_r_id, u.u_username,"+ 
                            " (SELECT up_photo FROM db_kampus.user_photo WHERE s.s_u_id = up_u_id) AS up_photo, "+
                            " (SELECT up_filename FROM db_kampus.user_photo WHERE s.s_u_id = up_u_id) AS up_filename, "+
                            " (SELECT r_desc FROM db_kampus.role WHERE u.u_r_id = r_id) AS r_desc"+
                            " FROM db_kampus.site s INNER JOIN users u ON s.s_u_id = u.u_id"+
                            " WHERE s.s_u_id = '"+s_u_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ust = new Site();
                if (dt.Rows[0]["up_filename"] != DBNull.Value)
                {
                    ust.up_photo = (byte[])dt.Rows[0]["up_photo"];
                    ust.up_filename = (string)dt.Rows[0]["up_filename"];
                }
                ust.s_id = (int)dt.Rows[0]["s_id"];
                ust.s_u_id = (int)dt.Rows[0]["s_u_id"];
                ust.s_fullname = (string)dt.Rows[0]["s_fullname"];
                ust.s_nik = (string)dt.Rows[0]["s_nik"];
                ust.s_address = (string)dt.Rows[0]["s_address"];
                ust.s_province = (string)dt.Rows[0]["s_province"];
                ust.s_city = (string)dt.Rows[0]["s_city"];
                ust.s_birthplace = (string)dt.Rows[0]["s_birthplace"];
                ust.s_birthdate = Convert.ToDateTime(dt.Rows[0]["s_birthdate"]).ToString("yyyy-MM-dd");
                ust.s_gender = (string)dt.Rows[0]["s_gender"];
                ust.s_religion = (string)dt.Rows[0]["s_religion"];
                ust.s_state = (string)dt.Rows[0]["s_state"];
                ust.s_email = (string)dt.Rows[0]["s_email"];
                ust.s_stat = (short)dt.Rows[0]["s_stat"];
                ust.s_contact = (string)dt.Rows[0]["s_contact"];
                ust.u_ut_id = (int)dt.Rows[0]["u_ut_id"];
                ust.u_username = dt.Rows[0]["u_username"].ToString().Replace("@","");
                ust.u_r_id = (int)dt.Rows[0]["u_r_id"];
                ust.r_desc = (string)dt.Rows[0]["r_desc"];
            }

            _conn.Close();
            return ust;
        }

        public static int CreateAlive(MySqlConnection _conn, Site s)
        {
            int affectedRow = 0;
            string sqlc_idCol = "", sqlc_idVal = "";
            if(!s.s_c_id.Equals(null))
            {
                sqlc_idCol = "`s_c_id`, ";
                sqlc_idVal = "'"+s.s_c_id+"', ";
            }
            string sqlStr = "INSERT INTO `db_kampus`.`site`"+
                            " (`s_id`, `s_u_id`, "+sqlc_idCol+"`s_fullname`, `s_nik`, `s_address`, `s_province`, `s_city`, `s_birthplace`, `s_birthdate`, `s_gender`, `s_religion`, `s_state`, `s_email`, `s_stat`, `s_contact`)"+
                            " VALUES ('"+s.s_id +"', '"+s.s_u_id+"', "+sqlc_idVal+"'"+s.s_fullname+"', '"+s.s_nik+"', '"+s.s_address+"', '"+s.s_province+"', '"+s.s_city+"', '"+s.s_birthplace+"', '"+s.s_birthdate+"', '"+s.s_gender+"', '"+s.s_religion+"', '"+s.s_state+"', '"+s.s_email+"', '"+s.s_stat+"', '"+s.s_contact+"')";
            Console.WriteLine("\n SQLquery >> {0}", sqlStr);

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool CreateSiteAndUser(string connStr, Site s, Users u, Role r, RolePreviledge rp, UserPhoto up = null)
        {
            bool result = false;
            Random rand = null;
            MySqlConnection _conn = null;
            MySqlCommand _cmd = null;
            MySqlTransaction sqlTrans = null;
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
                s.s_id = rand.Next(int.MinValue, int.MaxValue);
                s.s_u_id = u.u_id;
                r.r_s_id = s.s_id;
                rp.rp_id = rand.Next(int.MinValue, int.MaxValue);
                rp.rp_r_id = r.r_id;

                Console.WriteLine("\nCreating Data :");
                affectedRows += RoleCRUD.CreateAlive(_conn, r);
                Console.WriteLine("\n Role : {0}", affectedRows);
                affectedRows += UserCRUD.CreateAlive(_conn, u);
                Console.WriteLine("\n Users : {0}", affectedRows);
                if(up != null)
                {
                    up.up_id = rand.Next(int.MinValue, int.MaxValue);
                    up.up_u_id = u.u_id;
                    affectedRows += UserCRUD.CreatePhotoAlive(_conn, up);
                    Console.WriteLine("\n Photo : {0}", affectedRows);
                }
                affectedRows += CreateAlive(_conn, s);
                Console.WriteLine("\n Site : {0}", affectedRows);
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

        public static int UpdateAlive(MySqlConnection _conn, int s_id, int s_u_id, Site s)
        {
            int affectedRow = 0;

            string sqlStr = "UPDATE `db_kampus`.`site` SET "+
                            "`s_fullname` = '"+s.s_fullname+"',`s_nik` = '"+s.s_nik+"',`s_address` = '"+s.s_address+"',`s_province` = '"+s.s_province+"',`s_city` = '"+s.s_city+"',`s_birthplace` = '"+s.s_birthplace+"',`s_birthdate` = '"+s.s_birthdate+"',`s_gender` = '"+s.s_gender+"',`s_state` = '"+s.s_state+"',`s_email` = '"+s.s_email+"',`s_stat` = "+s.s_stat+",`s_contact` = '"+s.s_contact+"' "+
                            "WHERE (`s_id` = '"+s_id+"' AND `s_u_id` = '"+s_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool UpdateSiteAndUser(string connStr, Site s, Users u, UserPhoto up = null, Role r = null)
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

                int affectedRows = 0;
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
                            affectedRows += UserCRUD.CreatePhotoAlive(_conn, up);
                            Console.WriteLine("\n Image Create Success");
                        }
                        // Update
                        else
                        {
                            Console.WriteLine("\n Image Update");
                            affectedRows += UserCRUD.UpdatePhotoAlive(_conn, (int)u.u_id, up);
                            Console.WriteLine("\n Image Update Success");
                        }
                    }
                    // Delete
                    else
                    {
                        Console.WriteLine("\n Image Delete");
                        if (up.up_id == null) throw new Exception("Unknown operation of image because either photo data and ID is null");
                        affectedRows += UserCRUD.DeletePhotoAlive(_conn, (int)u.u_id, (int)up.up_id);
                        Console.WriteLine("\n Image Delete Success");
                    }
                }
                if (r != null) affectedRows += RoleCRUD.UpdateAlive(_conn, (int)u.u_r_id, r);
                affectedRows += UserCRUD.UpdateAlive(_conn, (int)u.u_id, u);
                affectedRows += UpdateAlive(_conn, (int)s.s_id, (int)s.s_u_id, s);

                if(affectedRows != 4-(up == null ? 1 : 0)-(r == null ? 1 : 0)) throw new Exception();

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

        public static int DeleteAlive(MySqlConnection _conn, int s_u_id)
        {
            int affectedRow = 0;

            string sqlStr = "DELETE FROM `db_kampus`.`site` WHERE (s_u_id = '"+s_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool DeleteSiteAndUser(string connStr, Site s, Users u)
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
                affectedRow += DeleteAlive(_conn, (int)s.s_u_id);
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