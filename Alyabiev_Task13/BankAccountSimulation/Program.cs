using System;

using BankAccountExceptions;

using EugeneAnykey.DebugLib.Loggers;

namespace BankAccountSimulation
{
	public class Program
	{
		static ILogger logger = new ConsoleLogger();

		#region break line
		const string breakLine = "\n===================\n\n";

		static void WriteBreak()
		{
			Console.WriteLine(breakLine);
		}
		#endregion

		static void Main(string[] args)
		{
			Console.WriteLine("[Task 13 - 1] Exceptions Model.\n");

			// exception catches examples:
			BadNameExample();
			BadIdentificationExample();
			BadWithdrawExample_NoMoney();
			BadWithdrawExample_FourTimes();


			// normal scenario 1:
			WriteBreak(); 
			SavingAccount_GoodScenario();

			// normal scenario 1:
			WriteBreak();
			CurrentAccount_GoodScenario();

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		#region Good scenarious.
		static void SavingAccount_GoodScenario()
		{
			BankAccount account = null;

			try
			{
				account = new SavingBankAccount("Sarvesh", "S12345");
			}
			catch (Exception e)
			{
			}

			try
			{
				BankAccount_GoodScenario_SavingAccount(account);
			}
			catch (AccountException e)
			{
				logger.Write(e.Message);
			}
		}

		static void CurrentAccount_GoodScenario()
		{
			BankAccount account = null;

			try
			{
				account = new CurrentBankAccount("Mark", "C12345");
			}
			catch (Exception e)
			{
			}

			try
			{
				BankAccount_GoodScenario_CurrentAccount(account);
			}
			catch (AccountException e)
			{
				logger.Write(e.Message);
			}
		}
		#endregion

		static void BankAccount_GoodScenario_SavingAccount(BankAccount acc)
		{
			if (acc == null)
				throw new AccountException("No account passed.");


			try
			{
				acc.Deposit(40000);
			}
			catch (DepositException e)
			{
				logger.Write(e.Message);
			}


			try
			{
				acc.Withdraw(1000);
				acc.Withdraw(1000);
				acc.Withdraw(1000);
			}
			catch (WithdrawException e)
			{
				logger.Write(e.Message);
			}


			try
			{
				acc.GenerateAccountReport();
			}
			catch (ReportException e)
			{
				logger.Write(e.Message);
			}
		}

		static void BankAccount_GoodScenario_CurrentAccount(BankAccount acc)
		{
			if (acc == null)
				throw new AccountException("No account passed.");


			try
			{
				acc.Deposit(190000);
			}
			catch (DepositException e)
			{
				logger.Write(e.Message);
			}


			try
			{
				acc.Withdraw(1000);
			}
			catch (WithdrawException e)
			{
				logger.Write(e.Message);
			}


			try
			{
				acc.GenerateAccountReport();
			}
			catch (ReportException e)
			{
				logger.Write(e.Message);
			}
		}

		#region bad scenarios
		static void BadNameExample()
		{
			logger.Write("[example] Bad Name.");
			try
			{
				BankAccount savingAccount1 = new SavingBankAccount(null, "S12345");
			}
			catch (NameException e)
			{
				logger.Write(e.Message);
			}
		}

		static void BadIdentificationExample()
		{
			logger.Write("[example] Bad Identification.");
			try
			{
				BankAccount currentAccount1 = new CurrentBankAccount("Mark", null);
			}
			catch (IdentificationException e)
			{
				logger.Write(e.Message);
			}
		}

		static void BadWithdrawExample_NoMoney()
		{
			BankAccount savingAccount = new SavingBankAccount("Sarvesh", "S12345");
			logger.Write("[example] Bad withdraw: no money.");
			try
			{
				savingAccount.Withdraw(1000);
			}
			catch (WithdrawException e)
			{
				logger.Write(e.Message);
			}
		}

		static void BadWithdrawExample_FourTimes()
		{
			BankAccount savingAccount = new SavingBankAccount("Sarvesh", "S12345");

			savingAccount.Deposit(5000);
			logger.Write("[example] Bad withdraw: more than 3 times.");
			try
			{
				savingAccount.Withdraw(50);
				savingAccount.Withdraw(100);
				savingAccount.Withdraw(200);
				savingAccount.Withdraw(400);
			}
			catch (WithdrawException e)
			{
				logger.Write(e.Message);
			}
		}
		#endregion
	}
}
