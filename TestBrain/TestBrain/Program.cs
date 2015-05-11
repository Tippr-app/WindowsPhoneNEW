﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braintree;


namespace TestBrain
{
    class Program
    {
        static void Main(string[] args)
        {
   
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "bmb8xhsjp2p9pb75",
                PublicKey = "vcy2btmbyxcpjr9p",
                PrivateKey = "bf218a4db6e6146be2a4855e4774dd16"
            };

            TransactionRequest request = new TransactionRequest
            {
                Amount = 1.25M,
                CreditCard = new TransactionCreditCardRequest
                {
                    Number = "378282246310005",
                    ExpirationDate = "05/2016"
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                Console.WriteLine("Success!: " + transaction.Id);
            }
            else if (result.Transaction != null)
            {
                Transaction transaction = result.Transaction;
                Console.WriteLine("Error processing transaction:");
                Console.WriteLine("  Status: " + transaction.Status);
                Console.WriteLine("  Code: " + transaction.ProcessorResponseCode);
                Console.WriteLine("  Text: " + transaction.ProcessorResponseText);
            }
            else
            {
                foreach (ValidationError error in result.Errors.DeepAll())
                {
                    Console.WriteLine("Attribute: " + error.Attribute);
                    Console.WriteLine("  Code: " + error.Code);
                    Console.WriteLine("  Message: " + error.Message);
                }
            }
        }
    }
}