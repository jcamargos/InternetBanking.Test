using Bank.Api.Controllers;
using Bank.Domain.Contracts.Services;
using Bank.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bank.UnitTest.Application.Controllers
{
    public class ITransferControllerTest
    {
        private ITransferService _transferReleaseServiceMock;
        private ITransferController _ITransferController;

        public ITransferControllerTest()
        {
            _transferReleaseServiceMock = Substitute.For<ITransferService>();

            _ITransferController = new TransferController(_transferReleaseServiceMock);
        }

        [Fact]
        public void GetTransferReleases_on_success()
        {
            //Act
            var result = _ITransferController.GetTransferReleases();

            //Assert
            Assert.IsType<List<Transfer>>(result.Value);
        }

        [Fact]
        public void GetById_on_success()
        {
            //Arrange
            var transferRelease = new Transfer();
            var id = 1;
            _transferReleaseServiceMock.GetById(id).Returns(transferRelease);

            //Act
            var result = _ITransferController.GetById(id);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<Transfer>(okResult.Value);
        }

        [Fact]
        public void GetById_when_not_found_checking_account()
        {
            //Arrange
            var id = 1;
            _transferReleaseServiceMock.GetById(id).ReturnsNull();

            //Act
            var result = _ITransferController.GetById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Post_on_success()
        {
            //Arrange
            var transferRelease = new Transfer();

            //Act
            var result = _ITransferController.Post(transferRelease);
            var createdAtActionResult = result.Result.Result as CreatedAtActionResult;

            //Assert
            _transferReleaseServiceMock.Received().Add(transferRelease);
            Assert.IsType<CreatedAtActionResult>(result.Result.Result);
            Assert.IsType<Transfer>(createdAtActionResult.Value);
        }

        [Fact]
        public void Post_when_has_exception_in_transfer_release_add_operation()
        {
            //Arrange
            var transferRelease = new Transfer();

            _transferReleaseServiceMock
                .When(t => t.Add(transferRelease))
                .Do(x => { throw new Exception(); });

            //Act
            var result = _ITransferController.Post(transferRelease);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result.Result);
        }
    }
}
