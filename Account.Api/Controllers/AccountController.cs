using System;
using System.Collections.Generic;
using System.Linq;
using Account.Domain.Contracts.Services;
using Account.Domain.Entity;
using Account.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICheckingAccountService _checkingAccountService;

        public AccountController(ICheckingAccountService checkingAccountService)
        {
            _checkingAccountService = checkingAccountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CheckingAccount>> GetCheckingAccounts()
        {
            return _checkingAccountService.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CheckingAccount))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<CheckingAccount>> GetById(int id)
        {
            var checkingAccount = _checkingAccountService.GetById(id);

            if (checkingAccount == null) { return NotFound(); }

            return Ok(checkingAccount);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CheckingAccount))]
        public ActionResult<IEnumerable<CheckingAccount>> Post([FromBody] CheckingAccount checkingAccount)
        {
            _checkingAccountService.Save(checkingAccount);

            return CreatedAtAction(nameof(GetById), new { id = checkingAccount.Id }, checkingAccount);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put(int id, [FromBody] CheckingAccount checkingAccount)
        {
            if (id != checkingAccount.Id)
            {
                return BadRequest("Error: [id] checking account object id not equals url id");
            }

            _checkingAccountService.Update(checkingAccount);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var checkingAccount = _checkingAccountService.GetById(id);

            if (checkingAccount == null) { return NotFound(); }

            _checkingAccountService.Delete(checkingAccount);

            return NoContent();
        }

        [HttpPost("{id}/credit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult PostCredit(int id, [FromBody] Money money)
        {
            var checkingAccount = _checkingAccountService.GetById(id);

            if (checkingAccount == null) { return NotFound(); }

            try
            {
                _checkingAccountService.Credit(checkingAccount, money.Value);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpPost("{id}/debit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult PostDebit(int id, [FromBody] Money money)
        {
            var checkingAccount = _checkingAccountService.GetById(id);

            if (checkingAccount == null) { return NotFound(); }

            try
            {
                _checkingAccountService.Debit(checkingAccount, money.Value);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
