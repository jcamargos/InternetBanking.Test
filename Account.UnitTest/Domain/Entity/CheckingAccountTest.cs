using Account.Domain.Entity;
using Xunit;

namespace Account.UnitTest.Domain.Entity
{
    public class CheckingAccountTest
    {

        [Fact]
        public void Credit()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();
            var value = new decimal(80.00);

            //Act
            checkingAccount.Credit(value);

            //Assert
            Assert.Equal(value, checkingAccount.Balance);
        }

        [Fact]
        public void Debit()
        {
            //Arrange
            var checkingAccount = new CheckingAccount();
            var value = new decimal(80.00);
            checkingAccount.Credit(new decimal(120.00));

            //Act
            checkingAccount.Debit(value);

            //Assert
            Assert.Equal(value, checkingAccount.Balance);
        }
    }
}
