using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braintree;
namespace TestBrain
{
    public class appCustomer{
        public appCustomer(String custID, String streetAddress, String city, String state,String zip, String fName, String lName, String email, String phone, String cardNumber ){
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "bmb8xhsjp2p9pb75",
                PublicKey = "vcy2btmbyxcpjr9p",
                PrivateKey = "bf218a4db6e6146be2a4855e4774dd16"
            };
            var request = new CustomerRequest
            {
                FirstName = fName,
                LastName = lName,
                Email = email,
                Phone = phone,
            };
            Result<Customer> result = gateway.Customer.Create(request);

            bool success = result.IsSuccess();
            if (result.IsSuccess())
            {
            
                Console.WriteLine("Success!: " + result.Target.Id);
            }
        }

    }

}
