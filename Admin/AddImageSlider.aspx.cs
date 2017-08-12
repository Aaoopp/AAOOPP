using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddImageSlider : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["AOPConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileNameWithPath = "";
        string fileName = "";
        try
        {
            FileUpload img = (FileUpload)FileUploadNewSliderImg;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = FileUploadNewSliderImg.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                ////force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);

                fileNameWithPath = Server.MapPath("~/NivoSlider/demo/images/") + File.FileName.ToString();
                FileUploadNewSliderImg.PostedFile.SaveAs(fileNameWithPath);
                fileNameWithPath = "~/NivoSlider/demo/images/" + File.FileName.ToString();
                fileName = File.FileName;

                //Stream stream = File.InputStream;

                //Bitmap sourceImage = new Bitmap(stream);

                //System.Drawing.Image rezisedImage = ResizeImageWithAspect(sourceImage, 150);



                ////System.Drawing.Image rezisedImage = FixedSize(sourceImage, 150, 150, true);

                //imgByte = ImageToByte(rezisedImage);

            }

            con.Open();
            SqlCommand command = new SqlCommand("SliderImageInsert", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

          
            command.Parameters.Add("image", System.Data.SqlDbType.VarBinary).Value = imgByte;
            command.Parameters.Add("Path", System.Data.SqlDbType.VarChar).Value = fileNameWithPath;
            command.Parameters.Add("ImageName", System.Data.SqlDbType.VarChar).Value = fileName;
            command.ExecuteNonQuery();
            lblMessage.Text = String.Format("Successfully inserted");
        }
        catch (Exception ex)
        {
            lblMessage.Text = "There was an error";
        }
        finally
        {
            con.Close();
        }
    }
}