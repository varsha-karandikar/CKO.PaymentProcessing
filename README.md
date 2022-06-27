# CKO.PaymentProcessing
This repository includes 2 components: (Also highlighted in pink rectange in Img 1)

1. Payment Gateway APIs
This is a .Net6 Web API project which exposes following 2 APIs:

![image](https://user-images.githubusercontent.com/4521723/175946208-d8da8b1b-84c2-47ec-b2ae-418c37b373b5.png)

The POST API can be used by any merchants to make a payment using customer's card details, while the GET API can be utilized by merchants to retrive previous payment details.

2. CKO.BankSimulator
 This component is a .Net 6 Class Library which is acting as Acquiring bank to process our payments. This uses an Im-Memory DB collection to store payment details and retrieves the details from the in-memory collection.
   
![image](https://user-images.githubusercontent.com/4521723/175814204-d22c7e59-6162-4cce-b1a7-66c44db54c46.png)
Img 1

# Technology Stack
It uses following tech:
-	Visual Studio 2022
-	.Net 6
-	EntityFramework Core In-Memory collection
- Authentication is done using JWT token.

# Assumptions
- The CKO Bank Simulator does not validate card details as per any rules( issuer schema), and does not validate funds present in given card number.
- This API only considers cardholder card details (cardnumber, expiry, Cvv) to make a payment. Other methods like tokenised card details, or performing card transactions from Terminal are not supported.


# How to Run
Steps:
-	Clone the repo from link: https://github.com/varsha-karandikar/CKO.PaymentProcessing.git
-	Press Ctrl + F5 to build and run the Web Apis
-	It will open Swagger page : http://localhost:5204/swagger/index.html which lists down all APIs as below:
![image](https://user-images.githubusercontent.com/4521723/175974182-7285b11f-2ce7-4aae-afc2-086d5dffa270.png)

- First, we need to generate Auth Token to allow access to Payment APIs:
- Click on /login API and click on Try It Out
- The sample request body as below:
{
  "merchantId": "1004",
  "secret": "mySecret1004"
}

- This will provide a token in Response. Copy the token
- Click on Authorize at the top right corner.
- Add copied token in the textbox.
- To create payment:
- Hit /Payment API and provide request body as below:
{
  "merchantId": "1004",
  "cardNumber": "5521370103998437",  //card numbers needs to be valid
  "expirationMonth": 12,
  "expirationYear": 2025, //expiration year should be valid
  "cvv": "123",
  "currencyCode": "USD",
  "amount": 10,
  "requestId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
and click on Execute:

If request is successful, it returns below response:
{
  "id": 1,
  "transactionTime": "2022-06-27T15:00:01.7011908Z",
  "paymentDetails": {
    "processorName": "CKO.BankSimulator.MockProcessor",
    "paymentStatus": "Approved",
    "amount": 10
  },
  "card": {
    "cardLogo": 1,
    "maskedCardNumber": "552137******8437"
  },
  "merchantId": "1004",
  "industryCode": null,
  "currencyCode": "USD"
}

- To retrieve previous payment details, hit API /Payment/{paymentId}, provide the paymentId of previous payment and hit on Execute.
- If paymentId exsists, this returns response as :
{
  "id": 1,
  "transactionTime": "2022-06-27T15:00:01.7011908Z",
  "paymentDetails": {
    "processorName": "CKO.BankSimulator.MockProcessor",
    "paymentStatus": "Approved",
    "amount": 10
  },
  "card": {
    "cardLogo": 1,
    "maskedCardNumber": "552137******8437"
  },
  "merchantId": "1004",
  "industryCode": null,
  "currencyCode": "USD"
}
- If the paymentId, does not exist, this results in 404 result.

# Areas of Improvement
The component CKO.BankSimulator has been built using Inmemory collection, and it saves card details for the time when its run.
These APIs will require richer fields to have more data from Customer, and will require strict validations to implement.
Further. the Bank Simulator will be a  separate service which will be called via HTTP/HTTPS

# Using cloud Technologies 
1. The Paymentgateway APIs can be deployed using Azure App Service or AWS Elastic Beanstalk.
2. The Payment Gateway will communicate with Acquiring Bank using HttpCommunication. We can have a wrapper build around IPaymentProcessingService to call Acquiring Bank APIs.
3. Here Security is managed by using local JWT tokens. however, for this separate IdentityService can be used to authenticate.This service can be used with API Gateway (BFF) for Authentication.
