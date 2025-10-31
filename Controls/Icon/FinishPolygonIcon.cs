using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class FinishPolygonIcon : Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;

            // Draw a checkmark or "X" icon to indicate finishing
            // Drawing a checkmark
            var checkPoints = new Point[]
            {
                new Point(mid - 8, mid),
                new Point(mid - 3, mid + 5),
                new Point(mid + 8, mid - 5)
            };
            
            // Draw checkmark with thicker line
            using (Pen thickPen = new Pen(LinePen.Color, 2))
            {
                g.DrawLine(thickPen, checkPoints[0], checkPoints[1]);
                g.DrawLine(thickPen, checkPoints[1], checkPoints[2]);
            }
        }
    }
}

