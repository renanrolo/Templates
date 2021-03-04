using Dapper;

namespace Template.Data.SqlClientWithDapper.Helpers
{
    public static class DbStringBuilder
    {
        public static DbString CHAR(int length, string value)
        {
            return new DbString { Value = value, Length = length, IsAnsi = true, IsFixedLength = true };
        }
        public static DbString NCHAR(int length, string value)
        {
            return new DbString { Value = value, Length = length, IsAnsi = false, IsFixedLength = true };
        }
        public static DbString VARCHAR(int length, string value)
        {
            return new DbString { Value = value, Length = length, IsAnsi = true, IsFixedLength = false };
        }
        public static DbString NVARCHAR(int length, string value)
        {
            return new DbString { Value = value, Length = length, IsAnsi = false, IsFixedLength = false };
        }
    }
}
