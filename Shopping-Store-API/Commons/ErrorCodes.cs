﻿using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.Commons
{
    public enum ErrorCodes
    {
        [Display(Description = "Client Request Is Invalid!")]
        ClientRequestIsInvalid = 1,

        [Display(Description = "An Unknown Error Occured!")]
        OopsSomethingHapped,

        [Display(Description = "Token Is InValid!")]
        TokenIsInValid,

        [Display(Description = "Token Is Misssing!")]
        TokenIsMissing,

        [Display(Description = "Unauthenticated To Access This Data!")]
        UserIsUnauthenticated,

        [Display(Description = "Unauthorized To Access This Data!")]
        UserIsUnauthorized,

        [Display(Description = "Data Entry Cannot Be Found!")]
        DataEntryIsNotExisted,

        [Display(Description = "Data Validation Is Failed!")]
        FailedValidationData,

        [Display(Description = "Data Already In Use And Cannot Be Deleted!")]
        DataAlreadyInUseAndCannotBeDeleted,

        [Display(Description = "Product Data Doesn't Exist!")]
        ProductDataDoesntExist,

        [Display(Description = "Item Isn't Added Successfully!")]
        ItemIsntAddedSuccessfully,

        [Display(Description = "Shopping Cart Doesn't Exist!")]
        ShoppingCartDoesntExist,

        [Display(Description = "Shopping Cart Can't Be Created!")]
        ShoppingCartCantBeCreated,

        [Display(Description = "Shopping Cart Can't Be Removed!")]
        ShoppingCartCantBeRemoved,

        [Display(Description = "Data Aren't Created Successfully!")]
        DataArentCreatedSuccessfully,

        [Display(Description = "Sign Up, Please!")]
        SignUpPlease,

        [Display(Description = "Data Aren't Deleted Successfully!")]
        DataArentDeletedSuccessfully,

        [Display(Description = "Data Aren't Updated Successfully!")]
        DataArentUpdatedSuccessfully,

        [Display(Description = "Data Aren't Loaded Successfully!")]
        DataArentLoadedSuccessfully,

        [Display(Description = "Data Aren't Added Successfully!")]
        DataArentAddedSuccessfully,

        [Display(Description = "Shopping Cart Can't Be Updated!")]
        ShoppingCartCantBeUpdated,

        [Display(Description = "Email Is Already Taken")]
        EmailIsAlreadyTaken,

        [Display(Description = "Address Isn't Added Successfully!")]
        AddressIsntAddedSuccessfully,

        [Display(Description = "Order Isn't Added Successfully!")]
        OrderIsntAddedSuccessfully,

        [Display(Description = "There is a problem of creating an payment intention")]
        ProblemCreatingPaymentIntent,

        [Display(Description = "Image Isn't Added Successfully!")]
        ImageIsntAddedSuccessfully,

        [Display(Description = "Stripe Checkout Isn't Successfully!")]
        StripeCheckoutIsntSuccessfully,

        [Display(Description = "New Address Can't Created!")]
        NewAddressCantCreated,
    }
}
