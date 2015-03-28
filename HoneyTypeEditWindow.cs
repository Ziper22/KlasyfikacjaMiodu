using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Marek Borski<para/>
    /// </summary>
    /// 
    public partial class HoneyTypeEditWindow : Form
    {
        public delegate void OkButtonClickedDelegate(HoneyType honeyType);
        public event OkButtonClickedDelegate OkButtonClicked;
        private HoneyType honeyType;

        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            honeyType = new HoneyType("", "", Color.White);
        }

        public HoneyTypeEditWindow(HoneyType honeyType)
        {
            InitializeComponent();
            this.honeyType = honeyType;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OnOkButtonClicked();
        }

        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(honeyType);
        }        
    }
}
