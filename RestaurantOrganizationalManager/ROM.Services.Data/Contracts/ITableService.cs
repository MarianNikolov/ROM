using ROM.Data.Model;
using System;
using System.Linq;

namespace ROM.Services.Data.Contracts
{
    public interface ITableService
    {
        Table GetTableByID(Guid? tableId);

        decimal GetBill(Table table);

        void AddProductToTable(Product product, Table table);

        void RemoveProductsFromTable(Table table);

        void ChangeTableStatus(Table table);
    }
}
