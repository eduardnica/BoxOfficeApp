using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZedGraph;
using ZedGraph.Web;

namespace BoxOfficeApp
{
    public partial class ZedGraphClass : System.Web.UI.Page
    {

        GraphPane graphPane;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateZedGraph();
            }
        }

        private void GenerateZedGraph()
        {
            DataTable dtMovies = GetMoviesData();

            // Create a ZedGraphControl
            ZedGraphControl zedGraphControl = new ZedGraphControl();

            // Create a GraphPane
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.Text = "Number of Movies Released Each Year";
            myPane.XAxis.Title.Text = "Year";
            myPane.YAxis.Title.Text = "Number of Movies";

           //extractData
            var query = from row in dtMovies.AsEnumerable()
                        let releaseYear = ((DateTime)row["ReleaseDate"]).Year
                        group row by releaseYear into g
                        orderby g.Key
                        select new { Year = g.Key, Count = g.Count() };

            //Create bar
            BarItem bar = myPane.AddBar("Number of Movies", null, query.Select(x => (double)x.Count).ToArray(), Color.Blue);
            bar.Bar.Fill = new Fill(Color.Blue);
            bar.Bar.Fill.Type = FillType.Solid;

            //Customize X-Axis
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = query.Select(x => x.Year.ToString()).ToArray();
            myPane.XAxis.Scale.FontSpec.Angle = 90;

            // Bind the ZedGraphControl to ZedGraphWeb
            ZedGraphWeb1.RenderGraph += (z, g, masterPane) =>
            {
                masterPane[0] = myPane;
            };
        }

        private DataTable GetMoviesData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectMoviesQuery = "SELECT IdMovie, Title, ReleaseDate, URL, imageURL FROM Movies";
                using (SqlCommand command = new SqlCommand(selectMoviesQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }

}