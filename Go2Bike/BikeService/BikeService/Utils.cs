using System;

namespace BikeService
{
    public class Utils
    {
        public static uint RemoveFirstBit(uint msgId)
        {
            return Convert.ToUInt32(Convert.ToString(msgId, 2).Remove(0, 1), 2);
        }

        public static string Serialize(object o)
        {
            return "";
        }

        public static object DeSerialize(object o)
        {
            return "";
        }

        public static int GetBit(byte b, int bitNumber)
        {
            return b & (1 << bitNumber);
        }

    }
}
