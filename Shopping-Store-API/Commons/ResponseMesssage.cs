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
    }
}
