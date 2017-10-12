using ROM.Data.Model;
using System;
using System.Linq;

namespace ROM.Services.Data.Contracts
{
    public interface ITableService
    {
        IQueryable<Table> GetTablesByRestaurantID(Guid? restaurantId);

        IQueryable<Table> GetTablesByID(Guid? tableId);

        decimal GetBill(Table table);

        void AddProductToTable(Product product, Table table);

        void RemoveProductFromTable(Table table);

        void ChangeTableStatus(Table table);
    }
}
