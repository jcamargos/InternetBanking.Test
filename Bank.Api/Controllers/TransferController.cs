using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Domain.Contracts.Services;
using Bank.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/transfer")]
    public class TransferController : Controller
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transfer>> GetTransferReleases()
        {
            return _transferService.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Transfer))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Transfer>> GetById(int id)
        {
            var transferRelease = _transferService.GetById(id);

            if (transferRelease == null) { return NotFound(); }

            return Ok(transferRelease);
        }

        // POST api/transfer-release
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Transfer))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Transfer>>> Post([FromBody] Transfer transferRelease)
        {
            try
            {
                await _transferService.Save(transferRelease);

                return CreatedAtAction(nameof(GetById), new { id = transferRelease.Id }, transferRelease);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
