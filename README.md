# CKO.PaymentProcessing
This application includes highlighted components, which has a PaymentGateway APIs exposed to Merchants.
Also, this includes a simulator for receiving requests and responding if the payment is approved or declined.

![image](https://user-images.githubusercontent.com/4521723/175813978-62f56fc6-7518-41ed-adfd-91571a8d5a76.png)

# Architecture

# Technology Stack
It uses following tech:
-	Visual Studio 2022
-	.Net 6
-	EntityFramework Core In-Memory collection

# Assumptions
The CKO Bank Simulator does not validate card details as per any rules( issuer schema), and does not validate funds present in given card number.

# How to Run
Steps:
-	Clone the repo from link: https://github.com/varsha-karandikar/CKO.PaymentProcessing.git

# Areas of Improvement
The component CKO.BankSimulator has been built using Inmemory collection, and it saves card details for the time when its run, assuming that payment gateway does not 

# Using cloud Technologies 
The Paymentgateway APIs can be deployed using Azure App Service or AWS Elastic Beanstalk.
The Payment Gateway will communicate with Acquiring Bank using HttpCommunication. We can have a wrapper build around IPaymentProcessingService to call Acquiring Bank
