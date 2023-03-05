using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class DBManagement
    {

        public static void GetAllData()
        {
            using (SberBankContext db = new SberBankContext())
            {

                Console.WriteLine("CLIENTS");
                ConsoleTable.From<Client>(db.Clients).Write();

                Console.WriteLine("DEPOSITS");
                ConsoleTable.From<Deposit>(db.Deposits).Write();

                Console.WriteLine("MANAGERS");
                ConsoleTable.From<Manager>(db.Managers).Write();

                Console.WriteLine("ACCOUNTS");
                ConsoleTable.From<Account>(db.Accounts).Write();

            }

        }
        public static void AddElementToDb<TEntity>(params TEntity[] entities) where TEntity :class
        {
            using (SberBankContext db = new SberBankContext())
            {
                foreach (var entity in entities)
                {
                    db.Set<TEntity>().Add(entity);

                }

                db.SaveChanges();
            }
        }
    }
}
