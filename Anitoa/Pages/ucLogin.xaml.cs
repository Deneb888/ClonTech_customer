﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anitoa.Pages
{
    /// <summary>
    /// ucLogin.xaml 的交互逻辑
    /// </summary>
    public partial class ucLogin : UserControl
    {
        public event EventHandler LoginOK;
        public ucLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                case "btnLogin":
                    Login();
                    break;
                case "btnRegist":
                    break;
            }
        }


        private void Login()
        {
            var user = CommData.GetUser(txtyhm.Text, txtpass.Password);
            if (user == null)
            {
                //                MessageBox.Show("用户名或者密码错误");
                MessageBox.Show("User name or password failure.");
            }
            else
            {
                if (LoginOK != null)
                {
                    if (user.Uname == "admin")
                    {
                        if (MessageBox.Show("Changing the cycler’s settings in administrator mode will affect assay measurement results.  Are you sure you want to proceed?",
                            "Now entering administrator mode ", MessageBoxButton.YesNo) == MessageBoxResult.No)
                            return;
                    }

                    CommData.user = user;
                    LoginOK("1", null);
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string name = "";
            if (sender is Border)
            {
                name = (sender as Border).Name;
            }
            if (sender is TextBlock)
            {
                name = (sender as TextBlock).Name;
            }

            switch (name)
            {
                case "mdlogin":
                    Login();
                    break;
                case "mdPass":
                    break;
                case "mdregister":
                    break;
            }
        }

        private void keyPassWd(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Login();
            }
        }
    }
}
