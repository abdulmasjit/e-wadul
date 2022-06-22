namespace Ewadul.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
public class AppHelper
{
    public static string GetMd5Hash(string input)
    {
        MD5 md5Hash = MD5.Create();
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }
    public static string generateKode(string prefix)
    {
        var date = DateTime.Now;
        //tahun
        var year = date.ToString("yy");
        //bulan
        var month = date.ToString("MM");
        //hari
        var day = date.ToString("dd");
        //jam
        var hours = date.ToString("HH");
        //menit
        var minutes = date.ToString("mm");
        //second
        var seconds = date.ToString("ss");
        //milisecond
        var milis = date.ToString("fff");
        var kode = prefix+year+month+day+hours+minutes+seconds+milis;
        return kode;
    }
}