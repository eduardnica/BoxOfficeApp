using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;


namespace BoxOfficeApp
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if page reloaded
            if (!IsPostBack)
            {
                LoadMovies();
            }
        }

        private void LoadMovies()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectMoviesQuery = "SELECT IdMovie, Title, releaseDate, url FROM Movies";

                using (SqlCommand command = new SqlCommand(selectMoviesQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTableMovies = new DataTable();
                    adapter.Fill(dataTableMovies);
                    //binddata to dropdown
                    dropDownMovies.DataSource = dataTableMovies;
                    dropDownMovies.DataTextField = "Title";
                    dropDownMovies.DataValueField = "IdMovie";
                    dropDownMovies.DataBind();
                    dropDownMovies.Items.Insert(0, new ListItem("-- Select a Movie --", "0"));
                }
            }
        }


        protected void btnBuyTickets_Click(object sender, EventArgs e)
        {

            // Validate that a movie is selected
            if (dropDownMovies.SelectedIndex == 0)
            {
                ticketResponse.Text = "Please select at least one movie.";
                return;
            }
            if (string.IsNullOrEmpty(txtDate.Text))
            {
                ticketResponse.Text = "Please enter a valid date.";
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                ticketResponse.Text = "Please enter a quantity greater than 0";
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            int ticketID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertTicketQuery = "INSERT INTO Tickets (Date, Quantity) VALUES (@Date, @Quantity); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(insertTicketQuery, connection))
                {
                    command.Parameters.AddWithValue("@Date", txtDate.Text);
                    command.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));

                    ticketID = Convert.ToInt32(command.ExecuteScalar());
                }

                // Insert into MovieTickets table for each selected movie
                foreach (ListItem movieItem in dropDownMovies.Items)
                {
                    if (movieItem.Selected)
                    {
                        int movieID = Convert.ToInt32(movieItem.Value);
                        string insertMovieTicketsQuery = "INSERT INTO MovieTickets (MovieID, TicketID) VALUES (@MovieID, @TicketID)";
                         

                        using (SqlCommand command = new SqlCommand(insertMovieTicketsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@MovieID", movieID);
                            command.Parameters.AddWithValue("@TicketID", ticketID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            ticketResponse.Text = $"Tickets purchased successfully for TicketID: {ticketID}. Thank you!";


        }



    }
}