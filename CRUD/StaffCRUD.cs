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
    public sealed class StaffCRUD
    {
        // Read All staff Table
        public static List<UserStaff> ReadAll(string connStr)
        {
            List<UserStaff> us = new List<UserStaff>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();
            string sqlStr = "SELECT stf.stf_u_id, stf.stf_fullname, sc.sc_name, stf.stf_nik, stf.stf_email, stf.stf_contact, stf.stf_stat"+
                            " FROM db_kampus.staff stf INNER JOIN db_kampus.staff_category sc ON stf.stf_sc_id = sc.sc_id;";
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while (_data.Read())
            {
                us.Add(new UserStaff {
                    stf_u_id = _data.GetInt32(0),
                    stf_fullname = _data.GetString(1),
                    sc_name = _data.GetString(2),
                    stf_nik = _data.GetString(3),
                    stf_email = _data.GetString(4),
                    stf_contact = _data.GetString(5),
                    stf_stat = _data.GetInt16(6)
                });
            }
            _conn.Close();
            return us;
        }

        public static UserStaff Read(string connStr, int stf_u_id)
        {
            UserStaff stf = new UserStaff();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            // string sqlFks = "", sqlPs = "", sqlMk = "";
            // if(!us.stf_fks_id.Equals(null)) sqlFks = ", stf.stf_fks_id";
            // if(!us.stf_ps_id.Equals(null)) sqlPs = ", stf.stf_ps_id";
            // if(!us.stf_mk_id.Equals(null)) sqlMk = ", stf.stf_mk_id";
            string sqlStr = "SELECT stf.stf_id, stf.stf_u_id, stf.stf_sc_id, stf.stf_fullname, stf.stf_nik, stf.stf_address, stf.stf_province, stf.stf_city, stf.stf_birthplace, stf.stf_birthdate, stf.stf_gender, stf.stf_religion, stf.stf_state, stf.stf_email, stf.stf_stat, stf.stf_contact, u.u_id, u.u_ut_id, u.u_username"
            // +sqlFks+sqlPs+sqlMk
            +" FROM db_kampus.staff stf INNER JOIN users u ON stf.stf_u_id = u.u_id"+
            " WHERE stf.stf_u_id = '"+stf_u_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read().Equals(true))
            {
                stf.stf_id = _data.GetInt32(0);
                stf.stf_u_id = _data.GetInt32(1);
                stf.stf_sc_id = _data.GetInt32(2);
                stf.stf_fullname = _data.GetString(3);
                stf.stf_nik = _data.GetString(4);
                stf.stf_address = _data.GetString(5);
                stf.stf_province = _data.GetString(6);
                stf.stf_city = _data.GetString(7);
                stf.stf_birthplace = _data.GetString(8);
                stf.stf_birthdate = _data.GetString(9);
                stf.stf_gender = _data.GetString(10);
                stf.stf_religion = _data.GetString(11);
                stf.stf_state = _data.GetString(12);
                stf.stf_email = _data.GetString(13);
                stf.stf_stat = _data.GetInt16(14);
                stf.stf_contact = _data.GetString(15);
                stf.u_id = _data.GetInt32(16);
                stf.u_ut_id = _data.GetInt32(17);
                stf.u_username = _data.GetString(18);
                // if(!_data.GetInt32(19).Equals(null)) stf.u_r_id = _data.GetInt32(19);
                // if(!_data.GetInt32(20).Equals(null)) stf.stf_fks_id = _data.GetInt32(20);
                // if(!_data.GetInt32(21).Equals(null)) stf.stf_ps_id = _data.GetInt32(21);
                // if(!_data.GetInt32(22).Equals(null)) stf.stf_mk_id = _data.GetInt32(22);
            }
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
            if(!stf.stf_fks_id.Equals(null))
            {
                sqlFksCol = "`stf_fks_id`, ";
                sqlFksVal = "'"+stf.stf_fks_id+"',";
            }
            if(!stf.stf_ps_id.Equals(null))
            {
                sqlPsCol = "`stf_ps_id`, ";
                sqlPsVal = "'"+stf.stf_ps_id+"', ";
            }
            if(!stf.stf_mk_id.Equals(null))
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
            if(!stf.stf_fks_id.Equals(null))
            {
                sqlFksCol = "`stf_fks_id`, ";
                sqlFksVal = "'"+stf.stf_fks_id+"',";
            }
            if(!stf.stf_ps_id.Equals(null))
            {
                sqlPsCol = "`stf_ps_id`, ";
                sqlPsVal = "'"+stf.stf_ps_id+"', ";
            }
            if(!stf.stf_mk_id.Equals(null))
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
        public static bool CreateStaffAndUsers(string connStr, UserStaff stf, Users u)
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
                affectedRow += CreateAlive(_conn, stf);

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

        // Update staff Table
        public static int Update(string connStr, int stf_id, int stf_u_id, UserStaff stf)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlFks = null;
            if(!stf.stf_fks_id.Equals(null)) sqlFks = "`stf_fks_id` = '"+stf.stf_fks_id+"'";
            string sqlPs = null;
            if(!stf.stf_ps_id.Equals(null)) sqlPs = "`stf_ps_id` = '"+stf.stf_ps_id+"', ";
            string sqlMk = null;
            if(!stf.stf_mk_id.Equals(null)) sqlMk = "`stf_mk_id` = '"+stf.stf_mk_id+"', ";

            string sqlStr = "UPDATE db_kampus.staff SET "+sqlFks+sqlPs+sqlMk+
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

            string sqlFks = null;
            if(!stf.stf_fks_id.Equals(null)) sqlFks = "`stf_fks_id` = '"+stf.stf_fks_id+"'";
            string sqlPs = null;
            if(!stf.stf_ps_id.Equals(null)) sqlPs = "`stf_ps_id` = '"+stf.stf_ps_id+"', ";
            string sqlMk = null;
            if(!stf.stf_mk_id.Equals(null)) sqlMk = "`stf_mk_id` = '"+stf.stf_mk_id+"', ";

            string sqlStr = "UPDATE db_kampus.staff SET "+sqlFks+sqlPs+sqlMk+
            "`stf_fullname` = '"+stf.stf_fullname+"',`stf_nik` = '"+stf.stf_nik+"',`stf_address` = '"+stf.stf_address+"',`stf_province` = '"+stf.stf_province+"',`stf_city` = '"+stf.stf_city+"',`stf_birthplace` = '"+stf.stf_birthplace+"',`stf_birthdate` = '"+stf.stf_birthdate+"',`stf_gender` = '"+stf.stf_gender+"',`stf_state` = '"+stf.stf_state+"',`stf_email` = '"+stf.stf_email+"',`stf_stat` = "+stf.stf_stat+",`stf_contact` = '"+stf.stf_contact+"' "+
            "WHERE (`stf_id` = '"+stf_id+"' AND `stf_u_id` = '"+stf_u_id+"');";
            
            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }
        public static bool UpdateStaffandUser(string connStr, UserStaff stf, Users u)
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
                affectedRow += UpdateAlive(_conn, (int)stf.stf_id, (int)stf.stf_u_id, stf);

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