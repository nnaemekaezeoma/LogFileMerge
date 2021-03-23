using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MergeLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void mergeFile_Click(object sender, EventArgs e)
        {
            if (SelectedLogFiles.HasFiles)
            {

                List<Items> items = new List<Items>();

                string fileline = string.Empty, timestring = string.Empty, logData = string.Empty;
                foreach (HttpPostedFile uploadedFile in SelectedLogFiles.PostedFiles)
                {

                    var streamfile = new StreamReader(uploadedFile.InputStream);

                    try
                    {
                        //derived code to read and split the string 
                        while ((fileline = streamfile.ReadLine()) != null)
                        {
                            try
                            {
                                timestring = fileline.Substring(0, fileline.IndexOf(" ", fileline.IndexOf(" ") + 1));
                                logData = fileline.Substring(timestring.Length + 1, (fileline.Length - timestring.Length) - 1);
                                //my code 
                                items.Add(new Items { logData = logData, logTime = DateTime.Parse(timestring) });
                            }
                            catch{ }
                        }
                    }

                    catch { }

                }

                LogOutput(items);

            }
        }

        //My code
        //order and output combined Log record
        protected void LogOutput(List<Items> logrec)
        {
            
            string destination = "C://NewFolder//write.txt";
            using (StreamWriter writetext = new StreamWriter(destination))
            {
                foreach (Items rec in logrec.OrderBy(a => a.logTime))
                {
                    writetext.WriteLine(rec.logTime + " " + rec.logData);
                }

            }
            outputMessage.Text = $"Log Files combined successfully!!! {destination}";
        }
    }
}