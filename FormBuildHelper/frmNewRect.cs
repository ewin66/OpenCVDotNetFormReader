using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBuildHelper
{
    public partial class frmNewRect : Form
    {
        frmImage referringForm;
        Rectangle cRect;

        public frmNewRect(frmImage formRef)
        {
            InitializeComponent();
            referringForm = formRef;
            
 
        }

        private void NewRect_Load(object sender, EventArgs e)
        {
            
        }

        FormLayoutMap LayoutMap;
        FormLayoutMap.FieldMap FieldMap;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTapUpperLeft_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnTapUpperLeft.Enabled = false;
            cRect = referringForm.StartNewRect();

            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            referringForm.RectUp(10, btnIsUpperLeft.Checked);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            referringForm.RectLeft(10, btnIsUpperLeft.Checked);
        }




        /*
        public Image FieldContentImage { get; set; }
        public FormLayoutMap.FieldMap Parent { get; set; }
        public String Name { get; set; }
        public Boolean IsHighlighted { get; set; }
        public Type ControlType { get; set; }
        public Type ValueType { get; set; }
        public Rectangle Rect { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Object Value { get; set; }
        public Boolean FromParentsValue { get; set; }
        public String XmlString { get; set; }
        public Boolean IsIdentifier { get; set; }
        public String Key { get; set; }
        public List<FormLayoutMap.FieldMap> Children { get; set; }
        public Int32 Ordinal { get; set; }
        public String ColumnName { get; set; }
        public Type SqlType { get; set; }
        public String Notes { get; set; }
        */
    }
}
