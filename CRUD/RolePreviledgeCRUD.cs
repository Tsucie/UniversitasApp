using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class RolePreviledgeCRUD
    {
        public static RolePreviledge Read(string connStr, int r_id)
        {
            RolePreviledge rp = new RolePreviledge();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT rp_id, rp_view, rp_add, rp_edit, rp_delete, r_name"+
                            " FROM db_kampus.role_previledge INNER JOIN db_kampus.role ON rp_r_id = r_id"+
                            " WHERE rp_r_id = '"+r_id+"';";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            using MySqlDataReader _data = _cmd.ExecuteReader();
            if(_data.Read())
            {
                rp.rp_id = _data.GetInt32(0);
                rp.rp_view = _data.GetInt16(1);
                rp.rp_add = _data.GetInt16(2);
                rp.rp_edit = _data.GetInt16(3);
                rp.rp_delete = _data.GetInt16(4);
                rp.r_name = _data.GetString(5);
            }
            _conn.Close();
            return rp;
        }

        public static int Update(string connStr, RolePreviledge rp)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "UPDATE `db_kampus`.`role_previledge` "+
            "SET `rp_view` = '"+rp.rp_view+"', `rp_add` = '"+rp.rp_add+"', `rp_edit` = '"+rp.rp_edit+"', `rp_delete` = '"+rp.rp_delete+"', `rp_rec_updator` = '"+rp.rp_rec_updator+"', `rp_rec_updated` = '"+rp.rp_rec_updated+"' "+
            "WHERE (`rp_id` = '"+rp.rp_id+"') and (`rp_r_id` = '"+rp.rp_r_id+"');";

            using var _command = new MySqlCommand(sqlStr, _conn);
            affectedRow = _command.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
    }
}