using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.SwitchStatements
{
    public class UnlimitedCustomer : Customer
    {
        public UnlimitedCustomer()
        {

        }

        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement();

            statement.TotalCost = 54.90f;

            return statement;
        }
    }
}
