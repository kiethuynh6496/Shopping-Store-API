using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.Commons
{
    public enum ErrorCodes
    {
        [Display(Description = "Credentials Is Invalid!")]
        CredentialsInvalid = 1,

        [Display(Description = "An Unknown Error Occured!")]
        OopsSomethingHapped,

        [Display(Description = "Access Token Is InValid!")]
        AccessTokenIsInValid,

        [Display(Description = "Access Token Is Misssing!")]
        AccessTokenIsMissing,

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
    }
}
