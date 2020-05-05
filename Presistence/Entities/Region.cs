using System.ComponentModel;

namespace learn_Russian_API.Presistence.Entities
{
    public enum Region
    {
        [Description("Asia")]
        Asia = 1,
        [Description("Africa")]
        Africa = 2,
        [Description("Australia")]
        Australia = 3,
        [Description("America")]
        America = 4,
        [Description("Europa")]
        Europe = 5,
    }
}