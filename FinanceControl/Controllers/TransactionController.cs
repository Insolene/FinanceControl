using FinanceControl.Data;
using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FinanceControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _banco;
        public TransactionController(ITransactionRepository banco)
        {
            _banco = banco;
        }
        [HttpGet,Route("all")]
        public async Task<ActionResult<List<TransactionEntities>>> GetAll()
        {
            List<TransactionEntities> tr = await _banco.GetOperations();
            return Ok(tr);
        }
        [HttpGet, Route("id")]
        public async Task<ActionResult<TransactionEntities>> GetId(int id)
        {
            TransactionEntities tr = await _banco.GetById(id);
            return Ok(tr);
        }
        [HttpPost,Route("add")]
        public async Task<ActionResult<TransactionEntities>> Add([FromBody] TransactionEntities transaction)
        {
            TransactionEntities tr = await _banco.AddTransaction(transaction);
            return Ok(tr);
        }
        [HttpPut,Route("update")]
        public async Task<ActionResult<TransactionEntities>> Update([FromBody] TransactionEntities transaction, int id)
        {
            TransactionEntities tr = await _banco.UpdateTransaction(transaction,id);
            return Ok(tr);
        }
        [HttpDelete,Route("Delete")]
        public async Task<ActionResult<TransactionEntities>> Delete(int id)
        {
            bool tr = await _banco.DeleteTransition(id);
            return Ok(tr);
        }

    }
}
