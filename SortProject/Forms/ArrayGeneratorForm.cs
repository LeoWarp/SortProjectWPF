using SortProject.Services.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SortProject.Forms
{
    public partial class ArrayGeneratorForm : Form
    {
        public ArrayGeneratorForm()
        {
            InitializeComponent();
            trackBar1.Scroll += TrackBar_Scroll;
            trackBar1.Maximum = 500;
        }

        private void ArrayGeneratorForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(200, 200);
            this.MaximumSize = new Size(200, 200);
            this.BackColor = Color.DarkGray;
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            ArrayService arrayService = new ArrayService();
            arrayService.SetTheNumberOfElements(trackBar1.Value);
            arrayService.FillArray();
            label1.Text = String.Format("{0}", trackBar1.Value);
        }
    }
}
