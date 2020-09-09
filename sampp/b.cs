using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace sampp
{
    public partial class b : UserControl
    {
        private static b _instance;
        public static b Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new b();
                return _instance;
            }
        }

        public b()
        {
            InitializeComponent();
        }

        private void b_Load(object sender, EventArgs e)
        {
          
        }

    }   
}
