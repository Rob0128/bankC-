using System;
using System.Collections.Generic;

namespace bank
{

    //Misc static functions
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

    public class Checkers
    {

        public static bool checkPositive(int number)
        {
            if (number < 0)
            {
                return false;
            }
            else
            {
                return true;
            }

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
            a4.deposit(400);
            Console.WriteLine(a4.accountBalance);
            Console.WriteLine(a1.accountBalance);
            pay.paySomeOne(a4, a1, 400);
            System.Console.WriteLine(a1.accountBalance);
            System.Console.WriteLine(a4.accountBalance);
            a4.deleteAccount(1003);
            System.Console.WriteLine(a4.accountBalance);
            Console.WriteLine(a4.accountNo);
            pay.paySomeOne(a1, a3, 400);
        }
    }

}