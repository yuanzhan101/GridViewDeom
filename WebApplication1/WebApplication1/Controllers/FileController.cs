using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            var fileName = file.FileName;
            var filePath = Server.MapPath(string.Format("~/App_Data/input1", "File"));
            file.SaveAs(Path.Combine(filePath, fileName));
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes(file.ContentLength);
            string a = System.Text.Encoding.UTF8.GetString(binData);

            string[] words = a.Split('\n');

            ArrayList vb = new ArrayList();
            String[] st1 = words[0].Split(' ');
            foreach (String ele in st1)
            {
                vb.Add(ele);
            }
            List<List<String>> vb2 = new List<List<string>>();

            for (int i = 1; i < words.Length; i++)
            {
                String[] st2 = words[i].Split(' ');
                List<String> vb1 = new List<String>();
                foreach (String ele in st2)
                {
                    vb1.Add(ele);
                }
                vb2.Add(vb1);
            }
            var f = new FIles
            {
                variables = vb,
                data = vb2
            };
            return View(f);
        }
    }
}