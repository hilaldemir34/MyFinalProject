﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi";
        public static string ProductCountofCategoryErrors = "Ürün sayısı aşıldı";
        public static string ProductNameAlreadyExists="Bu ürün daha önce girildi";
        public static string CategoryLimitExceded;
        public static string AuthorizationDenied="Yetkiniz yok";
        internal static string AccessTokenCreated;
    }
}
