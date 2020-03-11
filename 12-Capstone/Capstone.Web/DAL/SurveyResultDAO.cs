using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultDAO
    {
        private readonly string connectionString;

        public SurveyResultDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<SurveyResult> GetSurveyResults()
        {
            List<SurveyResult> surveyResults = new List<SurveyResult>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
@"SELECT *
FROM survey_result";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through each row
                    while (rdr.Read())
                    {
                        SurveyResult sResult = RowToObject(rdr);
                        surveyResults.Add(sResult);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return surveyResults;
        }

        private SurveyResult RowToObject(SqlDataReader rdr)
        {
            // Create a city
            SurveyResult sResult = new SurveyResult();
            sResult.SurveyId = Convert.ToInt32(rdr["surveyId"]);
            sResult.ParkCode = Convert.ToString(rdr["parkCode"]);
            sResult.EmailAddress = Convert.ToString(rdr["emailAddress"]);
            sResult.State = Convert.ToString(rdr["state"]);
            sResult.ActivityLevel = Convert.ToString(rdr["activityLevel"]);
            return sResult;
        }
    }
}
