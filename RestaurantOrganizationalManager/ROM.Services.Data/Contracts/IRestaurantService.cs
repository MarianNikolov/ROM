using ROM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROM.Services.Data.Contracts
{
    public interface IRestaurantService
    {
        void CreateRestaurant(string userID, string restaurantName, int countOfTables);

        Restaurant GetRestaurantByManagerID(string userID);
    }
}
