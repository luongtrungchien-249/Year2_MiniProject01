using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StrokePredictionWinForms.UI
{
    public static class ModernUI
    {
        public class ModernPanel : Panel
        {
            public int BorderRadius { get; set; } = 15;
            public Color BorderColor { get; set; } = Color.Transparent;
            public int BorderSize { get; set; } = 0;
            public bool Shadow { get; set; } = false;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
                {
                    this.Region = new Region(path);

                    if (BorderSize > 0)
                    {
                        using (Pen pen = new Pen(BorderColor, BorderSize))
                        {
                            pen.Alignment = PenAlignment.Inset;
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        public class ModernButton : Button
        {
            public int BorderRadius { get; set; } = 12;
            public Color HoverColor { get; set; } = Color.Empty;
            private Color _originalColor;

            public ModernButton()
            {
                FlatStyle = FlatStyle.Flat;
                FlatAppearance.BorderSize = 0;
                Cursor = Cursors.Hand;
                Font = new Font("Segoe UI", 10, FontStyle.Bold);
                ForeColor = Color.White;
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                _originalColor = BackColor;
                if (HoverColor != Color.Empty) BackColor = HoverColor;
                else BackColor = ControlPaint.Light(BackColor, 0.2f);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                BackColor = _originalColor;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
                {
                    this.Region = new Region(path);
                }
            }
        }

        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void FillRoundedRectangle(Graphics g, Brush b, Rectangle r, int radius)
        {
            using (GraphicsPath path = GetRoundedPath(r, radius))
            {
                g.FillPath(b, path);
            }
        }
    }
}
