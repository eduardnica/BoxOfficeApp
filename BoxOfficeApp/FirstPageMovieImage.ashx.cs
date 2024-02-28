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

            // Get the movie ID from the request
            int movieId = Convert.ToInt32(context.Request["movieId"]);

            // Fetch movie details from the database (replace this with your database logic)
            Movie movie = FetchMovieDetails(movieId);

            // Serialize movie details to JSON and send it in the response
            string json = JsonConvert.SerializeObject(movie);
            context.Response.Write(json);
        }

        private Movie FetchMovieDetails(int movieId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sample query (replace with your actual query)
                string query = "SELECT IdMovie, Title, releaseDate, url, ImageURL FROM Movies WHERE IdMovie = @MovieID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate a Movie object with details including ImageURL
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

            // Return null or handle the case when the movie is not found
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