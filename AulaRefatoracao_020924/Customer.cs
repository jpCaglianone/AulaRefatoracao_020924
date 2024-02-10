using System;
using System.Collections.Generic;

public class Customer
{
    private string name;
    private List<Rental> rentals = new List<Rental>();

    public Customer(string name)
    {
        this.name = name;
    }

    public void AddRental(Rental arg)
    {
        rentals.Add(arg);
    }

    public string GetName()
    {
        return name;
    }

    public string Statement()
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;
        string result = "Rental Record for " + GetName() + "\n";

        foreach (Rental rental in rentals)
        {
            double thisAmount = 0;

            // Determine amounts for each line
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.GetDaysRented() > 2)
                        thisAmount += (rental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (rental.GetDaysRented() > 3)
                        thisAmount += (rental.GetDaysRented() - 3) * 1.5;
                    break;
            }

            // Add frequent renter points
            frequentRenterPoints++;
            // Add bonus for a two day new release rental
            if ((rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && rental.GetDaysRented() > 1)
                frequentRenterPoints++;

            // Show figures for this rental
            result += "\t" + rental.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n";
            totalAmount += thisAmount;
        }

        // Add footer lines
        result += "Amount owed is " + totalAmount.ToString() + "\n";
        result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";
        return result;
    }
}

