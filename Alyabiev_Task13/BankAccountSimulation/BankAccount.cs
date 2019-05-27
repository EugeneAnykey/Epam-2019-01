using BankAccountExceptions;

namespace BankAccountSimulation
{
	public abstract class BankAccount
	{
		// thi variable will hold the summary of all the transaction that took place
		string transactionSummary;
		protected string TransactionSummary
		{
			get => transactionSummary;
			set => transactionSummary = value ?? string.Empty;
		}

		// Name of the Account Owner, Its common for all derived classes
		string accountOwnerName;
		public string AccountOwnerName
		{
			get => accountOwnerName;
			set => accountOwnerName = value ?? throw new NameException("You should set account's owner name.");
		}

		// Account Number field is a common field for all the account types
		string accountNumber;
		public string AccountNumber
		{
			get => accountNumber;
			set => accountNumber = value ?? throw new IdentificationException("You couldn't create an account without id.");
		}

		// A field to hold the Account Balance
		decimal accountBalance;
		public decimal AccountBalance
		{
			get => accountBalance;
			protected set => accountBalance = value > minAccountBalance ? value : throw new BalanceException($"Balance could not be less than {minAccountBalance}.");
		}

		// A field to hold the MinimumAccount Balance
		decimal minAccountBalance;
		protected decimal MinAccountBalance
		{
			get => minAccountBalance;
			set => minAccountBalance = value >= 0 ? value : throw new BalanceException("Minimum balance could not be less than 0.");
		}

		// A field to hold the Max Deposit Amount Balance
		decimal maxDepositAmount;
		protected decimal MaxDepositAmount
		{
			get => maxDepositAmount;
			set => maxDepositAmount = value > 0 ? value : throw new DepositException("Maximum deposit should be greater than 0.");
		}

		decimal interestRate;
		protected decimal InterestRate
		{
			get => interestRate;
			set => interestRate = value > 0 ? value : throw new InterestRateException("Interest rate should be greater than 0");
		}

		public BankAccount(string accountOwnerName, string accountNumber)
		{
			AccountOwnerName = accountOwnerName;
			AccountNumber = accountNumber;
			TransactionSummary = string.Empty;
		}

		// Depsoit is an abstract method so that Saving/Current Account must override it to give 
		// their specific implementaion.
		public abstract void Deposit(decimal amount);

		// Withdraw is an abstract method so that Saving/Current Account must override it to give 
		// their specific implementaion.
		public abstract void Withdraw(decimal amount);


		public decimal CalculateInterest()
		{
			return (this.AccountBalance * this.InterestRate) / 100;
		}

		// This method adds a Reporting functionality to the Bank Account
		public virtual string GenerateAccountReport()
		{
			return $"Account Owner:{ AccountOwnerName}, Account Number:{ AccountNumber}, AccountBalance: { AccountBalance}\n" +
				$"Interest Amount:{ CalculateInterest()}\n" +
				$"{TransactionSummary}\n";
		}
	}
}
