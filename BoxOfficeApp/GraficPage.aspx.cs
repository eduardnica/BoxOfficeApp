using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZedGraph;



namespace BoxOfficeApp
{
    public partial class GraficPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your existing code
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FirstPage.aspx");
        }

        protected void ZedGraphWeb1_RenderGraph(ZedGraph.Web.ZedGraphWeb webObject, System.Drawing.Graphics g, ZedGraph.MasterPane pane)
        {
            DataTable data = (DataTable)Cache["reviews"];
            GraphPane mPane = pane[0];
            mPane.Title.Text = "Movies / Reviews";
            mPane.XAxis.Title.Text = "Movies";
            mPane.YAxis.Title.Text = "Evaluations";
            ColorSymbolRotator colorSymbolRotator = new ColorSymbolRotator();
            if (Request.QueryString["type"] != null)
            {
                List<string> list = new List<string>();
                PointPairList ppList = new PointPairList();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(row[0].ToString());
                    ppList.Add(0, float.Parse(row[1].ToString()));
                }
                switch (Request.QueryString["type"])
                {
                    case "Bars":
                        {
                            BarItem item = mPane.AddBar("Bars", ppList, colorSymbolRotator.NextColor);
                            item.Bar.Fill = new Fill(colorSymbolRotator.NextColor);
                            item.Bar.Fill.Type = FillType.Solid;
                            item.Bar.Fill.RangeMin = 0;
                            item.Bar.Fill.RangeMax = ppList.Count;
                            mPane.XAxis.Type = AxisType.Text;
                            mPane.XAxis.Scale.TextLabels = list.ToArray();
                        }
                        break;
                }
            }
        }
    }
}

       