using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace OOPEksamensprojekt.Core
{
    public static class CsvReader
    {

        public static List<Product> GetProductsFromCsv()
        {
            List<Product> products = new List<Product>();
            using (TextFieldParser reader = new TextFieldParser("../../../products.csv"))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(";");
                reader.ReadFields();
                while (!reader.EndOfData)
                {
                    string[] fields = reader.ReadFields();
                    int id = Convert.ToInt32(fields[0]);
                    string name = Regex.Replace(fields[1], "<[^>]*>", String.Empty);
                    decimal price = Convert.ToDecimal(fields[2]);
                    bool active = Convert.ToBoolean(Convert.ToInt32(fields[3]));
                    
                    products.Add(new Product(id, name, price, active));
                }
            }

            return products;
        }
        
        public static List<User> GetUsersFromCsv()
        {
            List<User> users = new List<User>();
            using (TextFieldParser reader = new TextFieldParser("../../../users.csv"))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");
                reader.ReadFields();
                while (!reader.EndOfData)
                {
                    string[] fields = reader.ReadFields();
                    int id = Convert.ToInt32(fields[0]);
                    string firstname = fields[1];
                    string lastname = fields[2];
                    string username = fields[3];
                    decimal balance = Convert.ToDecimal(fields[4]);
                    string email = fields[5];

                    users.Add(new User(id, firstname, lastname, username, email, balance));
                }
            }

            return users;
        }


    }
}