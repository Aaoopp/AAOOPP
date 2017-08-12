using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["AOPConnectionString"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void BindRepeater()
    {

        //DataTable table = new DataTable();

        //string sql = "SELECT ID, ProfilePic FROM Team_DE";

        //SqlCommand cmd = new SqlCommand(sql, con);

        //SqlDataAdapter ad = new SqlDataAdapter(cmd);

        //ad.Fill(table);


        //foreach (DataRow row in table.Rows)
        //{
        //    //Response.Write("<p>" + row["AutoId"] + " > " + row["FirstName"] + " >" + row["LastName"] + " > " + row["Age"] + " > " + row["Active"] + "</p>");
        //    imgTeam.ImageUrl = "~/ShowImage.ashx?id=" + row["ID"];
        //}
        //RptTeam.DataSource = table;
        //RptTeam.DataBind();
                
            
        
    }

        // Display the image from the database


    protected void RptTeam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hf = e.Item.FindControl("HiddenFieldTeamid") as HiddenField;
        if (hf != null)
        {
            string val = hf.Value;
            Image img = e.Item.FindControl("imgTeam") as Image;
            //img.ImageUrl = "~/image" + val + ".jpg";

            img.ImageUrl = "~/ShowImage.ashx?id=" + val;
        }
    }

    protected void RptSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hf = e.Item.FindControl("HiddenFieldSliderid") as HiddenField;
        if (hf != null)
        {
            string val = hf.Value;
            Image img = e.Item.FindControl("imgSlider") as Image;
            //img.ImageUrl = "~/image" + val + ".jpg";

          //  img.ImageUrl = "~/SliderImage.ashx?id=" + val;

        }
    }
}