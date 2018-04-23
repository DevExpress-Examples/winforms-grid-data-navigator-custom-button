using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomButton {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // load some demo data
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            gridView1.OptionsSelection.MultiSelect = true;

            gridControl1.UseEmbeddedNavigator = true;
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(gridControl1_EmbeddedNavigator_ButtonClick);
            gridControl1.EmbeddedNavigator.Buttons.ImageList = imageCollection1;
            DevExpress.XtraEditors.NavigatorCustomButton button;
            button = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button.Tag = "copy";
            button.Hint = "Copy to clipboard";
            button.ImageIndex = 0;
        }

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            if("copy".Equals(e.Button.Tag)) {
                if(gridControl1.FocusedView != null) {
                    gridControl1.FocusedView.CopyToClipboard();
                    MessageBox.Show("Selected data has been copied to the Clipboard");
                    e.Handled = true;
                }
            }
        }
    }
}