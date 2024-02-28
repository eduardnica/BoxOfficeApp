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

            // Get the movie ID from the request
            int contentID = 1;

            // Fetch movie details from the database (replace this with your database logic)
            StaticContent staticContent = FetchStaticConentDetails(contentID);

            // Serialize movie details to JSON and send it in the response
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
                                ContentID = contentID, // assuming you also want to set ContentID
                                Content = reader.GetString(0) // Assuming content is in the first column
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