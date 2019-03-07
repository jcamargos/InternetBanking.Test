using Bank.Domain.Contracts.Services;
using Bank.Domain.Entity;
using Bank.Domain.Interfaces;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Bank.UnitTest.Domain.Servives
{
    public class TransferServiceTest
    {
        private ITransfer transferRepository;
        private ITransferService transferervice;

        public TransferServiceTest()
        {
            transferRepository = Substitute.For<ITransfer>();
        }

        [Fact]
        public async void Add()
        {
            //Arrange
            var transferReleaseMock = Substitute.For<Transfer>();
            var value = new decimal(100.00);

            transferReleaseMock.OriginAccount = 1;
            transferReleaseMock.DestinationAccount = 2;
            transferReleaseMock.Value = value;

            //Act
            await transferService.Add(transferReleaseMock);

            //Assert
            Received.InOrder(() =>
            {
                accountClientMock.CheckingAccountDebit(transferReleaseMock);
                accountClientMock.CheckingAccountCredit(transferReleaseMock);
                transferReleaseRepositoryMock.Add(transferReleaseMock);
            });
        }

        [Fact]
        public void All()
        {
            //Act
            transferService.All();

        }

        [Fact]
        public void Find()
        {
            //Arrange
            Expression<Func<Transfer, bool>> Filter = x => x.Value > new decimal(40.00);

            //Act
            transfeRepository.Find(Filter);

            //Assert
            transferRepository.Received().Find(Filter);
        }

        [Fact]
        public void FindById()
        {
            //Arrange
            var id = 10;

            //Act
            transferService.FindById(id);

            //Assert
            transferRepository.Received().FindById(id);
        }
    }
}
