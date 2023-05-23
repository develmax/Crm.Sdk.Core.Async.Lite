namespace Microsoft.Crm.Sdk.OData
{
    public static class BusinessUnitInheritanceMask
    {
        public const int InheritNone = 0;
        public const int InheritProcessTemplate = 1;
        public const int InheritEmailTemplate = 2;
        public const int InheritReferralSource = 4;
        public const int InheritCompetitor = 8;
        public const int InheritSalesProcess = 16;
        public const int MustInheritProcessTemplate = 32;
        public const int MustInheritEmailTemplate = 64;
        public const int MustInheritReferralSource = 128;
        public const int MustInheritCompetitor = 256;
        public const int MustInheritSalesProcess = 512;
        public const int InheritAll = 1023;
    }
}