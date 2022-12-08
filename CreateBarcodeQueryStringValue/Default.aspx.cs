using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;

namespace CreateBarcodeQueryStringValue
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string barCode = Request.QueryString["Barcode"];
            if (!string.IsNullOrWhiteSpace(barCode))
            {
                using (Bitmap bitMap = new Bitmap(barCode.Length * 20, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        graphics.DrawString(barCode, oFont, blackBrush, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, ImageFormat.Png);
                        imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                        imgBarcode.Visible = true;

                        Response.ContentType = "image/png";
                        byte[] data = ms.ToArray();
                        Response.OutputStream.Write(data, 0, data.Length);
                        Response.OutputStream.Flush();
                        Response.End();

                    }
                }

            }
        }
    }
}