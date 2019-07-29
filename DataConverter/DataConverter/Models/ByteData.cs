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
using System.Text.RegularExpressions;

namespace DataConverter.Models
{
    public class ByteData
    {
        public string Str1 { get; }
        public string Str2 { get; }
        public string Str3 { get; }
        public string Str4 { get; }

        /// <summary>
        /// 设置浮点数数值
        /// </summary>
        public ByteData(string dataStr)
        {
            if (!string.IsNullOrWhiteSpace(dataStr))
            {
                dataStr = dataStr.ToUpper().Replace(" ", "").Replace("-", "").Replace("0X", "");
                MatchCollection matches = Regex.Matches(dataStr, @"[0-9A-F]{2}");
                if (matches.Count == 4)
                {
                    var bytes = new byte[matches.Count];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = byte.Parse(matches[i].Value, System.Globalization.NumberStyles.AllowHexSpecifier);
                    }

                    Str1 = GetFloatSrt(bytes, ByteOrder._1234);
                    Str2 = GetFloatSrt(bytes, ByteOrder._2143);
                    Str3 = GetFloatSrt(bytes, ByteOrder._3412);
                    Str4 = GetFloatSrt(bytes, ByteOrder._4321);
                }
                else
                {
                    throw new Exception("输入值非法！");
                }
            }
            else
            {
                throw new Exception("输入不可为空！");
            }
        }

        private string GetFloatSrt(byte[] bytes, ByteOrder order)
        {
            float data = float.NaN;
            try
            {
                data = BitConverter.ToSingle(TransformArray(bytes, order), 0);
            }
            catch (Exception e)
            {

            }

            return data.ToString();
        }


        /// <summary>
        /// 转换数组字节序
        /// </summary>
        /// <param name="data"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private static byte[] TransformArray(byte[] data, ByteOrder order)
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
}
