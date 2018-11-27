using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TESTAPI.Objetos
{
    public class BDClass
    {

        public SqlConnection conectar;
        public SqlConnection conectarCheck;

        String tbl = String.Empty;
        String ipDisplay = String.Empty;
        private string connStrng;

        public BDClass()
        {
            ConexionOpen();
        }
        public string getConnStrng()
        {
            return connStrng;
        }

        #region Inicializa Conexion
        public void ConexionOpen()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            try
            {//Data source=172.168.1.67\\REPCASETAS;Initial Catalog=Telepeaje;User Id=sa;Password=Er3t4ihv; MultipleActiveResultSets=True
                string ConnString = "Data source=sql.softcame.net,2302;Initial Catalog=Transportes;User Id=sistemas;Password=softcame123; MultipleActiveResultSets=True";
                connStrng = ConnString;

                conectar = new SqlConnection(ConnString);
                conectarCheck = new SqlConnection(ConnString);
            }
            catch (SqlException ex)
            {
                
            }
            catch (Exception ex)
            {
               
            }
        }
        #endregion

        #region Abre Conexion
        private bool AbreConexion()
        {
            try
            {
                if (conectar.State != System.Data.ConnectionState.Open)
                {
                    ConexionOpen();
                    conectar.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "AbreConexion";
                this.CerrarConexion();
                conectar.Close();
                
                return false;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        private bool AbreConexionCheck()
        {
            try
            {
                if (conectarCheck.State != System.Data.ConnectionState.Open)
                {
                    conectarCheck.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "AbreConexion";
                this.CerrarConexion();
                conectarCheck.Close();
               
                return false;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }
        #endregion

        #region Cierra Conexion
        private bool CerrarConexion()
        {
            try
            {
                if (conectar.State != System.Data.ConnectionState.Closed)
                {
                    conectar.Close();
                    conectar.Dispose();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "CerrarConexion";
                string linea = ex.StackTrace.Substring(ex.StackTrace.Length - 8, 8);

               
                return false;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        #endregion

        public int ins_evento(string id,string usuario,string fecha, string personas, string categoria, string descripcion)
        {
            int valid = 0;
            if (this.AbreConexion())
            {
                try
                {
                   
                    SqlCommand cmd = new SqlCommand("SP_INS_EVENTO", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@personas", personas);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                   
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        valid = read.GetInt32(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                        return 0;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                    return 0;
                }
            }
            return 0;
        }

        public int upd_evento(string id, string fecha, string personas, string categoria, string descripcion)
        {
            int valid = 0;
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_UPDATE_EVENTO", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@personas", personas);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);

                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        valid = read.GetInt32(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                    return 0;
                }
            }
            return 0;
        }
        public int drop_evento(string id)
        {
            int valid = 0;
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_DROP_EVENTO", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        valid = read.GetInt32(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_EVENTO" + ex.Message);
                    return 0;
                }
            }
            return 0;
        }

        public ObjLogin login(string usuario, string password)
        {
            ObjLogin objLogin = new ObjLogin();
            objLogin.id = 0;
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_APP_LOGIN", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);

                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        objLogin.nombre = read.GetString(0);
                   
                    }
                    read.Close();
                    CerrarConexion();
                    return objLogin;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_LOGIN" + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_LOGIN" + ex.Message);
                    return null;
                }
            }
            return null;
        }
        public List<ObjListFallas> listReportes(string id)
        {
            List<ObjListFallas> listFallas = new List<ObjListFallas>();
            
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_APP_LISTSERVICIOS", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        ObjListFallas objListFallas = new ObjListFallas();
                        objListFallas.folio = read.GetInt64(0);
                        objListFallas.apodo = read.GetString(1);
                        objListFallas.nombres = read.GetString(2);
                        objListFallas.fecha = read.GetDateTime(5).ToString();
                        objListFallas.origen = read.GetString(3);
                        objListFallas.destino = read.GetString(4);
                        objListFallas.iniciado = read.GetBoolean(6);
                        objListFallas.cierre = read.GetBoolean(7);
                        objListFallas.reservacion = read.GetInt64(8).ToString();
                        listFallas.Add(objListFallas);
                    }
                    read.Close();
                    CerrarConexion();
                    return listFallas;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_APP_LIST_REPORTES" + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_APP_LIST_REPORTES" + ex.Message);
                    return null;
                }
            }
            return null;
        }

        public List<ObjListFallas> listReportesPendientes(string id)
        {
            List<ObjListFallas> listFallas = new List<ObjListFallas>();

            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_APP_LISTSERVICIOSPENDIENTES", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        ObjListFallas objListFallas = new ObjListFallas();
                        objListFallas.folio = read.GetInt64(0);
                        objListFallas.apodo = read.GetString(1);
                        objListFallas.nombres = read.GetString(2);
                        objListFallas.fecha = read.GetDateTime(5).ToString();
                        objListFallas.origen = read.GetString(3);
                        objListFallas.destino = read.GetString(4);
                        objListFallas.iniciado = read.GetBoolean(6);
                        objListFallas.cierre = read.GetBoolean(7);
                        objListFallas.reservacion = read.GetInt64(8).ToString();
                        listFallas.Add(objListFallas);
                    }
                    read.Close();
                    CerrarConexion();
                    return listFallas;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_APP_LIST_REPORTES" + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    EventLog.WriteEntry("BDClass", "SP_APP_LIST_REPORTES" + ex.Message);
                    return null;
                }
            }
            return null;
        }

        public int addSugerencia(string news, string name,string address,string phone,string email,string text)
        {
            int valid = 0;
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_ADD_SUGERENCIA", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@news", news);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@text", text);


                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        valid = read.GetInt32(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_ADD_SUGERENCIA" + ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_ADD_SUGERENCIA" + ex.Message);
                    return 0;
                }
            }
            return 0;
        }

        public int update_servicio(Int64 folio, byte caso)
        {
            int valid = 0;
            if (this.AbreConexion())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_APP_UPDATESERVICIO", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", folio);
                    cmd.Parameters.AddWithValue("@CASO", caso);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        valid = read.GetInt32(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_APP_UPDATESERVICIO" + ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_APP_UPDATESERVICIO" + ex.Message);
                    return 0;
                }
            }
            return 0;
        }

    }
}