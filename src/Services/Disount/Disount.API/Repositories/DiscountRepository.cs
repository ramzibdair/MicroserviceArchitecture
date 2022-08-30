using Disount.API.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace Disount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _iconfiguration;
        public DiscountRepository(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public async Task<Coupon> CreateDiscountAsync(Coupon coupon)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_iconfiguration.GetValue<string>("Database:ConnectionString"));
            var effectedRows = await connection.ExecuteAsync("INSERt INTO coupon (ProductName,Description , Amount) VALUES (@ProductName, @Description, @Amount)", 
                new { ProductName = coupon.ProductName, Description = coupon.Description , Amount = coupon.Amount });

            if (effectedRows == 0)
                return null;
            return coupon;
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_iconfiguration.GetValue<string>("Database:ConnectionString"));
            var effectedRows = await connection.ExecuteAsync("DELETE FROM coupon WHERE ProductName = @ProdcutName ",
                new { ProductName = productName });

            if (effectedRows == 0)
                return false;
            return true;
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_iconfiguration.GetValue<string>("Database:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            if (coupon == null)
                return new Coupon() { Amount = 0, Description = "No discount", ID = 0, ProductName = string.Empty };

            return coupon;

        }

        public async Task<Coupon> UpdateDiscountAsync(Coupon coupon)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_iconfiguration.GetValue<string>("Database:ConnectionString"));
            var effectedRows = await connection.ExecuteAsync("UPDATE TABLE coupon SET ProductName = @ProductName ,Description = @Description , Amount=@Amount WHERE ID = @ID",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount , ID= coupon.ID });

            if (effectedRows == 0)
                return null;
            return coupon;
        }
    }
}
