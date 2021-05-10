using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversitasApp.Models;

namespace UniversitasApp.CRUD
{
    public sealed class MataKuliahCRUD
    {
        public static List<MataKuliah> ReadAllById(string connStr, int mk_ps_id)
        {
            List<MataKuliah> matkul = new List<MataKuliah>();
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT *, " +
                            "(SELECT sm_code FROM db_kampus.semester WHERE sm_id = mk_sm_id) AS sm_code "+
                            "FROM db_kampus.mata_kuliah";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    matkul.Add(new MataKuliah {
                        mk_id = (int)dr["mk_id"],
                        mk_ps_id = (int)dr["mk_ps_id"],
                        mk_sm_id = (int)dr["mk_sm_id"],
                        mk_sks = (int)dr["mk_sks"],
                        mk_mutu = (int)dr["mk_mutu"],
                        mk_code = (string)dr["mk_code"],
                        mk_name = (string)dr["mk_name"],
                        mk_desc = (string)dr["mk_desc"],
                        sm_code = (string)dr["sm_code"]
                    });
                }
            }

            _conn.Close();
            return matkul;
        }

        public static MataKuliah Read(string connStr, int mk_id)
        {
            MataKuliah mk = null;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "SELECT * FROM db_kampus.mata_kuliah WHERE mk_id = " + mk_id.ToString();

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_cmd);
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                mk = new MataKuliah();
                mk.mk_id = (int)dt.Rows[0]["mk_id"];
                mk.mk_ps_id = (int)dt.Rows[0]["mk_ps_id"];
                mk.mk_sm_id = (int)dt.Rows[0]["mk_sm_id"];
                mk.mk_sks = (int)dt.Rows[0]["mk_sks"];
                mk.mk_mutu = (int)dt.Rows[0]["mk_mutu"];
                mk.mk_code = (string)dt.Rows[0]["mk_code"];
                mk.mk_name = (string)dt.Rows[0]["mk_name"];
                mk.mk_desc = (string)dt.Rows[0]["mk_desc"];
            }

            _conn.Close();
            return mk;
        }

        public static int Create(string connStr, MataKuliah mk)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "INSERT INTO db_kampus.mata_kuliah "+
            "(`mk_id`,`mk_ps_id`,`mk_sm_id`,`mk_sks`,`mk_mutu`,`mk_code`,`mk_name`,`mk_desc`) "+
            "VALUES ("+mk.mk_id+","+mk.mk_ps_id+","+mk.mk_sm_id+","+mk.mk_sks+","+mk.mk_mutu+",'"+mk.mk_code+"','"+mk.mk_name+"','"+mk.mk_desc+"')";

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int Update(string connStr, int mk_id, int mk_ps_id, MataKuliah mk)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "UPDATE db_kampus.mata_kuliah SET "+
            "`mk_ps_id` = "+mk.mk_ps_id+ ", `mk_sm_id` = "+mk.mk_sm_id+", `mk_sks` = "+mk.mk_sks+", `mk_mutu` = "+mk.mk_mutu+", `mk_code` = "+mk.mk_code+", `mk_name` = "+mk.mk_name+", `mk_desc` = "+mk.mk_desc+
            " WHERE mk_ps_id = "+mk_ps_id.ToString()+" AND mk_id = "+mk_id.ToString();
            
            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }

        public static int Delete(string connStr, int mk_id, int mk_ps_id)
        {
            int affectedRow = 0;
            using var _conn = new MySqlConnection(connStr);
            _conn.Open();

            string sqlStr = "DELETE FROM db_kampus.mata_kuliah WHERE mk_ps_id = "+mk_ps_id.ToString()+" AND mk_id = "+mk_id.ToString();

            using var _cmd = new MySqlCommand(sqlStr, _conn);
            affectedRow = _cmd.ExecuteNonQuery();

            _conn.Close();
            return affectedRow;
        }
    }
}