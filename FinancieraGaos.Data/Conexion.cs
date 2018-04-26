using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraGaos.Data
{
    public class Conexion
    {

        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataTable runQuery(string q)
        {
            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable runQueryStore(string q)
        {
            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable runQuery(string q, List<SqlParameter> parameter)
        {
            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            foreach (SqlParameter p in parameter)
            {
                da.SelectCommand.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable runQueryStore(string q, List<SqlParameter> parameter)
        {

            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 18000;
            foreach (SqlParameter p in parameter)
            {
                da.SelectCommand.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader runCursor(string q)
        {
            SqlCommand cmd = new SqlCommand(q, cn);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (SqlException e) { throw e; }
        }

        public SqlDataReader runCursor(string q, List<SqlParameter> parameter)
        {
            SqlCommand cmd = new SqlCommand(q, cn);
            foreach (SqlParameter p in parameter)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception e) { throw e; }
        }

        public int runTransactionStore(string q, List<SqlParameter> parameter)
        {
            SqlCommand cmd = new SqlCommand(q, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parameter)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                cn.Open();
                int f = cmd.ExecuteNonQuery() >= 1 ? 1 : 0;
                cn.Close();
                return f;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public bool runValidateQuery(string q, List<SqlParameter> parameter)
        {
            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            foreach (SqlParameter p in parameter)
            {
                da.SelectCommand.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }

    }
}
