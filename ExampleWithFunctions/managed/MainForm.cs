using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace CSharpPlusNativeExample {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        [DllImport("Native.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int fast_add(int a, int b);

        private void addButton_Click(object sender, EventArgs e) {
            int number1 = Convert.ToInt32(this.textBox1.Text);
            int number2 = Convert.ToInt32(this.textBox2.Text);

            // Без использования DLL C++
            //this.textBox3.Text = Convert.ToString(number1 + number2);

            // С использованием функции из DLL C++
            int res = fast_add(number1, number2);
            this.textBox3.Text = Convert.ToString(res);
        }
    }
}
