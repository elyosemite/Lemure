using System;

namespace Lemure.DesignPatterns.RulesEngine.Extensions;

public static class CustomerExtensions
{
    public static bool HasBeenLoyalForYears(this Customer customer, int numberOfYears, DateTime? date = null)
    {
        if (!customer.IsExisting()) return false;

        numberOfYears = -1 * numberOfYears;

        return customer.DateOfFirstPurchase < date.ToValueOrDefault().AddYears(numberOfYears);
    }

    public static bool IsExisting(this Customer customer)
    {
        return customer.DateOfFirstPurchase.HasValue;
    }

    public static bool IsSenior(this Customer customer, DateTime? date = null)
    {
        return customer.DateOfBirth < date.ToValueOrDefault().AddYears(-65);
    }

    public static bool IsBirthday(this Customer customer, DateTime? date = null)
    {
        date = date.ToValueOrDefault();

        return customer.DateOfBirth?.Day == date?.Day
            && customer.DateOfBirth?.Month == date?.Month;
    }
}