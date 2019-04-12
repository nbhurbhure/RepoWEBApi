using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServiceDataAccess
{
    /// <summary>
    /// DBHelper class
    /// </summary>
    public static class DBHelper
    {
        #region Methods

        /// Get Integer
        /// <param name="val">val</param>
        /// <returns>int</returns>
        public static int GetInt(object val)
        {
            try
            {

                return Convert.ToInt32(val);
            }
            catch
            {
                //return int.MinValue;
                return 0;
            }
        }

        /// Get Nullable Integer
        /// <param name="val">val</param>
        /// <returns>int</returns>
        public static Nullable<int> GetNullableInt(object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get String
        /// <param name="val">val</param>
        /// <returns>String</returns>
        public static String GetString(object val)
        {
            if (val == DBNull.Value)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(val);
            }
        }

        /// Get String
        /// <param name="val">val</param>
        /// <returns>String</returns>
        public static String GetNullableString(object val)
        {
            if (val == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToString(val);
            }
        }

        /// Get Single
        /// <param name="val">val</param>
        /// <returns>Single</returns>
        public static Single GetSingle(object val)
        {
            try
            {
                return Convert.ToSingle(val);
            }
            catch
            {
                return Single.MinValue;
            }
        }

        /// Get Nullable Single
        /// <param name="val">val</param>
        /// <returns>Single</returns>
        public static Nullable<Single> GetNullableSingle(object val)
        {
            try
            {
                return Convert.ToSingle(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Boolean
        /// <param name="val">val</param>
        /// <returns>Boolean</returns>
        public static Boolean GetBoolean(object val)
        {
            try
            {
                return Convert.ToBoolean(val);
            }
            catch
            {
                return false;
            }
        }

        /// Get Nullable Boolean
        /// <param name="val">val</param>
        /// <returns>Boolean</returns>
        public static Nullable<Boolean> GetNullableBoolean(object val)
        {
            try
            {
                return Convert.ToBoolean(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Deciaml
        /// <param name="val">val</param>
        /// <returns>Decimal</returns>
        public static Decimal GetDecimal(object val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                //return Decimal.MinValue;
                return 0;
            }
        }

        /// Get Nullable Deciaml
        /// <param name="val">val</param>
        /// <returns>Decimal</returns>
        public static Nullable<Decimal> GetNullableDecimal(object val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get short
        /// <param name="val">val</param>
        /// <returns>short</returns>
        public static short GetShort(object val)
        {
            try
            {
                return Convert.ToInt16(val);
            }
            catch
            {
                return Int16.MinValue;
            }
        }

        /// Get Nullable short
        /// <param name="val">val</param>
        /// <returns>short</returns>
        public static Nullable<short> GetNullableShort(object val)
        {
            try
            {
                return Convert.ToInt16(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get long
        /// <param name="val">val</param>
        /// <returns>long</returns>
        public static long GetLong(object val)
        {
            try
            {
                return Convert.ToInt64(val);
            }
            catch
            {
                return Int64.MinValue;
            }
        }

        /// Get Nullable long
        /// <param name="val">val</param>
        /// <returns>long</returns>
        public static Nullable<long> GetNullableLong(object val)
        {
            try
            {
                return Convert.ToInt64(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Date
        /// <param name="val">val</param>
        /// <returns>DateTime</returns>
        public static DateTime GetDate(object val)
        {
            try
            {
                return Convert.ToDateTime(val);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// Get Nullable Date
        /// <param name="val">val</param>
        /// <returns>DateTime</returns>
        public static Nullable<DateTime> GetNullableDate(object val)
        {
            try
            {
                return Convert.ToDateTime(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Binary
        /// <param name="val">val</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBinary(object val)
        {
            try
            {
                return (byte[])val;
            }
            catch
            {
                return null;
            }
        }

        /// Get GUID
        /// <param name="val">val</param>
        /// <returns>Guid</returns>
        public static Guid GetGUID(object val)
        {
            try
            {
                return new Guid(val.ToString());
            }
            catch
            {
                return new Guid();
            }
        }

        /// Get Nullable GUID
        /// <param name="val">val</param>
        /// <returns>Guid</returns>
        public static Nullable<Guid> GetNullableGUID(object val)
        {
            try
            {
                return new Guid(val.ToString());
            }
            catch
            {
                return null;
            }
        }

        /// Get Double
        /// <param name="val">val</param>
        /// <returns>Double</returns>
        public static Double GetDouble(object val)
        {
            try
            {

                return Convert.ToDouble(val);

            }
            catch
            {
                //return double.MinValue;
                return 0;
            }
        }

        /// Get Nullable Double
        /// <param name="val">val</param>
        /// <returns>Double</returns>
        public static Nullable<Double> GetNullableDouble(object val)
        {
            try
            {
                return Convert.ToDouble(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Byte
        /// <param name="val">val</param>
        /// <returns>Byte</returns>
        public static Byte GetByte(object val)
        {
            try
            {
                return Convert.ToByte(val);
            }
            catch
            {
                return byte.MinValue;
            }
        }

        /// Get Nullable Byte
        /// <param name="val">val</param>
        /// <returns>Byte</returns>
        public static Nullable<Byte> GetNullableByte(object val)
        {
            try
            {
                return Convert.ToByte(val);
            }
            catch
            {
                return null;
            }
        }

        /// Get Double
        /// <param name="val">val</param>
        /// <returns>Double</returns>
        public static Double GetDoubleRound(object val, int digits, MidpointRounding mode)
        {
            try
            {
                return Math.Round(Convert.ToDouble(val), digits, mode);
            }
            catch
            {
                return double.MinValue;
            }
        }

        /// Get Double
        /// <param name="val">val</param>
        /// <returns>Double</returns>
        public static String GetDoubleRoundString(object val, int digits, MidpointRounding mode)
        {
            try
            {
                if (val == DBNull.Value)
                {
                    return String.Empty;
                }
                else
                {
                    return Convert.ToString(Math.Round(Convert.ToDouble(val), digits, mode));
                }
            }
            catch
            {
                return Convert.ToString(double.MinValue);
            }
        }

        /// Get Nullable Double
        /// <param name="val">val</param>
        /// <returns>Double</returns>
        public static Nullable<Double> GetNullableDoubleRound(object val, int digits, MidpointRounding mode)
        {
            try
            {
                return Math.Round(Convert.ToDouble(val), digits, mode);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
