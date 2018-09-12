using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace RetroTable.Main
{
    public partial class RotatingLabel : System.Windows.Forms.Label
    {
        private int m_RotateAngle = 0;
        private string m_NewText = string.Empty;

        public int RotateAngle { get { return m_RotateAngle; } set { m_RotateAngle = value; Invalidate(); } }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string NewText
        {
            get { return m_NewText; }
            set
            {
                if (value == m_NewText) return;

                System.Diagnostics.Debug.WriteLine("Alter Text: " + m_NewText);

                if (value == "")
                    m_NewText = " ";
                else
                    m_NewText = value;
                System.Diagnostics.Debug.WriteLine("Neuer Text: " + m_NewText);

                if (m_NewText.Length > 1)
                    m_NewText = m_NewText.TrimStart(' ');

                Invalidate();
            }
        }
        public bool AlignText { get; set; }


        public RotatingLabel()
        {          
            SizeChanged += RotatingLabel_SizeChanged;
        }

        private int OldSizeWidth;

        private void RotatingLabel_SizeChanged(object sender, EventArgs e)
        {
            if (Parent == null) return;

            if (OldSizeWidth == 0)
            {
                OldSizeWidth = Size.Width;
                return;
            }

            if (RotateAngle == 90)
            {
                var change = Size.Width - OldSizeWidth;
                Location = new Point(Location.X - change, Location.Y);
                OldSizeWidth = Size.Width;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Func<double, double> DegToRad = (angle) => Math.PI * angle / 180.0;

            Brush b = new SolidBrush(this.ForeColor);
            SizeF size = e.Graphics.MeasureString(this.NewText, this.Font, this.Parent.Width);

            int normalAngle = ((RotateAngle % 360) + 360) % 360;
            double normaleRads = DegToRad(normalAngle);

            int hSinTheta = (int)Math.Ceiling((size.Height * Math.Sin(normaleRads)));
            int wCosTheta = (int)Math.Ceiling((size.Width * Math.Cos(normaleRads)));
            int wSinTheta = (int)Math.Ceiling((size.Width * Math.Sin(normaleRads)));
            int hCosTheta = (int)Math.Ceiling((size.Height * Math.Cos(normaleRads)));

            int rotatedWidth = Math.Abs(hSinTheta) + Math.Abs(wCosTheta);
            int rotatedHeight = Math.Abs(wSinTheta) + Math.Abs(hCosTheta);

            this.Width = rotatedWidth;
            this.Height = rotatedHeight;

            if (AlignText && Location.Y != Convert.ToInt32(Parent.Size.Height / 2f - Size.Height / 2f))
            {
                Align();
            }

            if (RotateAngle == 90)
            {
            }

            int numQuadrants =
                (normalAngle >= 0 && normalAngle < 90) ? 1 :
                (normalAngle >= 90 && normalAngle < 180) ? 2 :
                (normalAngle >= 180 && normalAngle < 270) ? 3 :
                (normalAngle >= 270 && normalAngle < 360) ? 4 :
                0;

            int horizShift = 0;
            int vertShift = 0;

            if (numQuadrants == 1)
            {
                horizShift = Math.Abs(hSinTheta);
            }
            else if (numQuadrants == 2)
            {
                horizShift = rotatedWidth;
                vertShift = Math.Abs(hCosTheta);
            }
            else if (numQuadrants == 3)
            {
                horizShift = Math.Abs(wCosTheta);
                vertShift = rotatedHeight;
            }
            else if (numQuadrants == 4)
            {
                vertShift = Math.Abs(wSinTheta);
            }

            e.Graphics.TranslateTransform(horizShift, vertShift);
            e.Graphics.RotateTransform(this.RotateAngle);

            e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);
            base.OnPaint(e);
        }

        private void Align()
        {
            System.Diagnostics.Debug.WriteLine("Alte Location: " + Location.X + " | " + Location.Y);
            System.Diagnostics.Debug.WriteLine("Parent Height: " + Parent.Size.Height + " Component Height : " + Size.Height);
            Location = new Point(Location.X, Convert.ToInt32(Parent.Size.Height / 2f - Size.Height / 2f));
            System.Diagnostics.Debug.WriteLine("Neue Location: " + Location.X + " | " + Location.Y);
        }

        //internal void ChangeText(string newText)
        //{
        //    if (newText == NewText) return;

        //    System.Diagnostics.Debug.WriteLine("Alter Text: " + NewText);
        //    if (newText == "")
        //        NewText = " ";
        //    else
        //        NewText = newText;
        //    System.Diagnostics.Debug.WriteLine("Neuer Text: " + NewText);
        //}

        //internal void AppendText(string text, bool midAlign)
        //{
        //    if (NewText == " ") NewText = "";
        //    ChangeText(NewText + text);
        //}
    }
}
