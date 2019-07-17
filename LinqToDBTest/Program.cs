using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using peppa.Domain;
using LinqToDB.Data;

namespace LinqToDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB("peppaConnectionString"))
            {
                var q =
                    from c in db.Account
                    select new
                    {
                        c.account_id,
                        c.is_valid
                    };

                foreach (var c in q)
                    Console.WriteLine(c);
            }
        }
    }
}
