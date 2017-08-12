using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_Admin_Team : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["AOPConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        try
        {
            FileUpload img = (FileUpload)FileUploadNewMember;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = FileUploadNewMember.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                ////force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);

                string fileName = File.FileName;

                Stream stream = File.InputStream;

                Bitmap sourceImage = new Bitmap(stream);

                System.Drawing.Image rezisedImage = ResizeImageWithAspect(sourceImage, 150);

               

                //System.Drawing.Image rezisedImage = FixedSize(sourceImage, 150, 150, true);

                imgByte = ImageToByte(rezisedImage);

            }

            con.Open();
            SqlCommand command = new SqlCommand("FileTeamDE", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("MemberLastName", System.Data.SqlDbType.NVarChar).Value = Convert.ToString(txtLastName.Text);
            command.Parameters.Add("MemberFirstName", System.Data.SqlDbType.NVarChar).Value = Convert.ToString(txtFirstName.Text);
            command.Parameters.Add("ProfilePic", System.Data.SqlDbType.VarBinary).Value = imgByte;
            command.Parameters.Add("DOB", System.Data.SqlDbType.Date).Value = Convert.ToString(CalendarDOB.SelectedDate);
            command.Parameters.Add("Desig", System.Data.SqlDbType.NVarChar).Value = Convert.ToString(txtDesig.Text);
            command.Parameters.Add("about", System.Data.SqlDbType.NVarChar).Value = Convert.ToString(txtAbout.Text);
            command.Parameters.Add("Email", System.Data.SqlDbType.NVarChar).Value = Convert.ToString(txtEmail.Text);
            command.ExecuteNonQuery();
            lblMessage.Text = String.Format("Successfully inserted");
        }
        catch
        {
            lblMessage.Text = "There was an error";
        }
        finally
        {
            con.Close();
        }
    }
    public static byte[] ImageToByte(System.Drawing.Image img)
    {
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
    private System.Drawing.Image ResizeImageWithAspect(System.Drawing.Image fileName,   int newWidth)

    {

        System.Drawing.Image original = fileName;

        //Find the aspect ratio between the height and width.

        float aspect = (float)original.Height / (float)original.Width;

        //Calculate the new height using the aspect ratio

        // and the desired new width.

       // int newHeight = (int)(newWidth * aspect);
        int newHeight = 150;

        //Create a bitmap of the correct size.

        Bitmap temp = new Bitmap(newWidth, newHeight, original.PixelFormat);

        //Get a Graphics object from the bitmap.

        Graphics newImage = Graphics.FromImage(temp);
        newImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
        newImage.CompositingQuality = CompositingQuality.HighQuality;
        newImage.SmoothingMode = SmoothingMode.HighQuality;

        //Draw the image with the new width/height

        newImage.DrawImage(original, 0, 0, newWidth, newHeight);

        //Save the bitmap

        return temp;

    }
    public static System.Drawing.Image FixedSize(System.Drawing.Image imagef, int Width, int Height, bool needToFill)
    {
        #region calculations
        int sourceWidth = imagef.Width;
        int sourceHeight = imagef.Height;
        int sourceX = 0;
        int sourceY = 0;
        double destX = 0;
        double destY = 0;

        double nScale = 0;
        double nScaleW = 0;
        double nScaleH = 0;

        nScaleW = ((double)Width / (double)sourceWidth);
        nScaleH = ((double)Height / (double)sourceHeight);
        if (!needToFill)
        {
            nScale = Math.Min(nScaleH, nScaleW);
        }
        else
        {
            nScale = Math.Max(nScaleH, nScaleW);
            destY = (Height - sourceHeight * nScale) / 2;
            destX = (Width - sourceWidth * nScale) / 2;
        }

        //if (nScale > 1)
        //    nScale = 1;

        int destWidth = (int)Math.Round(sourceWidth * nScale);
        int destHeight = (int)Math.Round(sourceHeight * nScale);
        #endregion

        System.Drawing.Bitmap bmPhoto = null;
        try
        {
            bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
        }
        catch (Exception ex)
        {
            throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                destWidth, destX, destHeight, destY, Width, Height), ex);
        }
        using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
        {
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;

            grPhoto.DrawImage(imagef, 0, 0, destWidth, destHeight);

            Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
            Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
            //Console.WriteLine("From: " + from.ToString());
            //Console.WriteLine("To: " + to.ToString());
           // grPhoto.DrawImage(imagef, to, from, System.Drawing.GraphicsUnit.Pixel);

            return bmPhoto;
        }
    }
}