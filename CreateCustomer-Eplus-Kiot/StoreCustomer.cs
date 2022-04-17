using System;
using System.Data.SqlTypes;
using System.Net;
using CreateCustomer_Eplus_Kiot;
using Microsoft.SqlServer.Server;

public class StoreCustomer
{
    private const string CLIENT_SECRET = "9BE94DC179BB890F4AB1DC7EFF16F819B10C11C5";
    private const string CLIENT_ID = "2c181bb5-10a9-4063-8a94-9e89f20564f0";
    private const string URL_TOKEN = "https://id.kiotviet.vn/connect/token";
    private const string URL_API = "https://public.kiotapi.com/";
    private const string CUSTOMER = "customers";
    private const string SKU = "products";

    // tooken

    [SqlProcedure]
    public static void CreateCustomer(String name, String code, String tel, String address, out SqlString text)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.
    
        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string bodyCustomer = BodyRequest.GetBodyCustomer(code, name, tel,address);
        string customer = Api.Post(URL_API + CUSTOMER, bodyCustomer, token);
        text = customer;
    }
    
    [SqlProcedure]
    public static void CreateSku(String code, String name, String unit, out SqlString text)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string bodyCustomer = BodyRequest.GetBodySku(code, name, unit);
        string customer = Api.Post(URL_API + SKU, bodyCustomer, token);
        text = customer;
    }


    static void Main(string[] args)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.
    
        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string bodyCustomer = BodyRequest.GetBodyCustomer("thangvm", "name", "tel","address");
        string customer = Api.Post(URL_API + CUSTOMER, bodyCustomer, token);
        Console.WriteLine(customer);
    }
    
}