using System;

namespace ThePlayer.Shared.Utilities
{
    public static class NumberUtils
    {
        public static int ConvertToInt32(long? nullableLong)
        {
            return nullableLong.HasValue ? Convert.ToInt32(nullableLong.Value) : 0;
        }

        public static bool ConvertToBoolean(long? nullableLong)
        {
            return nullableLong.HasValue && nullableLong.Value != 0 ? true : false;
        }
    }
}
