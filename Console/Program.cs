using System;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


internal class Program
{
    private static void Main (string[] args)
    {
        SetupConsole();

        Test();

        Console.ReadKey();
    }

    //------------------------------------------------------------------
    private static void SetupConsole()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Clear();
    }

    //------------------------------------------------------------------
    public static void Out (string text)
    {
        Console.WriteLine (text);
    }

    //------------------------------------------------------------------
    public static void Test()
    {
//        string ftpurl = "ftp://ftp.swfwmd.state.fl.us/pub/incoming/";
//        string filename = "GPS.txt";
//
//        FtpWebRequest ftpClient = (FtpWebRequest) FtpWebRequest.Create (ftpurl + filename);
//        ftpClient.Credentials = new System.Net.NetworkCredential ("Anonymous", "TrashBoxMails@Gmail.com");
//        ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
//        ftpClient.UseBinary = true;
//        ftpClient.KeepAlive = true;
//        System.IO.FileInfo fi = new System.IO.FileInfo (filename);
//        ftpClient.ContentLength = fi.Length;
//        byte[] buffer = new byte[4097];
//        int bytes = 0;
//        int total_bytes = (int) fi.Length;
//        System.IO.FileStream fs = fi.OpenRead ();
//        System.IO.Stream rs = ftpClient.GetRequestStream ();
//        while (total_bytes > 0)
//        {
//            bytes = fs.Read (buffer, 0, buffer.Length);
//            rs.Write (buffer, 0, bytes);
//            total_bytes = total_bytes - bytes;
//        }
//        //fs.Flush();
//        fs.Close ();
//        rs.Close ();
//        FtpWebResponse uploadResponse = (FtpWebResponse) ftpClient.GetResponse ();
//        var value = uploadResponse.StatusDescription;
//        uploadResponse.Close ();


//        int num1 = 10, num2 = 9;
//        int result = num1 ^ num2;


//        string s = @"Joe saud\t""Hello"" tome!";
//        Console.WriteLine(s);
//        Console.ReadLine();


//        decimal val = Math.Ceiling (2.5m);
//                Console.WriteLine(val);
//        Console.ReadLine ();


        Dictionary <int, int> dictionary = new Dictionary <int, int>();

        dictionary[0] = 10;
        Console.WriteLine (dictionary[0]);
        Console.ReadLine ();
    }
}