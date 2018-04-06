using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectProgressUpdate
{
    public class ProjectClass
    {
        public static string Con = ConfigurationManager.AppSettings["ConnectionTest"];
        public static string ConLive = ConfigurationManager.AppSettings["ConnectionLive"];
        public DataTable GetProjectId()
        {
            return SqlHelper.ExecuteDataset(Con, CommandType.Text, "select distinct t_cprj from ttpisg220200").Tables[0];
        }
        public DataTable GetProject(string ProjectId)
        {
            return SqlHelper.ExecuteDataset(Con, CommandType.Text, @"select t_cprj,t_cact,t_sdst,t_sdfn,t_acsd,t_acfn,
                                    t_dsca
                                    from ttpisg910200 
                                    WHERE t_cprj = '" + ProjectId + "'").Tables[0];
        }
        public DataTable GetProjectProgressByID(string ProjectId,string Activity)
        {
            return SqlHelper.ExecuteDataset(Con, CommandType.Text, @"select t_cprj,t_cact,t_sdst,t_sdfn,t_acsd,t_acfn,
                                    t_dsca
                                    from ttpisg910200                                 
                                    WHERE t_cprj = '" + ProjectId + "' and t_cact='" + Activity + "'").Tables[0];
        }
        public int UpdateActualDates(string ProjectId, string Activity,string Actual_SDate, string Actual_FDate)
        {
            return SqlHelper.ExecuteNonQuery(Con, CommandType.Text, @"Update ttpisg910200 set t_acsd='" + Actual_SDate + "' ,t_acfn='"+ Actual_FDate + @"'
                            WHERE t_cprj = '" + ProjectId + "' and t_cact='" + Activity + "'");
        }
        public DataTable GetProjectName(string ProjectId)
        {
            return SqlHelper.ExecuteDataset(Con, CommandType.Text, @"select t_dsca from ttcmcs052200 where t_cprj='" + ProjectId + "'").Tables[0];
        }
    }
}