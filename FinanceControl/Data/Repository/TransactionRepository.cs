using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FinanceControl.Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Banco _banco;
        public TransactionRepository(Banco banco)
        {
            _banco = banco;
        }
        public async Task<List<TransactionEntities>> GetOperations()
        {
            return await _banco.Transactions.ToListAsync();
        }
        public async Task<TransactionEntities> GetById(int id)
        {
            return _banco.Transactions.FirstOrDefault(x => x.Id == id);
        }
        public async Task<TransactionEntities> AddTransaction(TransactionEntities transaction)
        {
            await _banco.Transactions.AddAsync(transaction);
            await _banco.SaveChangesAsync();
            return transaction;
        }
        public async Task<TransactionEntities> UpdateTransaction(TransactionEntities tr, int id)
        {
            TransactionEntities transaction = await GetById(id);
            if (transaction == null)
            {
                throw new Exception($"Transação:{id} não encontrado no banco de dados!");
            }
            transaction.OperationDate = tr.OperationDate;
            transaction.Description = tr.Description;
            transaction.Type = tr.Type;
            transaction.Value = tr.Value;
             _banco.Transactions.Update(tr);
            await _banco.SaveChangesAsync();
            return transaction;
        }
        public async Task<bool> DeleteTransition(int id)
        {
            TransactionEntities trans = await GetById(id);
            if(trans == null)
            {
                throw new Exception($"Transação: {id} não encontrado no banco de dados!");
            }
            _banco.Transactions.Remove(trans);
            await _banco.SaveChangesAsync();
            return true;
        }
    }
}
