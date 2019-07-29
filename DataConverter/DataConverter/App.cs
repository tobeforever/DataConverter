/*==================================================================================================
** 类 名 称:App
** 创 建 人:xiaopeng_liu
** 当前版本：V1.0.0
** CLR 版本:4.0.30319.42000
** 创建时间:2019/7/26 16:09:52

** 修改人		修改时间		修改后版本		修改内容


** 功能描述：
 
==================================================================================================
 Copyright @2019. Focused Photonics Inc. All rights reserved.
==================================================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using DataConverter.Views;
using Xamarin.Forms;

namespace DataConverter
{
    public class App : Application
    {
        public App()
        {
            MainPage = new MainPage();
        }
    }
}
