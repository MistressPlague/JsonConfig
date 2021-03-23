using Libraries;
using System;
using System.Windows.Forms;

namespace ConfigTest
{
    public partial class JsonConfigTest : Form
    {
        public static JsonConfigTest Instance;

        public Configuration configuration = new Configuration();

        /// <summary>
        /// An Example Of How To Automate The Entire Config Process, Even For WinForms.
        /// </summary>
        public class Configuration
        {
            public bool Readable
            {
                get => Instance.checkBox1.Checked;
                set => Instance.checkBox1.Checked = value;
            }

            public int Test1
            {
                get => (int)Instance.numericUpDown1.Value;
                set => Instance.numericUpDown1.Value = value;
            }

            public string Test2
            {
                get => Instance.textBox2.Text;
                set => Instance.textBox2.Text = value;
            }

            public bool Test3
            {
                get => Instance.checkBox2.Checked;
                set => Instance.checkBox2.Checked = value;
            }

            public float Test4
            {
                get => (float)Instance.numericUpDown2.Value;
                set => Instance.numericUpDown2.Value = (decimal)value;
            }

            public string[] Test5
            {
                get => Instance.textBox3.Text.Replace("\r", "").Split('\n');
                set => Instance.textBox3.Text = string.Join("\r\n", value);
            }
        }

        public JsonConfigTest()
        {
            InitializeComponent();
        }

        private string ConfigPath = Environment.CurrentDirectory + "\\TestConfig.json";

        private void ConfigTest_Load(object sender, EventArgs e)
        {
            Instance = this;

            var Result = JsonConfig.LoadConfig(ref configuration, ConfigPath);

            MessageBox.Show(Result.Item1 + " " + Result.Item2, "Info");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Result = JsonConfig.LoadConfig(ref configuration, ConfigPath);

            MessageBox.Show(Result.Item1 + " " + Result.Item2, "Info");
        }

        public void Save()
        {
            var Result = JsonConfig.SaveConfig(configuration, ConfigPath, checkBox1.Checked);

            MessageBox.Show(Result.Item1 + " " + Result.Item2, "Info");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Save();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //Save();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Save();
        }
    }
}
