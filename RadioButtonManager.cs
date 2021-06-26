using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDashboard
{
    public partial class RadioButtonManager : Component
    {
        List<IRadioButtonKind> _items = new List<IRadioButtonKind>();
        public RadioButtonManager()
        {
            InitializeComponent();
        }

        public RadioButtonManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void Add(IRadioButtonKind target)
        {
            _items.Add(target);

            target.BindCheckedChangedHandler(Btn_CheckedChanged);
        }

        private void Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (((IRadioButtonKind)sender).GetChecked())
            {
                foreach (var btn in _items)
                {
                    if (btn != sender)
                    {
                        btn.SetChecked(false);
                    }
                }
            }
        }
    }
}
