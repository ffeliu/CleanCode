using System;
using System.Runtime.Remoting.Messaging;

namespace CleanCode.NestedConditionals.Refactor
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }

        public bool IsGoldMember() => LoyaltyPoints > 100;
    }

    public class Reservation
    {
        public const int GoldCustomersCancelUp24Hours = 24;
        public const int NormalCustomersCancelUp24Hours = 48;

        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            if (IsAlreadyStarted() || CancelationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        private bool IsAlreadyStarted() => DateTime.Now > From;

        private bool CancelationPeriodOver()
        {
            return (Customer.IsGoldMember() && IsReservationLessThan(GoldCustomersCancelUp24Hours)) ||
                            !Customer.IsGoldMember() && IsReservationLessThan(NormalCustomersCancelUp24Hours);
        }

        

        private bool IsReservationLessThan(int hours) => (From - DateTime.Now).TotalHours < hours;
    }
}
