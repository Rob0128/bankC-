using System;
using System.Collections.Generic;

namespace bank
{

    public static class Counter
    {
        public static int nextAccountNum = 1000;
    }
    public abstract class Account
    {
        public abstract String accType();

        public int accountNo;

        public Account()
        {
            accountNo = Counter.nextAccountNum;
            Counter.nextAccountNum++;
        }

        public abstract string getAccName();


    }

    public class personalAccount : Account
    {

        public string firstName;
        public string lastName;

        public personalAccount(string fname, string lname)
        {
            firstName = fname;
            lastName = lname;
        }

        public override string getAccName()
        {
            string accName = firstName + " " + lastName;
            return accName;
        }

        public override string accType()
        {
            return "personal";
        }
    }

    public class bussinessAccount : Account
    {

        public string busName;

        public bussinessAccount(string name)
        {
            busName = name;
        }

        public override string getAccName()
        {
            return busName;
        }

        public override string accType()
        {
            return "business";
        }


    }

    public class accountPermissions
    {

        public static string accountPerm(Account x)
        {
            switch (x.accType())
            {
                case "personal":
                    return "You have access to personal features";

                case "business":
                    return "You have access to business features";

                case "joint":
                    return "You have access to joint acount features";

                default:
                    return "invalid account";
            }
        }
    }

    public class jointAccount : Account
    {

        List<Account> accHolders = new List<Account>();
        public jointAccount(params Account[] args)
        {
            foreach (Account x in args)
            {
                accHolders.Add(x);
            }

        }

        public override string getAccName()
        {
            string ret = "";

            foreach (Account i in accHolders)
            {
                ret = ret + i.getAccName() + "\n";
            }
            return ret;
        }

        public override string accType()
        {
            return "joint";
        }
    }

    public class initialiser
    {

        public static void Main()
        {
            personalAccount a1 = new personalAccount("tom", "e");
            Console.WriteLine(a1.accountNo);
            personalAccount a2 = new personalAccount("tom", "e");
            Console.WriteLine(a2.accountNo);
            Console.WriteLine(a2.getAccName());
            bussinessAccount a3 = new bussinessAccount("Maccas");
            Console.WriteLine(a3.getAccName());
            Console.WriteLine(accountPermissions.accountPerm(a3));
            jointAccount a4 = new jointAccount(a2, a3);
            Console.WriteLine(a4.accountNo);
            Console.WriteLine(a4.getAccName());
        }
    }

}