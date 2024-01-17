using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.Commons
{
    public enum ResponseMesssage
    {
        [Description("Data Loaded Successfully!")]
        DataLoadedSuccessfully = 1,

        [Description("Data Updated Successfully!")]
        DataUpdatedSuccessfully,
    }
}
