﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using BO_BusinessManagement;

namespace Dao_BussinessManagement
{
    public class Dao_UtilsLib
    {
        private static string lConnectionString = ConfigurationManager.ConnectionStrings["Conex_Business"].ConnectionString;

        public static SqlConnection Dao_SqlConnection(SqlConnection lConn)
        {
            lConn = new SqlConnection(lConnectionString);           
            if(lConn.State == ConnectionState.Open)
            {
                return lConn;
            }
            lConn.Open();
            return lConn;
            
        }

        public static void Dao_CloseSqlconnection(SqlConnection pConex)
        {
            pConex.Close();
        }

        public static void dao_Addparameters(List<SqlParameter> pListParam, SqlDbType pType, string pNameParameter, string pValue)
        {
            SqlParameter lParameter = new SqlParameter(pNameParameter, pType);
            lParameter.Value = pValue;
            pListParam.Add(lParameter); 
        }

        public static string Dao_executeSqlTransactionWithProcedement(List<SqlParameter> lListParameters, string pNameTransaction, string pNameProcedure)
        {
            
            string lResult = null;
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                using (SqlTransaction lTran = lConex.BeginTransaction(pNameTransaction))
                {
                    SqlCommand lCommand = lConex.CreateCommand();
                    lCommand.Connection = lConex;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Transaction = lTran;
                    try
                    {
                        lCommand.CommandType = CommandType.StoredProcedure;
                        lCommand.CommandText = pNameProcedure;                      
                        lCommand.CommandTimeout = 30;

                        if (lListParameters.Count > 0)
                        {
                            lListParameters.ForEach(x => { lCommand.Parameters.Add(x); });
                        }
                        lCommand.ExecuteNonQuery();
                        lTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        lResult = "Commit Exception Type: " + ex.GetType() + "  Message: " + ex.Message;

                        try
                        {
                            lTran.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            lResult += " Rollback Exception Type: " + ex2.GetType() + "  Message: " + ex2.Message;
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection( lConex);
                }
            }
            return lResult;
        }

        public static Bo_Object DaoUtilsLib_getObject(string lNameObject){
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_getObjectByName";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("NameObject", lNameObject));
                    var lReader = lCommand.ExecuteReader();
                    Bo_Object oObject = new Bo_Object();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {   
                            oObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oObject.LNameObject = lReader["NameObject"].ToString();
                            oObject.LActive = Convert.ToBoolean(lReader["flActive"].ToString());
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return oObject;
                }
                catch (Exception e)
                {
                    Bo_Object oObject = new Bo_Object();
                    oObject.LException = e.Message;
                    if (e.InnerException != null)
                        oObject.LInnerException = e.InnerException.ToString();
                    oObject.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return oObject;
                }

            }
        }

        public static List<Bo_Unit> DaoUtilsLib_getAllUnit()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllUnit";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Unit> oListUnit= new List<Bo_Unit>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Unit oUnit = new Bo_Unit();
                            oUnit.LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString());
                            oUnit.LNameUnit = lReader["NameUnit"].ToString();
                            oUnit.LCdUnit = lReader["CdUnit"].ToString();
                            oUnit.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                            oListUnit.Add(oUnit);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return oListUnit;
                }
                catch (Exception e)
                {
                    List<Bo_Unit> oListUnit = new List<Bo_Unit>();
                    Bo_Unit oUnit = new Bo_Unit();
                    oUnit.LException = e.Message;
                    if (e.InnerException != null)
                        oUnit.LInnerException = e.InnerException.ToString();
                    oUnit.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    oListUnit.Add(oUnit);
                    return oListUnit;
                }

            }
        }

    }
}
