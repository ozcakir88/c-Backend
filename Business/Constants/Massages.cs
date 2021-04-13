using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Massages
    {
        public static string ProductAddes = "ürün eklendi";
        public static string ProducNameInvalid = "ürün ismi gecersiz";
        public static string MaintenanceTime = "bakım zamanı";
        public static string ProductListed = "ürünler listelendi";
        public static string Ayni = "ayni üründen var";

        public static string ProductCountCategoryError = "en faxla 10 kategori olur";

        public static string CategoryLimitExcedet = "maksimüm 15 kategori olması gerek";

        public static string AuthorizationDenied = "yetkiniz yok";

        public static string UserRegistered = "kayıd oldu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı mevcut";
        public static string AccessTokenCreated = "hata mesajası işte uzatma";
    }
}
