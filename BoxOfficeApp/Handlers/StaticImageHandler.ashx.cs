using BoxOfficeApp.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoxOfficeApp.Handlers
{
    /// <summary>
    /// Summary description for StaticImageHandler
    /// </summary>
    public class StaticImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int contentID = 1;

            StaticContent staticContent = FetchStaticConentDetails(contentID);

            string json = JsonConvert.SerializeObject(new { StaticImageURL = staticContent?.Content });
            context.Response.Write(json);
        }



        private StaticContent FetchStaticConentDetails(int contentID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT content FROM StaticContent WHERE IdContent = @ContentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContentID", contentID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StaticContent
                            {
                                ContentID = contentID, 
                                Content = reader.GetString(0)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}