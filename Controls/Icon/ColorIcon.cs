using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class ColorIcon : Icon
    {
        private Color iconColor;

        public Color IconColor
        {
            get { return iconColor; }
        }

        public ColorIcon(Color color)
        {
            iconColor = color;
            BackColor = color;
        }

        internal override void doPaint(Graphics g)
        {
            // Just fill the circle with the color
            var rect = new Rectangle(0, 0, Width, Height);
            g.FillEllipse(new SolidBrush(iconColor), rect);
            g.DrawArc(LinePen, rect, 0, 360);
        }
    }
}

