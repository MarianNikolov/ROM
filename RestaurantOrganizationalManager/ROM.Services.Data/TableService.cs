﻿using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Linq;

namespace ROM.Services.Data
{
    public class TableService : ITableService
    {
        private readonly IEfRepository<Table> tableRepository;
        private readonly IEfRepository<Product> productRepository;
        private readonly ISaveContext saveContext;

        public TableService(
            IEfRepository<Table> tableRepository, 
            IEfRepository<Product> productRepository,
            ISaveContext saveContext)
        {
            this.tableRepository = tableRepository;
            this.productRepository = productRepository;
            this.saveContext = saveContext;
        }

        public Table GetTableByID(Guid? tableId)
        {
            if (tableId == null)
            {
                throw new NullReferenceException();
            }

            var tableResult = this.tableRepository.All.FirstOrDefault(t => t.Id == tableId);

            if (tableResult == null)
            {
                throw new NullReferenceException();
            }

            return tableResult;
        }

        public decimal GetBill(Table table)
        {
            if (table == null)
            {
                throw new NullReferenceException();
            }

            decimal bill = 0;

            foreach (var product in table.Products)
            {
                bill += product.Price;
            }

            return bill; 
        }

        public void AddProductToTable(Product product, Table table)
        {
            if (product == null || table == null)
            {
                throw new NullReferenceException();
            }

            table.Products.Add(product);
            product.Tables.Add(table);
            this.tableRepository.Update(table);
            this.productRepository.Update(product);

            this.saveContext.Commit();
        }

        public void RemoveProductsFromTable(Table table)
        {
            if (table == null)
            {
                throw new NullReferenceException();
            }

            table.Products.Clear();
            this.tableRepository.Update(table);

            this.saveContext.Commit();
        }

        public void ChangeTableStatus(Table table)
        {
            if (table == null)
            {
                throw new NullReferenceException();
            }

            table.IsFree = !table.IsFree;
            this.tableRepository.Update(table);

            saveContext.Commit();
        }
    }
}
