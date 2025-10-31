using System.Drawing;
using System.Drawing.Drawing2D;

namespace MissionPlanner.Controls.Icon
{
    public class LineStyleIcon : Icon
    {
        public enum LineStyleType
        {
            Solid,
            Dashed,
            Dots
        }

        private LineStyleType styleType;

        public LineStyleIcon(LineStyleType type)
        {
            styleType = type;
        }

        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;
            var y = Height / 2;

            System.Drawing.Pen stylePen = new System.Drawing.Pen(ForeColor, 2);
            
            switch (styleType)
            {
                case LineStyleType.Solid:
                    stylePen.DashStyle = DashStyle.Solid;
                    break;
                case LineStyleType.Dashed:
                    stylePen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyleType.Dots:
                    stylePen.DashStyle = DashStyle.Dot;
                    break;
            }

            g.DrawLine(stylePen, mid - 10, y, mid + 10, y);
            stylePen.Dispose();
        }
    }
}

