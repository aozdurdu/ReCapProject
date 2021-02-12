﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //System Related Messages
        public static string MaintenanceTime = "System in maintenance mode";

        //DB Related Messages---

        //DB_Add Related Messages
        public static string CarAdded = "New car is added to DB";
        public static string CarUpdated = "Car is updated in DB";
        public static string CarDeleted = "Car is deleted from DB";
        public static string CarDescriptionInvalid = "Not added. Car description should be more than 2 characters and car daily price should be bigger than 0";
        public static string CarsListed = "Cars listed";

        //DB_Color Related Messages
        public static string ColorAdded = "New color is added to DB";
        public static string ColorUpdated = "Color is updated in DB";
        public static string ColorDeleted = "Color is deleted from DB";
        public static string ColorNameInvalid = "Not added. Color name should be more than 2 characters";
        public static string ColorsListed = "Colors listed";

        //DB_Brand Related Messages
        public static string BrandAdded = "New brand is added to DB";
        public static string BrandUpdated = "Brand is updated in DB";
        public static string BrandDeleted = "Brand is deleted from DB";
        public static string BrandNameInvalid = "Not added. Brand name should be more than 2 characters";
        public static string BrandsListed = "Brands listed";
    }
}