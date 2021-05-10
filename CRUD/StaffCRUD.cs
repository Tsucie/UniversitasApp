using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class StaffCRUD
    {
        // Read All staff Table
        public static List<UserStaff> ReadAll(string connStr)
        {
            List<UserStaff> us = new List<UserStaff>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT stf.stf_u_id, stf.stf_fullname, stf.stf_nik, stf.stf_stat, sc.sc_name,  "+
                            "(SELECT up_photo FROM db_kampus.user_photo WHERE stf.stf_u_id = up_u_id) AS up_photo, "+
                            "(SELECT up_filename FROM db_kampus.user_photo WHERE stf.stf_u_id = up_u_id) AS up_filename, "+
                            "(SELECT u_username FROM db_kampus.users WHERE stf.stf_u_id = u_id) AS u_username "+
                            "FROM db_kampus.staff stf "+
                            "INNER JOIN db_kampus.staff_category sc ON stf.stf_sc_id = sc.sc_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    us.Add(new UserStaff {
                        stf_u_id = (int?)dr["stf_u_id"],
                        up_filename = (dr["up_filename"] == DBNull.Value) ? null : (string)dr["up_filename"],
                        up_photo = (dr["up_photo"] == DBNull.Value) ? null : (byte[])dr["up_photo"],
                        stf_fullname = (string)dr["stf_fullname"],
                        u_username = (string)dr["u_username"],
                        sc_name = (string)dr["sc_name"],
                        stf_nik = (string)dr["stf_nik"],
                        stf_stat = (short?)dr["stf_stat"]
                    });
                }
            }

            _conn.Close();
            return us;
        }

        public static UserStaff Read(string connStr, int stf_u_id)
        {
            UserStaff stf = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT stf.stf_id, stf.stf_u_id, stf.stf_sc_id, stf.stf_fullname, stf.stf_nik, stf.stf_address, stf.stf_province, stf.stf_city, stf.stf_birthplace, stf.stf_birthdate, stf.stf_gender, stf.stf_religion, stf.stf_state, stf.stf_email, stf.stf_stat, stf.stf_contact, u.u_id, u.u_ut_id, u.u_username, stf.stf_fks_id, stf.stf_ps_id, stf.stf_mk_id,"+
            " (SELECT up_photo FROM db_kampus.user_photo WHERE stf.stf_u_id = up_u_id) AS up_photo,"+
            " (SELECT up_filename FROM db_kampus.user_photo WHERE stf.stf_u_id = up_u_id) AS up_filename"+
            " FROM db_kampus.staff stf INNER JOIN users u ON stf.stf_u_id = u.u_id"+
            " WHERE stf.stf_u_id = '"+stf_u_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                stf = new UserStaff();
                if (dt.Rows[0]["up_filename"] != DBNull.Value)
                {
                    stf.up_photo = (byte[])dt.Rows[0]["up_photo"];
                    stf.up_filename = (string)dt.Rows[0]["up_filename"];
                }
                stf.stf_id = (int)dt.Rows[0]["stf_id"];
                stf.stf_u_id = (int)dt.Rows[0]["stf_u_id"];
                stf.stf_sc_id = (int)dt.Rows[0]["stf_sc_id"];
                stf.stf_fullname = (string)dt.Rows[0]["stf_fullname"];
                stf.stf_nik = (string)dt.Rows[0]["stf_nik"];
                stf.stf_address = (string)dt.Rows[0]["stf_address"];
                stf.stf_province = (string)dt.Rows[0]["stf_province"];
                stf.stf_city = (string)dt.Rows[0]["stf_city"];
                stf.stf_birthplace = (string)dt.Rows[0]["stf_birthplace"];
                stf.stf_birthdate = Convert.ToDateTime(dt.Rows[0]["stf_birthdate"]).ToString("yyyy-MM-dd");
                stf.stf_gender = (string)dt.Rows[0]["stf_gender"];
                stf.stf_religion = (string)dt.Rows[0]["stf_religion"];
                stf.stf_state = (string)dt.Rows[0]["stf_state"];
                stf.stf_email = (string)dt.Rows[0]["stf_email"];
                stf.stf_stat = (short)dt.Rows[0]["stf_stat"];
                stf.stf_contact = (string)dt.Rows[0]["stf_contact"];
                stf.u_id = (int)dt.Rows[0]["u_id"];
                stf.u_ut_id = (int)dt.Rows[0]["u_ut_id"];
                stf.u_username = dt.Rows[0]["u_username"].ToString().Replace("@","");
                stf.stf_fks_id = (dt.Rows[0]["stf_fks_id"] == DBNull.Value) ? (int?)null : (int)dt.Rows[0]["stf_fks_id"];
                stf.stf_ps_id = (dt.Rows[0]["stf_ps_id"] == DBNull.Value) ? (int?)null : (int)dt.Rows[0]["stf_ps_id"];
                stf.stf_mk_id = (dt.Rows[0]["stf_mk_id"] == DBNull.Value) ? (int?)null : (int)dt.Rows[0]["stf_mk_id"];
            }
            // using MySqlDataReader _data = _cmd.ExecuteReader();
            // if(_data.Read())
            // {
            //     stf = new UserStaff();
            //     stf.stf_id = _data.GetInt32(0);
            //     stf.stf_u_id = _data.GetInt32(1);
            //     stf.stf_sc_id = _data.GetInt32(2);
            //     stf.stf_fullname = _data.GetString(3);
            //     stf.stf_nik = _data.GetString(4);
            //     stf.stf_address = _data.GetString(5);
            //     stf.stf_province = _data.GetString(6);
            //     stf.stf_city = _data.GetString(7);
            //     stf.stf_birthplace = _data.GetString(8);
            //     stf.stf_birthdate = _data.GetDateTime(9).ToString("yyyy-MM-dd");
            //     stf.stf_gender = _data.GetString(10);
            //     stf.stf_religion = _data.GetString(11);
            //     stf.stf_state = _data.GetString(12);
            //     stf.stf_email = _data.GetString(13);
            //     stf.stf_stat = _data.GetInt16(14);
            //     stf.stf_contact = _data.GetString(15);
            //     stf.u_id = _data.GetInt32(16);
            //     stf.u_ut_id = _data.GetInt32(17);
            //     stf.u_username = _data.GetString(18).Replace("@","");
            //     stf.stf_fks_id = (_data.GetInt32(19).Equals(null)) ? (int?)null : _data.GetInt32(19);
            //     stf.stf_ps_id = (_data.GetInt32(20).Equals(null)) ? (int?)null : _data.GetInt32(20);
            //     stf.stf_mk_id = (_data.GetInt32(21).Equals(null)) ? (int?)null : _data.GetInt32(21);
            // }
            _conn.Close();
            return stf;
        }

        // Create staff Table
        public static int Create(string connStr, UserStaff stf)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            
            string sqlFksCol = "", sqlFksVal = "", sqlPsCol = "", sqlPsVal = "", sqlMkCol = "", sqlMkVal = "";
            if(stf.stf_fks_id != null)
            {
                sqlFksCol = "`stf_fks_id`, ";
                sqlFksVal = "'"+stf.stf_fks_id+"',";
            }
            if(stf.stf_ps_id != null)
            {
                sqlPsCol = "`stf_ps_id`, ";
                sqlPsVal = "'"+stf.stf_ps_id+"', ";
            }
            if(stf.stf_mk_id != null)
            {
                sqlMkCol = "`stf_mk_id`,  ";
                sqlMkVal = "'"+stf.stf_mk_id+"', ";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`staff`"+
            " (`stf_id`, `stf_u_id`, `stf_sc_id`, "+sqlFksCol+""+sqlPsCol+""+sqlMkCol+"`stf_fullname`, `stf_nik`, `stf_address`, `stf_province`, `stf_city`, `stf_birthplace`, `stf_birthdate`, `stf_gender`, `stf_religion`, `stf_state`, `stf_email`, `stf_stat`, `stf_contact`)"+
            " VALUES ('"+stf.stf_id +"', '"+stf.stf_u_id+"', '"+stf.stf_sc_id+"', "+sqlFksVal+""+sqlPsVal+""+sqlMkVal+"'"+stf.stf_fullname+"', '"+stf.stf_nik+"', '"+stf.stf_address+"', '"+stf.stf_province+"', '"+stf.stf_city+"', '"+stf.stf_birthplace+"', '"+stf.stf_birthdate+"', '"+stf.stf_gender+"', '"+stf.stf_religion+"', '"+stf.stf_state+"', '"+stf.stf_email+"', '"+stf.stf_stat+"', '"+stf.stf_contact+"');";
            
            using var _command = new MySqlCommand(sqlStr, _connection);
            affectedRow = _command.ExecuteNonQuery();

            _connection.Close();
            return affectedRow;
        }

        public static int CreateAlive(MySqlConnection _conn, UserStaff stf)
        {
            int affectedRow = 0;
            string sqlFksCol = "", sqlFksVal = "", sqlPsCol = "", sqlPsVal = "", sqlMkCol = "", sqlMkVal = "";
            if(stf.stf_fks_id != null)
            {
                sqlFksCol = "`stf_fks_id`, ";
                sqlFksVal = "'"+stf.stf_fks_id+"',";
            }
            if(stf.stf_ps_id != null)
            {
                sqlPsCol = "`stf_ps_id`, ";
                sqlPsVal = "'"+stf.stf_ps_id+"', ";
            }
            if(stf.stf_mk_id != null)
            {
                sqlMkCol = "`stf_mk_id`,  ";
                sqlMkVal = "'"+stf.stf_mk_id+"', ";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`staff`"+
            " (`stf_id`, `stf_u_id`, `stf_sc_id`, "+sqlFksCol+""+sqlPsCol+""+sqlMkCol+"`stf_fullname`, `stf_nik`, `stf_address`, `stf_province`, `stf_city`, `stf_birthplace`, `stf_birthdate`, `stf_gender`, `stf_religion`, `stf_state`, `stf_email`, `stf_stat`, `stf_contact`)"+
            " VALUES ('"+stf.stf_id +"', '"+stf.stf_u_id+"', '"+stf.stf_sc_id+"', "+sqlFksVal+""+sqlPsVal+""+sqlMkVal+"'"+stf.stf_fullname+"', '"+stf.stf_nik+"', '"+stf.stf_address+"', '"+stf.stf_province+"', '"+stf.stf_city+"', '"+stf.stf_birthplace+"', '"+stf.stf_birthdate+"', '"+stf.stf_gender+"', '"+stf.stf_religion+"', '"+stf.stf_state+"', '"+stf.stf_email+"', '"+stf.stf_stat+"', '"+stf.stf_contact+"');";
            
            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool CreateStaffAndUsers(string connStr, UserStaff stf, Users u, Role r = null, RolePreviledge rp = null, UserPhoto up = null)
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
                stf.stf_id = rand.Next(int.MinValue, int.MaxValue);
                stf.stf_u_id = u.u_id;
                Console.WriteLine("\nCreating Data :");
                if (r != null && rp != null)
                {
                    r.r_id = rand.Next(int.MinValue, int.MaxValue);
                    u.u_r_id = r.r_id;
                    rp.rp_id = rand.Next(int.MinValue, int.MaxValue);
                    rp.rp_r_id = r.r_id;
                    affectedRows += RoleCRUD.CreateAlive(_conn, r);
                    Console.WriteLine("\n Role : {0}", affectedRows);
                    affectedRows += RolePreviledgeCRUD.CreateAlive(_conn, rp);
                    Console.WriteLine("\n RolePreviledge : {0}", affectedRows);
                }
                affectedRows += UserCRUD.CreateAlive(_conn, u);
                Console.WriteLine("\n Users : {0}", affectedRows);
                if(up != null)
                {
                    up.up_id = rand.Next(int.MinValue, int.MaxValue);
                    up.up_u_id = u.u_id;
                    affectedRows += UserCRUD.CreatePhotoAlive(_conn, up);
                    Console.WriteLine("\n Photo : {0}", affectedRows);
                }
                affectedRows += CreateAlive(_conn, stf);
                Console.WriteLine("\n Staff : {0}", affectedRows);

                if(affectedRows != 2 + (((r != null && rp != null) ? 2 : 0) + (up != null ? 1 : 0))) throw new Exception();

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

        // Update staff Table
        public static int Update(string connStr, int stf_id, int stf_u_id, UserStaff stf)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlFks = null;
            if(stf.stf_fks_id != null) sqlFks = "`stf_fks_id` = '"+stf.stf_fks_id+"',";
            string sqlPs = null;
            if(stf.stf_ps_id != null) sqlPs = "`stf_ps_id` = '"+stf.stf_ps_id+"', ";
            string sqlMk = null;
            if(stf.stf_mk_id != null) sqlMk = "`stf_mk_id` = '"+stf.stf_mk_id+"', ";

            string sqlStr = "UPDATE db_kampus.staff SET "+sqlFks+sqlPs+sqlMk+"`stf_sc_id` = '"+stf.stf_sc_id+"',"+
            "`stf_fullname` = '"+stf.stf_fullname+"',`stf_nik` = '"+stf.stf_nik+"',`stf_address` = '"+stf.stf_address+"',`stf_province` = '"+stf.stf_province+"',`stf_city` = '"+stf.stf_city+"',`stf_birthplace` = '"+stf.stf_birthplace+"',`stf_birthdate` = '"+stf.stf_birthdate+"',`stf_gender` = '"+stf.stf_gender+"',`stf_state` = '"+stf.stf_state+"',`stf_email` = '"+stf.stf_email+"',`stf_stat` = "+stf.stf_stat+",`stf_contact` = '"+stf.stf_contact+"' "+
            "WHERE (`stf_id` = '"+stf_id+"' AND `stf_u_id` = '"+stf_u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
        public static int UpdateAlive(MySqlConnection _conn, int stf_id, int stf_u_id, UserStaff stf)
        {
            int affectedRow = 0;

            string sqlFks = string.Empty, sqlPs = string.Empty, sqlMk = string.Empty;
            if(stf.stf_fks_id != null) sqlFks = "`stf_fks_id` = '"+stf.stf_fks_id+"',";
            if(stf.stf_ps_id != null) sqlPs = "`stf_ps_id` = '"+stf.stf_ps_id+"', ";
            if(stf.stf_mk_id != null) sqlMk = "`stf_mk_id` = '"+stf.stf_mk_id+"', ";

            string sqlStr = "UPDATE db_kampus.staff SET "+sqlFks+sqlPs+sqlMk+"`stf_sc_id` = '"+stf.stf_sc_id+"',"+
            "`stf_fullname` = '"+stf.stf_fullname+"',`stf_nik` = '"+stf.stf_nik+"',`stf_address` = '"+stf.stf_address+"',`stf_province` = '"+stf.stf_province+"',`stf_city` = '"+stf.stf_city+"',`stf_birthplace` = '"+stf.stf_birthplace+"',`stf_birthdate` = '"+stf.stf_birthdate+"',`stf_gender` = '"+stf.stf_gender+"',`stf_state` = '"+stf.stf_state+"',`stf_email` = '"+stf.stf_email+"',`stf_stat` = "+stf.stf_stat+",`stf_contact` = '"+stf.stf_contact+"' "+
            "WHERE (`stf_id` = '"+stf_id+"' AND `stf_u_id` = '"+stf_u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }
        public static bool UpdateStaffandUser(string connStr, UserStaff stf, Users u, UserPhoto up = null)
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
                        Console.WriteLine("\n Image Delete");
                        if (up.up_id == null) throw new Exception("Unknown operation of image because either photo data and ID is null");
                        affectedRow += UserCRUD.DeletePhotoAlive(_conn, (int)u.u_id, (int)up.up_id);
                        Console.WriteLine("\n Image Delete Success");
                    }
                }
                affectedRow += UserCRUD.UpdateAlive(_conn, (int)u.u_id, u);
                affectedRow += UpdateAlive(_conn, (int)stf.stf_id, (int)stf.stf_u_id, stf);

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

        // Delete staff Table
        public static int Delete(string connStr, int stf_id)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "DELETE FROM `db_kampus`.`staff` WHERE (`stf_id` = '"+stf_id+"');";

            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
        public static int DeleteAlive(MySqlConnection _conn, int stf_u_id)
        {
            int affectedRow = 0;

            string sqlStr = "DELETE FROM `db_kampus`.`staff` WHERE (`stf_u_id` = '"+stf_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }
        public static bool DeleteStaffandUser(string connStr, UserStaff stf, int u_id)
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
                affectedRow += DeleteAlive(_conn, (int)stf.stf_u_id);
                affectedRow += UserCRUD.DeleteAlive(_conn, u_id);

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