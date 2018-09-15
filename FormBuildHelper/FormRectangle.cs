using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FormBuildHelper
{
    public partial class FormRectangle : Component
    {
        public FormRectangle()
        {
            InitializeComponent();
        }

        public FormRectangle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void InnerPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
