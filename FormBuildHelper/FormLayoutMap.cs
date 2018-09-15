using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace FormBuildHelper
{
    class FormLayoutMap
    {
        public FormLayoutMap()
        {

        }
        public Image Image { get; set; }        
        public List<FieldMap> Fields { get; set; }
        public String Name { get; set;  }
        public Uri OwnerUrl { get; set; }
        public String Notes { get; set; }

        public Object GetAsForm()
        {
            return new object();
        }

        public void IdentifyScan()
        {

        }


        public class FieldMap
        {
            public Image FieldContentImage { get; set; }
            public FieldMap Parent { get; set; }
            public String Name { get; set; }
            public Boolean IsHighlighted { get; set; }
            public Type ControlType {get; set;}
            public Type ValueType { get; set; }
            public Rectangle Rect { get; set; }
            public Point Location { get; set; }
            public Size Size { get; set; }
            public Object Value { get; set; }
            public Boolean FromParentsValue { get; set; }
            public String XmlString { get; set; }
            public Boolean IsIdentifier { get; set; }
            public String Key { get; set; }
            public List<FieldMap> Children { get; set; }
            public Int32 Ordinal { get; set;  }
            public String ColumnName { get; set; }
            public Type SqlType { get; set; }
            public String Notes { get; set; }

            public FieldMap()
            {

            }
            public Object GetAsControl()
            {
                return new object();

            }
            public void Highlight()
            {

            }


        }




    }
}
