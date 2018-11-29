using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostClassDemo.Models
{
	public class Payment
	{

		public static string RunPayment()
		{
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

			// define the merchant information (authentication / transaction id)
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication =
				new merchantAuthenticationType()
				{
					name = "3Q36ttuxXa",
					ItemElementName = ItemChoiceType.transactionKey,
					Item = "6up9ffJ84QE5rG3E",
				};


			// We can hardcode the CC number or we can grab it from the secrets file. 
			var creditCard = new creditCardType
			{
				cardNumber = "4111111111111111",
				expirationDate = "0519"
			};

			// set the credit card as the payment type
			var paymentType = new paymentType { Item = creditCard };

			var transactionRequest = new AuthorizeNet.Api.Contracts.V1.transactionRequestType
			{
				transactionType = transactionTypeEnum.authOnlyTransaction.ToString(),
				amount = 1.01m,
				payment = paymentType
				// bill to and Lineitems are optional

			};

			// attach the transaction from above to a new request
		 var request = new createTransactionRequest { transactionRequest = transactionRequest };

			var controller = new AuthorizeNet.Api.Controllers.createTransactionController(request);
			controller.Execute();


			//var response = controller.GetApiResponse();

			//if(response.messages.resultCode == messageTypeEnum.Ok)
			//{
			//	// redirect to the receipt page with the order information
			//}

			return "invalid";
		}
	}
}
