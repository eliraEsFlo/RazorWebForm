using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.ProgramerPages
{
    public partial class PdfViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string p = "C:\\Users\\Administrador\\Downloads\\dummy.pdf";

                string route = Cache["Ruta"] as string;
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(route);


                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                }
            }
        }
    }
}