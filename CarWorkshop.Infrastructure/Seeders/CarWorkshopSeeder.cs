using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync()) // sprwadzenie czy polaczenie jest mozliwe
            {
                if(!_dbContext.CarWorkshops.Any()) // czy tabela jest pusta
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop() // doda mazda aso
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Rzeszow",
                            Street = "8 Marca 17",
                            PostalCode = "30-001",
                            PhoneNumber = "+48 123456789"
                        }
                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshops.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync(); // zapisanie danych
                }
            }
        }
    }
}
