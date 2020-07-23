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
            
            string sqlStr = "SELECT ust.s_u_id, u.u_username, ust.s_fullname, ust.s_nik, ust.s_stat"+
                            " FROM `db_kampus`.`site` ust"+
                            " INNER JOIN `db_kampus`.`users` u ON u.u_id = ust.s_u_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while (_data.Read())
            {
                ust.Add(new Site {
                    s_u_id = _data.GetInt32(0),
                    u_username = _data.GetString(1),
                    s_fullname = _data.GetString(2),
                    s_nik = _data.GetString(3),
                    s_stat = _data.GetInt16(4)
                });
            }
            _conn.Close();
            return ust;
        }

        public static Site Read(string connStr, int s_u_id)
        {
            Site ust = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT s.s_id, s.s_u_id, s.s_fullname, s.s_nik, s.s_address, s.s_province, s.s_city, s.s_birthplace, s.s_birthdate, s.s_gender, s.s_religion, s.s_state, s.s_email, s.s_stat, s.s_contact, u.u_id, u.u_ut_id, u.u_username"+ 
            " FROM db_kampus.site s INNER JOIN users u ON s.s_u_id = u.u_id"+
            " WHERE s.s_u_id = '"+s_u_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read())
            {
                ust = new Site();
                ust.s_id = _data.GetInt32(0);
                ust.s_u_id = _data.GetInt32(1);
                ust.s_fullname = _data.GetString(2);
                ust.s_nik = _data.GetString(3);
                ust.s_address = _data.GetString(4);
                ust.s_province = _data.GetString(5);
                ust.s_city = _data.GetString(6);
                ust.s_birthplace = _data.GetString(7);
                ust.s_birthdate = _data.GetString(8);
                ust.s_gender = _data.GetString(9);
                ust.s_religion = _data.GetString(10);
                ust.s_state = _data.GetString(11);
                ust.s_email = _data.GetString(12);
                ust.s_stat = _data.GetInt16(13);
                ust.s_contact = _data.GetString(14);
                ust.u_id = _data.GetInt32(15);
                ust.u_ut_id = _data.GetInt32(16);
                ust.u_username = _data.GetString(17);
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
                            " VALUES ('"+s.s_id +"', '"+s.s_u_id+"', "+sqlc_idVal+""+s.s_fullname+"', '"+s.s_nik+"', '"+s.s_address+"', '"+s.s_province+"', '"+s.s_city+"', '"+s.s_birthplace+"', '"+s.s_birthdate+"', '"+s.s_gender+"', '"+s.s_religion+"', '"+s.s_state+"', '"+s.s_email+"', '"+s.s_stat+"', '"+s.s_contact+"')";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool CreateSiteAndUser(string connStr, Site s, Users u)
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
                affectedRow += CreateAlive(_conn, s);

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

        public static int UpdateAlive(MySqlConnection _conn, int s_id, int s_u_id, Site s)
        {
            int affectedRow = 0;

            string sqlStr = "UPDATE `db_kampus`.`site` SET"+
                            "`s_fullname` = '"+s.s_fullname+"',`s_nik` = '"+s.s_nik+"',`s_address` = '"+s.s_address+"',`s_province` = '"+s.s_province+"',`s_city` = '"+s.s_city+"',`s_birthplace` = '"+s.s_birthplace+"',`s_birthdate` = '"+s.s_birthdate+"',`s_gender` = '"+s.s_gender+"',`s_state` = '"+s.s_state+"',`s_email` = '"+s.s_email+"',`s_stat` = "+s.s_stat+",`s_contact` = '"+s.s_contact+"' "+
                            "WHERE (`s_id` = '"+s_id+"' AND `s_u_id` = '"+s_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool UpdateSiteAndUser(string connStr, Site s, Users u)
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
                affectedRow += UpdateAlive(_conn, (int)s.s_id, (int)s.s_u_id, s);

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

        public static bool DeleteStaffandUser(string connStr, Site s, int u_id)
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