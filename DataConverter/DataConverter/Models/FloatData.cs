/*==================================================================================================
** 类 名 称:ByteData
** 创 建 人:xiaopeng_liu
** 当前版本：V1.0.0
** CLR 版本:4.0.30319.42000
** 创建时间:2019/7/27 15:52:10

** 修改人		修改时间		修改后版本		修改内容


** 功能描述：
 
==================================================================================================
 Copyright @2019. Focused Photonics Inc. All rights reserved.
==================================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataConverter.Models
{
    public class FloatData
    {
        public string Str1 { get; }
        public string Str2 { get; }
        public string Str3 { get; }
        public string Str4 { get; }

        /// <summary>
        /// 设置浮点数数值
        /// </summary>
        public FloatData(string dataStr)
        {
            if (string.IsNullOrWhiteSpace(dataStr))
            {
                throw new Exception("输入不可为空！");
            }
            else if (float.TryParse(dataStr, out float inputdata))
            {
                Str1 = GetString(inputdata, ByteOrder._1234, " ");
                Str2 = GetString(inputdata, ByteOrder._2143, " ");
                Str3 = GetString(inputdata, ByteOrder._3412, " ");
                Str4 = GetString(inputdata, ByteOrder._4321, " ");
            }
            else
            {
                throw new Exception("输入不合法！");
            }
        }

        /// <summary>
        /// 获取浮点数对应byte数组形式
        /// </summary>
        /// <param name="value"></param>
        /// <param name="order"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        private string GetString(float value, ByteOrder order = ByteOrder._1234, string separator = "")
        {
            if (!float.IsNaN(value))
            {
                IEnumerable<byte> data = TransformArray(BitConverter.GetBytes(value), order);
                string returnStr = data.Aggregate("", (current, @by) => current + @by.ToString("X2") + separator);
                return returnStr.Substring(0, returnStr.Length - separator.Length);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 转换数组字节序
        /// </summary>
        /// <param name="data"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private static IEnumerable<byte> TransformArray(byte[] data, ByteOrder order)
        {
            var returnByte = new byte[4];
            switch (order)
            {
                case ByteOrder._1234:
                    returnByte[0] = data[3];
                    returnByte[1] = data[2];
                    returnByte[2] = data[1];
                    returnByte[3] = data[0];
                    break;
                case ByteOrder._2143:
                    returnByte[0] = data[2];
                    returnByte[1] = data[3];
                    returnByte[2] = data[0];
                    returnByte[3] = data[1];
                    break;
                case ByteOrder._3412:
                    returnByte[0] = data[1];
                    returnByte[1] = data[0];
                    returnByte[2] = data[3];
                    returnByte[3] = data[2];
                    break;
                case ByteOrder._4321:
                    returnByte = data;
                    break;
            }
            return returnByte;
        }
    }

    /// <summary>
    /// byte字符顺序
    /// </summary>
    public enum ByteOrder
    {
        _1234,
        _2143,
        _3412,
        _4321
    }
}