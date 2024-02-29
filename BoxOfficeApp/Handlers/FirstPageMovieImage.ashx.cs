using BoxOfficeApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace BoxOfficeApp
{

    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            int movieId = Convert.ToInt32(context.Request["movieId"]);

            Movie movie = FetchMovieDetails(movieId);

            // Serialize movie details to JSON and send response
            string json = JsonConvert.SerializeObject(movie);
            context.Response.Write(json);
        }

        private Movie FetchMovieDetails(int movieId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IdMovie, Title, releaseDate, url, ImageURL FROM Movies WHERE IdMovie = @MovieID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movie
                            {
                                MovieID = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                ImageURL = reader.GetString(4)
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