using System;
using System.Collections.Generic;

namespace bank
{

    //General account
    public abstract class Account
    {
        public abstract String accType();

        private static int nextAccountNum = 1000;
        private int? _accountNo;

        public int? accountNo { get { return _accountNo; } }

        private int _accountBalance;
        public int accountBalance { get { return _accountBalance; } }

        public void deposit(int amount)
        {
            if (accountNo == null)
            {
                System.Console.WriteLine("Invalid account");
            }
            else
            {
                _accountBalance += amount;
            }
        }

        public void withdraw(int amount)
        {
            if (accountNo == null)
            {
                System.Console.WriteLine("Invalid account");
            }
            else
            {
                if (_accountBalance >= amount)
                {
                    _accountBalance -= amount;
                }
                else
                {
                    System.Console.WriteLine("Not enough money");
                }
            }
        }

        public Account()
        {
            _accountNo = nextAccountNum;
            nextAccountNum++;
            _accountBalance = 0;
        }

        public abstract string getAccName();

        public void deleteAccount(int accountNumber)
        //Would usually delete from database but here will just nullify account no
        {
            if (accountNumber == this._accountNo)
            {
                if (this.accountBalance == 0)
                {
                    this._accountNo = null;

                }
                else
                {
                    Console.WriteLine("Balance must be 0");
                }
            }
            else
            {
                Console.WriteLine("Account number is incorrect");
            }
        }


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