# CarHouse
Car House Inventory System

#Database Approach
I have chosen the code-first DB approach.
My reasoning for this includes:
.Net 6 does not support the DB first edmx view.
Edmx's are very cumbersome to merge GIT changes.
DB first cannot be used to deploy instances of the database, requiring doing without or managing separate SQL Projects.

#Data Choices

##Tables
I have implemented a separate table for Cars, Customers and Sales.
This seemed reasonable given the requirements, i could see value in adding a Employee's table to link to the Sales
instead of simply stamping the salesman name.

##General Design
Used as small datatypes as seemed reasonable.
Everything is not null except the Car.Notes as specified.

##Cars
###Registration number - NVARCHAR(7) Australian number plates are not longer than 7 characters.
###Year - Stored as an integer, no partial years, no need for additional date info.
###OdometerKM - int, Specified units in name, no need for decimals.
###Advertised Price - Decimal(10,2) room for 2 decimal places, 8 value places max value of 99,999,999 is plenty.
###Notes - NVARCHAR(2000) 2000 seems reasonable, limited for efficiencies sake, MAX would prevent indexing if that were to become a requirement.
###AcquiredDate - DateTimeOffset(7) important to keep offset on this to avoid timezone issues.
###AvailableFlag - bit either sold or not. (could have brought this out into an enum states table to cover more cases i.e under order)

##Customers
###Names: NVARCHAR(100) seems a reasonable length.
###DriversLicenseNo: NVARCHAR(11) number of characters in an australian drivers license
###ContactNumber: NCHAR(10) No VAR to help limit special Characters
###ResidentialPostCode: CHAR(4) should always be 4 numbers, int also an option but wouldn't validate number of characters.

##Sales
###AdvertisedPrice/SaleAmount both decimal(10,2) to make Advertised price on car.
###SalesmanName - NVARCHAR(200) combined room of first_last name.

#Validation
Due to time constraints, nothing has been implemented beyond HTML input type limitations, required form fields and DB Data types.

