using System;

namespace CreateCustomer_Eplus_Kiot
{
    public class BodyRequest
    {
        public static string GetBodyCustomer(string code, string name, string tel, string address)
        {
            return "{" +
                   $"\"code\": \"{code}\"," +
                   $"\"name\": \"{name}\"," +
                   $"\"contactNumber\": \"{tel}\"," +
                   $"\"address\": \"{address}\"," +
                   "\"branchId\":3634," +
                   "\"groupIds\":116050" +
                   "}";
        }

        
        public static string GetBodySku(string code, string name, string unit)
        {
            return "{" +
                   $"\"code\": \"{code}\"," +
                   $"\"name\": \"{name}\"," +
                   "\"categoryId\": 720186," +
                   "\"allowsSale\": false," +
                   $"\"unit\": \"{unit}\"," +
                   "\"branchId\":3634" +
                   "}";
        }

        public static string GetbodyAuth(string id, string secret)
        {
            return "scopes=PublicApi.Access&grant_type=client_credentials&client_id=" + id + "&client_secret=" + secret;
        }
    }
}