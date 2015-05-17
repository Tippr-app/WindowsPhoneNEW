﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Braintree;

namespace TestBrain
{
    class Account_Creation
    {
        public string customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        //address getters and setters 
        public string street_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        //cc info 
        public string ccNumber { get; set; }
        public string exp { get; set; }
        public string ccv { get; set; }
        string connectionString =
                    "Server=tcp:z18y76s6f5.database.windows.net,1433;Database=Tippr;User ID=tippr@z18y76s6f5;Password=Password#1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        public Account_Creation(string _customerID, string _firstName, string _lastNAme, string _email, string _streetAddress, string _city, string _state, string _zip, string _phone, string _ccNumber, string _exp, string _ccv)
        {
            firstName = _firstName;
            lastName = _lastNAme;
            email = _email;
            street_address = _streetAddress;
            city = _city;
            state = _state;
            zip = _zip;
            phone = _phone;
            ccNumber = _ccNumber;
            exp = _exp;
            var new_id = Regex.Replace(_customerID, "[^0-9]", "");
            customerID = new_id;
            ccv = _ccv;
            //create_account();
            //InsertAccount();
           // newTransaction(2.5, 11111140, 11111141);
            Console.Write(getBalance(11111141));
        }

        /// <summary>
        /// create account 
        /// </summary>
        /// <returns>true if created from brain tree success false else </returns>
        public bool create_account()
        {
            //TODO: insert code here 
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "bmb8xhsjp2p9pb75",
                PublicKey = "vcy2btmbyxcpjr9p",
                PrivateKey = "bf218a4db6e6146be2a4855e4774dd16"
            };

            var request = new CustomerRequest
            {
                FirstName = this.firstName,
                LastName = this.lastName,
                Email = this.email,
                Phone = this.phone,
                Id = this.customerID,
                CustomerId = this.customerID,
                CreditCard = new CreditCardRequest
                {
                    Number = this.ccNumber,
                    CVV = this.ccv,
                    ExpirationDate = this.exp,
                    CardholderName = this.firstName + " " + this.lastName
                }


            };
            Result<Customer> result = gateway.Customer.Create(request);

            bool success = result.IsSuccess();
            if (success)
            {
                createAddress();
            }
            return success;
        }
        public bool createAddress(){
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "bmb8xhsjp2p9pb75",
                PublicKey = "vcy2btmbyxcpjr9p",
                PrivateKey = "bf218a4db6e6146be2a4855e4774dd16"
            };
            var request2 = new AddressRequest
            {
                FirstName = this.firstName,
                LastName = this.lastName,
                StreetAddress = this.street_address,
                Locality = this.city,
                Region = this.state,
                PostalCode = this.zip,
                CountryCodeAlpha2 = "US"
            };

            Result<Address> result = gateway.Address.Create(this.customerID, request2);
            bool success = result.IsSuccess();

            return success;
        }
        public bool InsertAccount()
        {
            try
            {
                
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("INSERT INTO Account VALUES(" +
                            "@Id, @UserName, @Password, @Balance)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", this.customerID);
                        cmd.Parameters.AddWithValue("@UserName", this.firstName + " " + this.lastName);
                        cmd.Parameters.AddWithValue("@Password", "1234");
                        cmd.Parameters.AddWithValue("@Balance", 0);

                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
            return true;
        }
        public double getBalance(int custID)
        {
            try
            {

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("Select Balance from Account where Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", custID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        //rows number of record got inserted if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return Convert.ToDouble(reader["Balance"]);
                            }
                        }

                        reader.Close();
                       
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return 0;
            }
            return 0;
            
        }
        public bool newTransaction(double amount, int toCustID, int fromCustID)
        {
            DateTime myDate = DateTime.Now;
            try
            {

     
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("INSERT INTO Transactions VALUES(" +
                            "@toId, @fromID, @Amount, @timeStamp)", conn))
                    {
                        cmd.Parameters.AddWithValue("@toId", toCustID);
                        cmd.Parameters.AddWithValue("@fromID", fromCustID);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@timeStamp", myDate);

                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
            return true;
        }
        public bool updateBalance(double newBalance, int custID)
        {
            try
            {
                
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("UPDATE Account SET Balance=@NewBalance" +
                    " WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", custID);
                        cmd.Parameters.AddWithValue("@NewBalance", newBalance);

                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                return false;
            }
            return true;
        }

    }
}

