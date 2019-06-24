using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace CSharpCppCLICpp {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Summator s = new Summator(4, 5);

            // Можно потестить с 3000000000 в полях ввода. Оно маршалит до uint64_t
            UInt64 a64 = Convert.ToUInt64(textBox1.Text);
            UInt64 b64 = Convert.ToUInt64(textBox2.Text);

            textBox3.Text = Convert.ToString(s.get64Sum(a64, b64));
            //textBox3.Text = Convert.ToString(s.getSum(a, b));
            //MessageBox.Show(Convert.ToString(s.getInnerSum()));
        }

        private void button2_Click(object sender, EventArgs e) {
            PasswordGenerator pg = new PasswordGenerator(5);
            textBox4.Text = pg.getPassword();
        }
    }

    public sealed class PasswordGenerator {
        public PasswordGenerator(int size) {
            mInstance = pg_initInstance(size);
            mDelete = true;
        }

        public void generate() {
            pg_generate(mInstance);
        }

        public string getPassword() {
            return Marshal.PtrToStringAnsi(pg_getPassword(mInstance));
        }

        private IntPtr mInstance;
        private bool mDelete;

        [DllImport("backend.dll", EntryPoint = "pg_initInstance", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr pg_initInstance(int size);

        [DllImport("backend.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void pg_deleteInstance(IntPtr instance);

        [DllImport("backend.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern void pg_generate(IntPtr instance);

        [DllImport("backend.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern IntPtr pg_getPassword(IntPtr instance);

        internal IntPtr getUnmanaged() {
            return mInstance;
        }

        internal PasswordGenerator(IntPtr instance) {
            Debug.Assert(instance != IntPtr.Zero);
            mInstance = instance;
            mDelete = false;
        }

        ~PasswordGenerator() {
            if (mDelete) {
                pg_deleteInstance(mInstance);
            }
        }
    }

    public sealed class Summator {
        public Summator(int a, int b) {
            mInstance = sm_initInstance(a, b);
            mDelete = true;
        }

        public UInt64 get64Sum(UInt64 a, UInt64 b) {
            return sm_get64Sum(mInstance, a, b);
        }

        public int getSum(int a, int b) {
            return sm_getSum(mInstance, a, b);
        }

        public int getInnerSum() {
            return sm_getInternalSum(mInstance);
        }

        private IntPtr mInstance;
        private bool mDelete;

        [DllImport("backend.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sm_initInstance(int a, int b);

        [DllImport("backend.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void sm_deleteInstance(IntPtr instance);

        [DllImport("backend.dll", EntryPoint = "sm_getSum", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sm_getSum(IntPtr instance, int a, int b);

        [DllImport("backend.dll", EntryPoint = "sm_getInnerSum", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sm_getInternalSum(IntPtr instance);

        [DllImport("backend.dll", EntryPoint = "sm_get64Sum", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U8)]
        private static extern UInt64 sm_get64Sum(IntPtr instance,
            [param: MarshalAs(UnmanagedType.U8)]
            UInt64 a,
            [param: MarshalAs(UnmanagedType.U8)]
            UInt64 b);

        internal IntPtr getUnmanaged() {
            return mInstance;
        }

        internal Summator(IntPtr instance) {
            Debug.Assert(instance != IntPtr.Zero);
            mInstance = instance;
            mDelete = false;
        }

        ~Summator() {
            if (mDelete) {
                sm_deleteInstance(mInstance);
            }
        }
    }
}
