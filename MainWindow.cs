using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 由 XAML 中所有 TextBox 的 TextChanged 綁定呼叫（目前為空，可用來做輸入驗證）
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 可以在此加入即時驗證數字輸入的程式碼（視需要）
        }

        // 訂購按鈕的處理器（對應 XAML 的 Click="OrderButton_Click"）
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 逐一讀取每種飲料數量（空字串視為 0）
                int redL = ParseQty(TxtRedTeaL.Text);
                int redS = ParseQty(TxtRedTeaS.Text);
                int greenL = ParseQty(TxtGreenTeaL.Text);
                int greenS = ParseQty(TxtGreenTeaS.Text);
                int cokeL = ParseQty(TxtCokeL.Text);
                int cokeS = ParseQty(TxtCokeS.Text);

                const int PriceRedL = 60;
                const int PriceRedS = 40;
                const int PriceGreenL = 60;
                const int PriceGreenS = 40;
                const int PriceCokeL = 50;
                const int PriceCokeS = 30;

                int total = redL * PriceRedL
                          + redS * PriceRedS
                          + greenL * PriceGreenL
                          + greenS * PriceGreenS
                          + cokeL * PriceCokeL
                          + cokeS * PriceCokeS;

                var sb = new StringBuilder();
                if (redL > 0) sb.AppendLine($"紅茶大杯 x{redL} = {redL * PriceRedL} 元");
                if (redS > 0) sb.AppendLine($"紅茶小杯 x{redS} = {redS * PriceRedS} 元");
                if (greenL > 0) sb.AppendLine($"綠茶大杯 x{greenL} = {greenL * PriceGreenL} 元");
                if (greenS > 0) sb.AppendLine($"綠茶小杯 x{greenS} = {greenS * PriceGreenS} 元");
                if (cokeL > 0) sb.AppendLine($"可樂大杯 x{cokeL} = {cokeL * PriceCokeL} 元");
                if (cokeS > 0) sb.AppendLine($"可樂小杯 x{cokeS} = {cokeS * PriceCokeS} 元");

                sb.AppendLine();
                sb.AppendLine($"總計：{total} 元");

                ResultTextBlock.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"計算時發生錯誤：{ex.Message}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 輔助：安全地把欄位文字轉為數量，非數字或空字串視為 0
        private static int ParseQty(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            return int.TryParse(text.Trim(), out var v) && v >= 0 ? v : 0;
        }
    }
}