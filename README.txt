Checkout C# Test

Specification:

Requirements
Create a C# simple client and service for a supermarket checkout basket total.
The service must calculate the total price for a number of items by summing their prices
including applying any relevant discounts.

Goods are priced individually however there are weekly special offers for when multiple
items are bought. For example “Apples are 50p each or 3 for £1.30”.

Weekly offers change frequently so it is important to provide the ability to change them.
Example price list

SKU		Description   Unit Price	  Special Offer
A99		Apple		        0.50		    3 for 1.30
B15		Biscuits	      0.30		    2 for 0.45
C40		Coffee		      1.80
T23		Tissues		      0.99

The checkout client must accept the items in any order, and any multiples, and may not be
scanned in sequence. Upon checkout the basket must be sent to the service which will
return a total for the provided basket. The client will then display this.

The input (scan) to the application should be via command line, to keep the solution simple.
This should be in a separate project if part of one solution.

Notes:
The solution UI and data storage is not the subject of the test - so an MVP approach should
be used so long as it meets the requirements.

The solution setup / layout is important, and unit testing and test coverage should be
considered. As should defensive programming techniques.


My Solution:

Projects:
	Degree53: This is the project that hold the front end (console app)
	Degree53Logic: This project contains the backend logic such as solution models and services
	Degree53UnitTests: This project contains all of the unit tests implemented to prove the correctness of my solution

Altering the setup:

	There is no backend database in this solution. To customise the running of the application, got to Degree53Logic and open the services folder. 
	From here access the SetUpService class and modify the product and offer models as required.

Future work:

Given extra time I would like to use dependancy injection, for example if I were to use Unit I could do:

	// Create a new container
	var container = new UnityContainer();
	// Register the given object via its interface
	container.RegisterType<ICatalogue, Catalogue>();
	// Resolved the object from its interface when required later in the program
	var catalogue = container.Resolve<ICatalogue>();

I have included functionality to add and remove products/ offers from the system. However, I have not implemented the ability for the user to alter this data from the console app.
This could be implemented fairly easily but I decided against it for the simple fact that with no database the data would not persist between runnings of the console app. 
