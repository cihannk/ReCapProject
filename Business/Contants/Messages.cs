using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
        public static string ResultDeleted = "Sonuç silindi";
        public static string RentalsListed = "Rentals listelendi";
        public static string CarImageExceeded = "Maksimum araba resim limitine ulaşıldı.";
        public static string CarImageAdded = "Araba resmi eklendi.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string UserAlreadyExists = "Kullanıcı sistemde zaten var.";
        public static string UserValidationError = "Kullanıcı onaylanmadı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string AuthorizationDenied = "Yetki hatası";
    }
}
