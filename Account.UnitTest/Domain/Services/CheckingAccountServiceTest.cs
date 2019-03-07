using Account.Business;
using Account.Domain.Entity;
using Account.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Account.UnitTest.Domain.Services
{
    public class CheckingAccountServiceTest
    {
        private CheckingAccount checkingAccountMock;
        private ICheckingAccountRepository checkingAccountRepository;
        private CheckingAccountService checkingAccountService;

        public CheckingAccountServiceTest()
        {
            checkingAccountMock = Substitute.For<CheckingAccount>();
            checkingAccountRepositoryMock = Substitute.For<ICheckingAccountRepository>();

            checkingAccountService = new CheckingAccountService(checkingAccountRepository);
        }

        [Fact]
        public void Add()
        {
            //Act
            checkingAccountService.Add(checkingAccountMock);

            //Assert
            checkingAccountRepository.Received().Add(checkingAccountMock);
        }

        [Fact]
        public void Remove()
        {
            //Act
            checkingAccountService.Remove(checkingAccountMock);

            //Assert
            checkingAccountRepository.Received().Remove(checkingAccountMock);
        }

        [Fact]
        public void Update()
        {
            //Act
            checkingAccountService.Update(checkingAccountMock);

            //Assert
            checkingAccountRepository.Received().Update(checkingAccountMock);
        }

        [Fact]
        public void All()
        {
            //Act
            checkingAccountService.All();

            //Assert
            checkingAccountRepository.Received().All();
        }

        [Fact]
        public void Find()
        {
            //Arrange
            Expression<Func<CheckingAccount, bool>> Filter = x => x.Balance > new decimal(10.00);

            //Act
            checkingAccountService.Find(Filter);

            //Assert
            checkingAccountRepository.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            //Arrange
            var id = 1;

            //Act
            checkingAccountService.FindById(id);

            //Assert
            checkingAccountRepositoryMock.Received().FindById(id);
        }

        [Fact]
        public void Credit_when_value_less_than_zero()
        {
            //Arrange
            var value = new decimal(-10.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Credit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Credit_when_value_bigger_than_zero()
        {
            //Arrange
            var value = new decimal(10.00);

            //Act
            checkingAccountService.Credit(checkingAccountMock, value);

            //Assert
            Received.InOrder(() => {
                checkingAccountMock.Credit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }

        [Fact]
        public void Debit_when_value_less_than_zero()
        {
            //Arrange
            var value = new decimal(-10.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_balance()
        {
            //Arrange
            var value = new decimal(100.00);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => checkingAccountService.Debit(checkingAccountMock, value)
            );
        }

        [Fact]
        public void Debit_when_value_bigger_than_zero_and_balance()
        {
            //Arrange
            checkingAccountMock.Balance.Returns(new decimal(20.00));
            var value = new decimal(10.00);

            //Act
            checkingAccountService.Debit(checkingAccountMock, value);

            //Assert
            Received.InOrder(() => {
                checkingAccountMock.Debit(value);
                checkingAccountRepositoryMock.Update(checkingAccountMock);
            });
        }
    }
}
