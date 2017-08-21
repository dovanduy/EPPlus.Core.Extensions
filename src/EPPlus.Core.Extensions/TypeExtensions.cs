﻿using System;

namespace EPPlus.Core.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether given type is nullable or not
        /// </summary>
        /// <param name="type">Type to test</param>
        /// <returns>True if type is nullable</returns>
        public static bool IsNullable(this Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Tests whether given type is numeric or not
        /// </summary>
        /// <param name="type">Type to test</param>
        /// <returns>True if type is numeric</returns>
        public static bool IsNumeric(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
