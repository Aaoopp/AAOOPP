using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RptSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
           HiddenField hf = e.Item.FindControl("HiddenFieldSliderid") as HiddenField;
        if (hf != null)
        {
            string val = hf.Value;
            Image img = e.Item.FindControl("imgSlider") as Image;
            //img.ImageUrl = "~/image" + val + ".jpg";

            img.ImageUrl = "~/SliderImage.ashx?id=" + val;
            
        }
    }
}