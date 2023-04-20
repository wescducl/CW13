using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;


namespace BankTest
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountHigherThanBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 14.55;

            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
        }// unit test code


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_WhenAccountFrozen()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;

            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.ToggleFreeze();
        account.Debit(debitAmount);
        }// unit test code  

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            try 
   {  
       account.Debit(debitAmount);  
   }  
   catch (ArgumentOutOfRangeException e)  
   {  
       // assert  
       StringAssert.Contains(e.Message, BankAccount.                                        DebitAmountExceedsBalanceMessage);  
   }
        }
        //unit test method  
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert is handled by ExpectedException  
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double CreditAmount = 1.00;
            double expected = 12.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Credit(CreditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            
        }

    }
}
