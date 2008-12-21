﻿//-----------------------------------------------------------------------
// <copyright file="Any.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace InteropApiTests
{
    using System;
    using System.Text;

    /// <summary>
    /// Generate arbitrary (random) values
    /// </summary>
    public static class Any
    {
        /// <summary>
        /// Random object used to generate the values.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Gets a value indicating whether the random boolean value
        /// is true or false.
        /// </summary>
        public static bool Boolean
        {
            get
            {
                return 0 == Any.random.Next() % 2;
            }
        }

        /// <summary>
        /// Gets a random byte.
        /// </summary>
        public static byte Byte
        {
            get
            {
                byte[] data = new byte[1];
                Any.random.NextBytes(data);
                return data[0];
            }
        }

        /// <summary>
        /// Gets a random short.
        /// </summary>
        public static short Int16
        {
            get
            {
                byte[] data = new byte[2];
                Any.random.NextBytes(data);
                return BitConverter.ToInt16(data, 0);
            }
        }

        /// <summary>
        /// Gets a random ushort.
        /// </summary>
        public static ushort UInt16
        {
            get
            {
                byte[] data = new byte[2];
                Any.random.NextBytes(data);
                return BitConverter.ToUInt16(data, 0);
            }
        }

        /// <summary>
        /// Gets a random int.
        /// </summary>
        public static int Int32
        {
            get
            {
                byte[] data = new byte[4];
                Any.random.NextBytes(data);
                return BitConverter.ToInt32(data, 0);
            }
        }

        /// <summary>
        /// Gets a random uint.
        /// </summary>
        public static uint UInt32
        {
            get
            {
                byte[] data = new byte[4];
                Any.random.NextBytes(data);
                return BitConverter.ToUInt32(data, 0);
            }
        }

        /// <summary>
        /// Gets a random long.
        /// </summary>
        public static long Int64
        {
            get
            {
                byte[] data = new byte[8];
                Any.random.NextBytes(data);
                return BitConverter.ToInt64(data, 0);
            }
        }

        /// <summary>
        /// Gets a random ulong.
        /// </summary>
        public static ulong UInt64
        {
            get
            {
                byte[] data = new byte[8];
                Any.random.NextBytes(data);
                return BitConverter.ToUInt64(data, 0);
            }
        }

        /// <summary>
        /// Gets a random float.
        /// </summary>
        public static float Float
        {
            get
            {
                return (float)Any.random.NextDouble();
            }
        }

        /// <summary>
        /// Gets a random double.
        /// </summary>
        public static double Double
        {
            get
            {
                return Any.random.NextDouble();
            }
        }

        /// <summary>
        /// Gets a random Guid.
        /// </summary>
        public static Guid Guid
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Gets a random string. The string will only
        /// contain ASCII characters and will be 1 to
        /// 120 characters long.
        /// </summary>
        public static string String
        {
            get
            {
                int length = Any.random.Next(1, 120);
                var sb = new StringBuilder();
                for (int i = 0; i < length; ++i)
                {
                    char c = (char)Any.random.Next(32, 127);
                    sb.Append(c);
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets a random array of bytes. The array will
        /// be from 1 to 255 bytes.
        /// </summary>
        public static byte[] Bytes
        {
            get
            {
                int length = Any.random.Next(1, 255);
                byte[] data = new byte[length];
                Any.random.NextBytes(data);
                return data;
            }
        }
    }
}