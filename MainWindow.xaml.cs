using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Input please!", "keikou", MessageBoxButton.OK);
                return;
            }
            textBox2.Text = "";
            string searchText = "";
            string dirScanner = @"D:\xampp\htdocs\t-site-core-master\view\page\";
            //searchText = searchText.Replace(@"/", @"\/");
            int lines = textBox1.LineCount;
            string[] list = textBox1.Text.Split(new System.Char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines; i++)
            {
                if (Path.HasExtension(list[i]))
                {
                    searchText = EncodeNonAsciiCharacters(list[i].Remove(list[i].LastIndexOf(".")));
                }
                else
                {
                    searchText = EncodeNonAsciiCharacters(list[i]);
                }
                searchText = searchText.Replace(@"/", @"\/");
                //textBox2.Text = searchText;
                grepText(dirScanner, searchText);
            }
            //string[] distinctLines = textBox2.Text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None).Distinct().ToArray();
            //textBox2.Text = string.Join("\r\n", distinctLines);
            //searchText = "\\u5e74\\u9f62\\u8a8d\\u8a3c";


        }
        private void grepText(string directory, string searchText)
        {

            if (string.IsNullOrWhiteSpace(searchText))
                return;
            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                string firstOccurrence = lines.FirstOrDefault(l => l.Contains(searchText));
                if (firstOccurrence != null)
                {
                    textBox2.Text += "\\page\\" + Path.GetFileNameWithoutExtension(file) + "\n";
                }
            }
            DirSearch(directory, searchText);
        }
        void DirSearch(string sDir, string searchText)
        {
            string dirPath = "\\view";
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string file in Directory.GetFiles(d))
                    {
                        string[] lines = File.ReadAllLines(file);
                        string firstOccurrence = lines.FirstOrDefault(l => l.Contains(searchText));
                        if (firstOccurrence != null)
                        {
                            string[] a = file.Split(new[] { dirPath }, System.StringSplitOptions.None);
                            textBox2.Text += a[1] + "\n";
                        }
                    }
                    DirSearch(d, searchText);
                }
            }
            catch (System.Exception excpt)
            {
                System.Console.WriteLine(excpt.Message);
            }
        }
        static string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static string DecodeEncodedNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m =>
                {
                    return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
                });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Input please!", "keikou", MessageBoxButton.OK);
                return;
            }
            textBox2.Text = "";
            string searchText = "";


            string dirScanner = @"D:\tsutaya\tsutaya\project_TSUTAYA\10.Share\QuanLD\asset_page_20200130\net-tsutaya-data\export\home\nettsutaya\jlycms\view\page\";
            //textBox2.Text = searchText.Replace(@"/", @"\/");

            int lines = textBox1.LineCount;
            string[] list = textBox1.Text.Split(new System.Char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines; i++)
            {
                if (Path.HasExtension(list[i]))
                {
                    searchText = EncodeNonAsciiCharacters(list[i].Remove(list[i].LastIndexOf(".")));
                }
                else
                {
                    searchText = EncodeNonAsciiCharacters(list[i]);
                }
                searchText = searchText.Replace(@"/", @"\/");
                //textBox2.Text = searchText;
                grepText(dirScanner, searchText);
            }
            //string[] distinctLines = textBox2.Text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None).Distinct().ToArray();
            //textBox2.Text = string.Join("\r\n", distinctLines);
            //searchText = "\\u5e74\\u9f62\\u8a8d\\u8a3c";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Input please!", "keikou", MessageBoxButton.OK);
                return;
            }
            textBox2.Text = "";
            string searchText = "";


            string dirScanner = @"D:\tsutaya\tsutaya\project_TSUTAYA\10.Share\QuanLD\asset_page_20200130\net-tsutaya-data\export\home\nettsutaya\jlycms\approved\page\";
            //textBox2.Text = searchText.Replace(@"/", @"\/");

            int lines = textBox1.LineCount;
            string[] list = textBox1.Text.Split(new System.Char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines; i++)
            {
                if (Path.HasExtension(list[i]))
                {
                    searchText = EncodeNonAsciiCharacters(list[i].Remove(list[i].LastIndexOf(".")));
                }
                else
                {
                    searchText = EncodeNonAsciiCharacters(list[i]);
                }
                searchText = searchText.Replace(@"/", @"\/");
                //textBox2.Text = searchText;
                grepText(dirScanner, searchText);
            }
            //string[] distinctLines = textBox2.Text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None).Distinct().ToArray();
            //textBox2.Text = string.Join("\r\n", distinctLines);
            //searchText = "\\u5e74\\u9f62\\u8a8d\\u8a3c";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Input please!", "keikou", MessageBoxButton.OK);
                return;
            }
            textBox2.Text = "";
            string changeText = EncodeNonAsciiCharacters(textBox1.Text);
            changeText = changeText.Replace(@"/", @"\/");
            textBox2.Text = changeText;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Form
        }
    }
}
