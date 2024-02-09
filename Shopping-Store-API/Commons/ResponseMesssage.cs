using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.Commons
{
    public enum ResponseMesssage
    {
        [Description("Data Are Loaded Successfully!")]
        DataAreLoadedSuccessfully = 1,

        [Description("Data Are Updated Successfully!")]
        DataAreUpdatedSuccessfully,

        [Description("Data Are Created Successfully!")]
        DataAreCreatedSuccessfully,

        [Description("Data Are Deleted Successfully!")]
        DataAreDeletedSuccessfully,

        [Description("Token Are Revoked Successfully!")]
        TokenAreRevokedSuccessfully,

        [Description("Token Are Refreshed Successfully!")]
        TokenAreRefreshedSuccessfully,
        
        [Description("Logged Out Successfully!")]
        LoggedOutSuccessfully,

        [Description("Logged In Successfully!")]
        LoggedInSuccessfully,

        [Description("Shopping Cart Is Loaded Successfully!")]
        ShoppingCartIsLoadedSuccessfully,

        [Description("Item Is Added Successfully!")]
        ItemIsAddedSuccessfully,

        [Description("Item Is Removed Successfully!")]
        ItemIsRemovedSuccessfully,

        [Description("User Registered Successfully!")]
        UserRegisteredSuccessfully,

        [Description("Order Is Created Successfully!")]
        OrderIsCreatedSuccessfully,
    }
}
