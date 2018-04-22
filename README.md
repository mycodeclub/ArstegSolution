# ArstegSolution Machine test asdf 

NOTE : Application is build in Visual Studio 2017 and MVC 5.

Following are the test detail.

Create a page in in ASP.Net or ASP.NET MVC in which you should be able to create and save tax Slabs of an employee.
you should be able to edit and delete these slabs information.

Now accept the gross salary of an employee and calculate the net salary (calculate tax based on the saved slabs)
net salary = gross salary - tax

For example:
The tax slabs are:

0 to 2,50,000 			                0%
2,50,000  to 5,00,000			10%
5,00,000 to 10,00,000			20%
more than 10,00,000			30%

Tax Calculation Procedure: 

If an employee's salary is 6,00,000. Then his salary will go through first three tax slabs i.e.

First, 2,50,000 of his salary is non-taxable as per the first slab, Now remaining is 3,50,000.
then next 2,50,000 will be taxable at the rate of 10% as per the second slab, Now Remaining is 1,00,000.
then remaining 1,00,000 will be taxable at the rate of 20% as per the third slab.

Note: The above example is just for reference. Allow the user to create his own slabs.
