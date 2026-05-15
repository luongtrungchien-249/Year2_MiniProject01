using System;
using System.Windows.Forms;
using StrokePredictionWinForms.UI;

namespace StrokePredictionWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Hiện màn hình Login trước
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Mở MainForm truyền ApiClient đã đăng nhập
                Application.Run(new MainForm(loginForm.Api));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}