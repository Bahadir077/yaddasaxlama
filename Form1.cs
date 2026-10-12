using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            SetupPlaceholder(textBox1, "istifadəçi adı");
            SetupPlaceholder(textBox2, "gmail ünvanı");
            SetupPlaceholder(textBox3, "telefon");

         
            button1.Click += Button1_Click; 
            button2.Click += Button2_Click; 
        }

   
        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Şəkil Faylları|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Şəkil Seçin";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "istifadəçi adı" || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Xahiş olunur istifadəçi adını daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            progressBar1.Value = 0;
            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (s, args) =>
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value += 5;
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("Məlumatlar uğurla yadda saxlanıldı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            timer.Start();
        }

        
        private void SetupPlaceholder(TextBox txt, string placeholderText)
        {
            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholderText)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholderText;
                    txt.ForeColor = Color.Gray;
                }
            };
        }
    }
}