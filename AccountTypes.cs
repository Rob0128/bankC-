using System;
using System.Collections.Generic;

namespace bank
{

    //General account
    public abstract class Account
    {
        public abstract String accType();

        public int accountNo;

        public int accountBalance;

        public Account()
        {
            accountNo = Counter.nextAccountNum;
            Counter.nextAccountNum++;
            accountBalance = 0;
        }

        public abstract string getAccName();


    }

    public static class Counter
    {
        public static int nextAccountNum = 1000;
    }

    //Specific Accounts

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




}