using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://huauchinango.tecnm.mx/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DecBin(int valor)
    {
        int r;
        string bin = "";
        while (valor >= 2)
        {
            r = valor % 2;
            valor = valor / 2;
            bin = r.ToString() + bin;
        }
        bin = valor.ToString() + bin;
        return bin;
    }
    [WebMethod]
    public int BinDec(String valor)
    {
        int s = 0;
        int pos = valor.Length - 1;
        int p = 0;
        while (pos >= 0)
        {
            int n = Convert.ToInt16(valor[pos].ToString());
            s = s + (n * Convert.ToInt16(Math.Pow(2, p)));
            p = p + 1;
            pos = pos - 1;
        }
        return s;
    }
    [WebMethod]
    public string DecOct(int valor)
    {
        string cade = "";
        while (valor >= 8)
        {
            int r = valor % 8;
            valor = valor / 8;
            cade = r.ToString() + cade;
        }
        cade = valor.ToString() + cade;
        return cade;
    }
    [WebMethod]
    public int OctDec(string valor)
    {
        int s, p, pos, v;
        s = 0;
        p = 0;
        pos = valor.Length - 1;
        while (pos >= 0)
        {
            v = Convert.ToInt16(valor[pos].ToString());
            s = s + Convert.ToInt16(v * (Math.Pow(8, p)));
            p = p + 1;
            pos = pos - 1;
        }
        return s;
    }
    [WebMethod]
    public string DecHex(int valor)
    {
        string res = "";
        int r;
        while (valor >= 16)
        {
            r = valor % 16;
            valor = valor / 16;
            res = CadHex(r) + res;
        }
        res = CadHex(valor) + res;
        return res;
    }
    public string CadHex(int n)
    {
        string car = "";
        if (n > 9)
        {
            car = ((char)(n+55)).ToString();
            /*switch (n)
            {
                case 10:
                    car = "A"; break;
                case 11:
                    car = "B"; break;
                case 12:
                    car = "C"; break;
                case 13:
                    car = "D"; break;
                case 14:
                    car = "E"; break;
                case 15:
                    car = "F"; break;
            }*/
        }
        else
        {
            car = n.ToString();
        }
        return car;
    }
    [WebMethod]
    public long HexDec(string valor)
    {
        int pos, p, v;
        long s = 0;
        p = 0;
        pos = valor.Length - 1;
        while (pos >= 0)
        {
            v = ValHex(valor[pos]);
            s = s + Convert.ToInt32(v * Math.Pow(16, p));
            p = p + 1;
            pos = pos - 1;
        }
        return s;
    }
    public int ValHex(char c)
    {
        int res = 0;
        
        if (c >= '0' && c <= '9')
            res = Convert.ToInt16(c) - 48;
        if (c >= 'A' && c <= 'F')
            res = Convert.ToInt16(c) - 55;
        if (c >= 'a' && c <= 'f')
            res = Convert.ToInt16(c) - 87;
        /* int cod;
        cod = Convert.ToInt16(c);
        if (cod >= 48 && cod <= 57)
        {
            res = Convert.ToInt16(c.ToString());
        }
        else
        {
            if (cod == 65 || cod == 97) res = 10;
            if (cod == 66 || cod == 98) res = 11;
            if (cod == 67 || cod == 99) res = 12;
            if (cod == 68 || cod == 100) res = 13;
            if (cod == 69 || cod == 101) res = 14;
            if (cod == 70 || cod == 102) res = 15;
        }*/
        return res;
    }
    [WebMethod]
    public string BinOct(string valor)
    {
        string oct = "";
        int dec;
        dec = BinDec(valor);
        oct = DecOct(dec);
        return oct;
    }
    [WebMethod]
    public string BinHex(string valor)
    {
        string hex = "";
        int dec;
        dec = BinDec(valor);
        hex = DecHex(dec);
        return hex;
    }
    [WebMethod]
    public string OctHex(string valor)
    {
        string hex = "";
        int dec;
        dec = OctDec(valor);
        hex = DecHex(dec);
        return hex;
    }
    [WebMethod]
    public string HexOct(string valor)
    {
        string oct = "";
        long dec;
        dec = HexDec(valor);
        oct = DecOct(Convert.ToInt16(dec));
        return oct;
    }
    [WebMethod]
    public string OctBin(string valor)
    {
        string bin = "";
        int dec;
        dec = OctDec(valor);
        bin = DecBin(dec);
        return bin;
    }
    [WebMethod]
    public string HexBin(string valor)
    {
        string bin = "";
        long dec;
        dec = HexDec(valor);
        bin = DecBin(Convert.ToInt16(dec));
        return bin;
    }
}