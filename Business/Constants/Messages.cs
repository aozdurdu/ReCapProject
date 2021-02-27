using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //System Related Messages
        public static string MaintenanceTime = "System in maintenance mode";

        //DB Related Messages---

        //DB_Car Related Messages
        public static string CarAdded = "New car is added to DB";
        public static string CarUpdated = "Car is updated in DB";
        public static string CarDeleted = "Car is deleted from DB";
        public static string CarDescriptionInvalid = "Car description should be more than 2 characters";
        public static string CarDailyPriceInvalid = "Car daily price should be bigger than 0";
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

        //DB_User Related Messages
        public static string UserAdded = "New user is added to DB";
        public static string UserUpdated = "User is updated in DB";
        public static string UserDeleted = "User is deleted from DB";
        public static string UserNameInvalid = "Not added. User first name and/or last name should be more than 2 characters";
        public static string UsersListed = "Users listed";

        //DB_Customer Related Messages
        public static string CustomerAdded = "New customer is added to DB";
        public static string CustomerUpdated = "Customer is updated in DB";
        public static string CustomerDeleted = "Customer is deleted from DB";
        public static string CustomerNameInvalid = "Not added. Customer name should be more than 2 characters";
        public static string CustomersListed = "Customers listed";

        //DB_Rental Related Messages
        public static string RentalAdded = "New rental is added to DB";
        public static string RentalNotAdded = "New rental is not added to DB";
        public static string RentalUpdated = "Rental is updated in DB";
        public static string RentalDeleted = "Rental is deleted from DB";
        public static string RentalsListed = "Rentals listed";

        //DB_CarImage Related Messages
        public static string CarImageAdded = "New car image is added to DB";
        public static string CarImageNotAdded = "New car image is not added to DB";
        public static string CarImageUpdated = "Car image is updated in DB";
        public static string CarImageDeleted = "Car image is deleted from DB";
        public static string CarImagesListed = "Car images listed";
        public static string MaxCarImageCountLimit = "Max limit for car images reached";
    }
}
