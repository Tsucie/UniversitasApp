using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class RoleCRUD
    {
        public static List<Role> ReadAll(string connStr)
        {
            List<Role> roles = new List<Role>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT r_id, rt_name, r_name, rt_desc, r_c_id, r_s_id, (SELECT u_username FROM db_kampus.users WHERE u_r_id = r_id) AS u_username "+
                            "FROM `db_kampus`.`role` "+
                            "INNER JOIN db_kampus.role_type ON r_rt_id = rt_id;";
            
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            while (_data.Read())
            {
                roles.Add(new Role {
                    r_id = _data.GetInt32(0),
                    rt_name = _data.GetString(1),
                    r_name = _data.GetString(2),
                    rt_desc = _data.GetString(3),
                    r_c_id = (_data.IsDBNull(4)) ? (int?)null : _data.GetInt32(4),
                    r_s_id = (_data.IsDBNull(5)) ? (int?)null : _data.GetInt32(5),
                    u_username = _data.GetString(6)
                });
            }
            _conn.Close();
            return roles;
        }

        public static int CreateAlive(MySqlConnection _conn, Role r)
        {
            int affectedRow = 0;
            string sqlRcIdCol = "", sqlRcIdVal = "";
            if(r.r_c_id != null)
            {
                sqlRcIdCol = "`r_c_id`,";
                sqlRcIdVal = "'"+r.r_c_id+"',";
            }
            string sqlRsIdCol = "", sqlRsIdVal = "";
            if(r.r_s_id != null)
            {
                sqlRsIdCol = "`r_s_id`,";
                sqlRsIdVal = "'"+r.r_s_id+"',";
            }

            string sqlStr = "INSERT INTO `db_kampus`.`role`"+
            " (`r_id`,`r_rt_id`,"+sqlRcIdCol+sqlRsIdCol+"`r_name`,`r_desc`,`r_rec_status`,`r_rec_creator`,`r_rec_created`)"+
            " VALUES ('"+r.r_id+"','"+r.r_rt_id+"',"+sqlRcIdVal+sqlRsIdVal+"'"+r.r_name+"','"+r.r_desc+"','"+r.r_rec_status+"','"+r.r_rec_creator+"','"+r.r_rec_created+"');";
            Console.WriteLine("\n Role Create : {0}", sqlStr);

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if (_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static int UpdateAlive(MySqlConnection _conn, int r_id, Role r)
        {
            int affectedRow = 0;
            PropertyInfo[] propInfos = r.GetType().GetProperties();
            PropertyInfo pi;
            Object v;
            string field;
            string value;
            string sqlUpdateVal = "";
            for (int i = 0; i < propInfos.Length; i++)
            {
                pi = propInfos[i];
                v = pi.GetValue(r);
                if (v != null)
                {
                    value = null;
                    if (v.GetType().Equals(typeof(string))) value = "'"+Convert.ToString(v)+"'";
                    else value = Convert.ToString(v);

                    if (value != string.Empty)
                    {
                        field = pi.Name;
                        sqlUpdateVal += (field + "=" + value + ",");
                    }
                }
            }

            string sqlStr = "UPDATE `db_kampus`.`role` SET " + sqlUpdateVal + ". WHERE (`r_id`="+r_id+");";
            sqlStr = sqlStr.Replace(",.","");
            Console.WriteLine("\n Role Update Sql: {0}", sqlStr);
            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if (_conn.State == ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }

        public static int DeleteAlive(MySqlConnection _conn, int r_id)
        {
            int affectedRow = 0;
            string sqlStr = "DELETE FROM `db_kampus`.`role` WHERE `r_id` = '"+r_id+"';";

            using var _cmd = new MySqlCommand(sqlStr);
            _cmd.Connection = _conn;

            if (_conn.State ==  ConnectionState.Closed) _conn.Open();
            affectedRow = _cmd.ExecuteNonQuery();

            return affectedRow;
        }
    }
}