using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Contants
{
    public static class Messages
    {
        public static string CarsListed = "Arabalar başarıyla listelendi";
        public static string CarFetched = "Araba başarıyla getirildi";
        public static string NotEnoughInfo = "Yeterli bilgi vermediniz";
        public static string CarAdded = "Araba başarıyla eklendi";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string RentalSuccess = "Araba başarıyla kiralandı";
        public static string RentalFailDate = "Araba kiralanması için kiralanma zamanı verilmesi gerekiyor.";

        public static string ResultDeleted { get; internal set; }
        public static List<Rental> RentalsListed { get; internal set; }
    }
}
