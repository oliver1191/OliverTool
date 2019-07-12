using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWriteGitIngoreFile
{
    public class GitIgnoreControll
    {
        public void WriteIgnoreFile()
        {
            string folderPath = ConfigurationManager.AppSettings["foldPath"];
            List<string> ignoreFolderNames = new List<string>();
            NameValueCollection allSettings = ConfigurationManager.AppSettings;
            foreach (var setting in allSettings)
            {
                if (setting.ToString() != "foldPath" && setting.ToString() != "logPath")
                {
                    ignoreFolderNames.Add(ConfigurationManager.AppSettings[setting.ToString()]);
                }
            }            
            foreach (var folder in Directory.GetDirectories(folderPath))
            {
                string folderName = folder.Substring(folder.LastIndexOf("\\") + 1);                
                if (folderName == ".git" || folderName == ".vs"||folderName== "packages")
                {                    
                    WriteStrtoFile(string.Format("/{0}", folderName));
                }
                else
                {
                    foreach (var item in ignoreFolderNames)
                    {                                                
                        WriteStrtoFile(string.Format("/{0}/{1}", folderName, item));
                    }                    
                }                                         
            }
        }
        public void WriteStrtoFile(string message)
        {           
            string sFilePath = ConfigurationManager.AppSettings["logPath"];
            string sFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            sFileName = sFilePath + @"\\" + sFileName;
            if (!Directory.Exists(sFilePath))
            {
                Directory.CreateDirectory(sFilePath);
            }
            FileStream fs;
            StreamWriter sw;
            if (System.IO.File.Exists(sFileName))
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(message);
            sw.Close();
            fs.Close();

        }
    }
}
