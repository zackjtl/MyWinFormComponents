using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDashboard
{
    public interface IRadioButtonKind
    {
        void SetChecked(bool value);
        bool GetChecked();
        void BindCheckedChangedHandler(EventHandler value);
    }
    public partial class ActivePictureBox : PictureBox, IRadioButtonKind
    {
        public ActivePictureBox()
        {
            InitializeComponent();

            this.Click += Clicked;
        }

        public EventHandler CheckedChanged;

        public ActivePictureBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            this.Click += Clicked;                    
            //
        }

        Image _ImageOrg;
        Image _ImageDown;
        Image _ImageChecked;
        Image _ImageHover;
        Image _ImageCheckedHover;

        bool _Checked;

        RadioButtonManager radioButtonManager;

        [Description("Radio Button Manager")]
        [Category("Function")]
        [DefaultValue(typeof(RadioButtonManager))]
        public RadioButtonManager RadioButtonManager
        {
            get => radioButtonManager;
            set
            {
                if (value == null) return;
                radioButtonManager = value;
                value.Add(this);
            }
        }

        [Description("Image Original")]
        [Category("Images")]
        [DefaultValue(typeof(Image))]
        public Image ImageOrg
        {
            get => _ImageOrg;
            set
            {
                _ImageOrg = value;
            }
        }
        [Description("Image Down")]
        [Category("Images")]
        [DefaultValue(typeof(Image))]
        public Image ImageDown
        {
            get => _ImageDown;
            set
            {
                _ImageDown = value;
            }
        }
        [Description("Image Checked")]
        [Category("Images")]
        [DefaultValue(typeof(Image))]
        public Image ImageChecked
        {
            get => _ImageChecked;
            set
            {
                _ImageChecked = value;
            }
        }
        [Description("Image Hover")]
        [Category("Images")]
        [DefaultValue(typeof(Image))]
        public Image ImageHover
        {
            get => _ImageHover;
            set
            {
                _ImageHover = value;
            }
        }
        [Description("Image Checked Hover")]
        [Category("Images")]
        [DefaultValue(typeof(Image))]
        public Image ImageCheckedHover
        {
            get => _ImageCheckedHover;
            set
            {
                _ImageCheckedHover = value;
            }
        }
        [Description("Checked")]
        [Category("Function")]
        [DefaultValue(typeof(bool))]
        public bool Checked
        {
            get => _Checked;
            set
            {
                SetChecked(value);
            }
        }
        public void SetChecked(bool value)
        {
            bool orgChecked = _Checked;
            _Checked = value;

            if (orgChecked != value)
            {
                if (value == false)
                {
                    Image = _ImageOrg;
                }
                if (CheckedChanged != null)
                    CheckedChanged.Invoke(this, new EventArgs());
            }
        }
        public bool GetChecked()
        {
            return _Checked;
        }
        public void BindCheckedChangedHandler(EventHandler value)
        {
            CheckedChanged = value;
        }

        private void Clicked(object sender, EventArgs e)
        {
            if (!_Checked)
                Checked = true;
        }
        /*
        private void radioBtnCheckedChanged(object sender, EventArgs e)
        {
            if (CheckedChanged != null)
                CheckedChanged.Invoke(sender, e);

            if (((RadioButton)sender).Checked == false)
            {
                Image = _ImageOrg;
            }
        }*/
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (Checked)
            {
                Image = _ImageCheckedHover;
            }
            else
            {
                Image = _ImageHover;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (Checked)
            {
                Image = _ImageChecked;
            }
            else
            {
                Image = _ImageOrg;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = _ImageDown;            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Checked)
            {
                Image = _ImageCheckedHover;
            }
            else
            {
                Image = _ImageHover;
            }
        }


    }
}
