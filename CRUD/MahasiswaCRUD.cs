using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;
using UniversitasApp.Controllers;

namespace UniversitasApp.CRUD
{
    public sealed class MahasiswaCRUD
    {
        public static async Task<List<UserMahasiswa>> ReadAllAsync(string connStr)
        {
            List<UserMahasiswa> um = new List<UserMahasiswa>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr =
                "SELECT * FROM db_kampus.mahasiswa"+
                    " INNER JOIN db_kampus.fakultas ON fks_id = mhs_fks_id;";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = await Task.Run(() => _cmd.ExecuteReader());

            while (_data.ReadAsync().Result)
            {
                um.Add(new UserMahasiswa {
                    mhs_fullname = _data.GetString("mhs_fullname"),
                    fks_name = _data.GetString("fks_name"),
                    mhs_nim = _data.GetString("mhs_nim"),
                    mhs_kelas = _data.GetString("mhs_kelas"),
                    mhs_email = _data.GetString("mhs_email"),
                    mhs_stat = _data.GetInt16("mhs_stat"),
                    mhs_u_id = _data.GetInt32("mhs_u_id")
                });
            }
            _conn.Close();
            return um;
        }

        public static UserMahasiswa Read(string connStr, int mhs_u_id)
        {
            UserMahasiswa um = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT mhs_id, mhs_u_id, mhs_fks_id, mhs_fullname, mhs_kelas, mhs_address, mhs_province, mhs_city, mhs_birthplace, mhs_birthdate, mhs_gender, mhs_religion, mhs_state, mhs_email, mhs_stat, mhs_contact, u_id, u_ut_id, u_username, mhs_nim, mhs_ps_id "+
            "FROM db_kampus.mahasiswa INNER JOIN db_kampus.users ON u_id = mhs_u_id "+
            "WHERE mhs_u_id = '"+mhs_u_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read())
            {
                um = new UserMahasiswa();
                um.mhs_id = _data.GetInt32(0);
                um.mhs_u_id = _data.GetInt32(1);
                um.mhs_fks_id = _data.GetInt32(2);
                um.mhs_fullname = _data.GetString(3);
                um.mhs_kelas = _data.GetString(4);
                um.mhs_address = _data.GetString(5);
                um.mhs_province = _data.GetString(6);
                um.mhs_city = _data.GetString(7);
                um.mhs_birthplace = _data.GetString(8);
                um.mhs_birthdate = _data.GetDateTime(9).ToString("yyyy-MM-dd");
                um.mhs_gender = _data.GetString(10);
                um.mhs_religion = _data.GetString(11);
                um.mhs_state = _data.GetString(12);
                um.mhs_email = _data.GetString(13);
                um.mhs_stat = _data.GetInt16(14);
                um.mhs_contact = _data.GetString(15);
                um.u_id = _data.GetInt32(16);
                um.u_ut_id = _data.GetInt32(17);
                um.u_username = _data.GetString(18).Replace("@", "");
                um.mhs_nim = _data.GetString(19);
                um.mhs_ps_id = _data.GetInt32(20);
            }
            _conn.Close();
            return um;
        }

        public static int Create(string connStr, UserMahasiswa mhs)
        {
            int affectedRow = 0;
            using var _connection = new MySqlConnection(connStr);
            _connection.Open();
            
            string sqlStr = "INSERT INTO `db_kampus`.`mahasiswa`"+
            " (`mhs_id`, `mhs_u_id`,`mhs_fks_id`, `mhs_fullname`, `mhs_nim`, `mhs_kelas`, `mhs_address`, `mhs_province`, `mhs_city`, `mhs_birthplace`, `mhs_birthdate`, `mhs_gender`, `mhs_religion`, `mhs_state`, `mhs_email`, `mhs_stat`, `mhs_contact`)"+
            " VALUES ('"+mhs.mhs_id +"', '"+mhs.mhs_u_id+"','"+mhs.mhs_fks_id+"', '"+mhs.mhs_fullname+"', '"+mhs.mhs_nim+"', '"+mhs.mhs_kelas+"', '"+mhs.mhs_address+"', '"+mhs.mhs_province+"', '"+mhs.mhs_city+"', '"+mhs.mhs_birthplace+"', '"+mhs.mhs_birthdate+"', '"+mhs.mhs_gender+"', '"+mhs.mhs_religion+"', '"+mhs.mhs_state+"', '"+mhs.mhs_email+"', '"+mhs.mhs_stat+"', '"+mhs.mhs_contact+"');";
            
            using var _command = new MySqlCommand(sqlStr, _connection);
            using MySqlDataReader _datareader = _command.ExecuteReader();
            if (_datareader.RecordsAffected.Equals(1)) affectedRow = _datareader.RecordsAffected;

            _connection.Close();
            return affectedRow;
        }

