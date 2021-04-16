using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EF
{
    public class EfRentalDal:EfEntitiyRepositoryBase<Rental, CarDBContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDBContext carDBContext = new CarDBContext())
            {
                var cars = carDBContext.Cars;
                var users = carDBContext.Users;
                var customers = carDBContext.Customers;
                var rentals = carDBContext.Rentals;
                var brands = carDBContext.Brands;

                var result = from user in users
                             join
                            customer in customers on user.UserId equals customer.UserId
                             join
                            rental in rentals on customer.CustomerId equals rental.CustomerId
                             join
                            car in cars on rental.CarId equals car.CarId
                             join brand in brands on car.BrandId
                            equals brand.BrandId
                             select new RentalDetailDto { RentalId = rental.RentalId, BrandName = brand.Name, FullName = user.FirstName + " " + user.LastName, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };
                return result.ToList();
             }


        }
    }
}

