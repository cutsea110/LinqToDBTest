using System;
using System.Diagnostics;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;

using peppa.Domain;

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
                db.Insert<AddressType>(new AddressType
                {
                    address_type_id = 0,
                    name = "現住所",
                    display_order = 0,
                });
                var q =
                    from a in db.AddressType
                    select new
                    {
                        a.address_type_id,
                        a.name,
                        a.created_at,
                        a.created_by,
                        a.modified_at,
                        a.modified_by,
                        a.row_version,
                    };

                foreach (var a in q)
                {
                    Console.WriteLine(a);
                    Debug.WriteLine(a);
                }

                var cond = new AddressTypeCondition
                {
                    name_eq = "現住所"
                };
                var pred = cond.CreatePredicate();
                var list = db.AddressType.Where(pred).ToList();
                foreach(var x in list)
                {
                    Console.WriteLine(x);
                    Debug.WriteLine(x);
                }
            }
        }
    }
}
