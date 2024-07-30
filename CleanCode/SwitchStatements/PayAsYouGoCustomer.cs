using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.SwitchStatements
{
    public class PayAsYouGoCustomer : Customer
    {
        public PayAsYouGoCustomer()
        {

        }

        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement();

            statement.CallCost = 0.12f * monthlyUsage.CallMinutes;
            statement.SmsCost = 0.12f * monthlyUsage.SmsCount;
            statement.TotalCost = statement.CallCost + statement.SmsCost;

            return statement;
        }
    }
}
