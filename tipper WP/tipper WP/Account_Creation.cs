using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braintree;

namespace tipper_WP
{
    class Account_Creation
    {
        public string customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        //address getters and setters 
        public string street_address { get; set;}
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        //cc info 
        public string ccNumber { get; set; }
        public string exp { get; set; }
        public string ccv { get; set; }

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
            customerID = _customerID;
            create_account();
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
            if (success){
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



    }
}