        public static int CreateAlive(MySqlConnection _conn, UserMahasiswa mhs)
        {
            int affectedRow = 0;
            string sqlStr = "INSERT INTO `db_kampus`.`mahasiswa`"+
            " (`mhs_id`, `mhs_u_id`,`mhs_fks_id`, `mhs_ps_id`, `mhs_fullname`, `mhs_nim`, `mhs_kelas`, `mhs_address`, `mhs_province`, `mhs_city`, `mhs_birthplace`, `mhs_birthdate`, `mhs_gender`, `mhs_religion`, `mhs_state`, `mhs_email`, `mhs_stat`, `mhs_contact`)"+
            " VALUES ('"+mhs.mhs_id +"', '"+mhs.mhs_u_id+"', '"+mhs.mhs_fks_id+"', '"+mhs.mhs_ps_id+"', '"+mhs.mhs_fullname+"', '"+mhs.mhs_nim+"', '"+mhs.mhs_kelas+"', '"+mhs.mhs_address+"', '"+mhs.mhs_province+"', '"+mhs.mhs_city+"', '"+mhs.mhs_birthplace+"', '"+mhs.mhs_birthdate+"', '"+mhs.mhs_gender+"', '"+mhs.mhs_religion+"', '"+mhs.mhs_state+"', '"+mhs.mhs_email+"', '"+mhs.mhs_stat+"', '"+mhs.mhs_contact+"');";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool CreateMhsAndUser(string connStr, UserMahasiswa mhs, Users u)
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
                affectedRow += CreateAlive(_conn, mhs);

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

        public static int UpdateAlive(MySqlConnection _conn, int mhs_id, int mhs_u_id, UserMahasiswa mhs)
        {
            int affectedRow = 0;

            string sqlFks = null, sqlPs = null;
            if(mhs.mhs_fks_id != null) sqlFks = "`mhs_fks_id` = '"+mhs.mhs_fks_id+"',";
            if(mhs.mhs_ps_id != null) sqlPs = "`mhs_ps_id` = '"+mhs.mhs_ps_id+"',";

            string sqlStr = "UPDATE db_kampus.mahasiswa SET "+ sqlFks + sqlPs +
            "`mhs_fullname` = '"+mhs.mhs_fullname+
            "',`mhs_nim`='"+mhs.mhs_nim+
            "',`mhs_kelas` = '"+mhs.mhs_kelas+
            "',`mhs_address` = '"+mhs.mhs_address+
            "',`mhs_province` = '"+mhs.mhs_province+
            "',`mhs_city` = '"+mhs.mhs_city+
            "',`mhs_birthplace` = '"+mhs.mhs_birthplace+
            "',`mhs_birthdate` = '"+mhs.mhs_birthdate+
            "',`mhs_gender` = '"+mhs.mhs_gender+
            "',`mhs_religion` = '"+mhs.mhs_religion+
            "',`mhs_state` = '"+mhs.mhs_state+
            "',`mhs_email` = '"+mhs.mhs_email+
            "',`mhs_stat` = "+mhs.mhs_stat+
            ",`mhs_contact` = '"+mhs.mhs_contact+"' "+
            "WHERE (`mhs_id` = '"+mhs_id+"' AND `mhs_u_id` = '"+mhs_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool UpdateMhsAndUser(string connStr, UserMahasiswa mhs, Users u)
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
                affectedRow += UpdateAlive(_conn, (int)mhs.mhs_id, (int)mhs.mhs_u_id, mhs);

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

        public static int DeleteAlive(MySqlConnection _conn, int mhs_u_id)
        {
            int affectedRow = 0;
            string sqlStr = "DELETE FROM `db_kampus`.`mahasiswa` WHERE (`mhs_u_id` = '"+mhs_u_id+"');";

            using var _command = new MySqlCommand(sqlStr);
            _command.Connection = _conn;

            if(_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _command.ExecuteNonQuery();

            return affectedRow;
        }

        public static bool DeleteMhsAndUser(string connStr, UserMahasiswa mhs, int u_id)
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
                affectedRow += DeleteAlive(_conn, (int)mhs.mhs_u_id);
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