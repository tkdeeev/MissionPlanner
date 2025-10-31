using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class PenIcon : Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;

            // Draw a pencil/pen icon - simple angled rectangle with tip
            // Pen body (angled rectangle)
            var penOutline = new Point[]
            {
                new Point(mid - 8, mid + 6),
                new Point(mid - 6, mid + 8),
                new Point(mid + 6, mid - 8),
                new Point(mid + 4, mid - 10),
                new Point(mid - 8, mid + 6)
            };
            g.DrawLines(LinePen, penOutline);
            
            // Draw horizontal lines for pencil body
            g.DrawLine(LinePen, mid - 6, mid + 5, mid + 4, mid - 9);
            g.DrawLine(LinePen, mid - 6, mid + 7, mid + 4, mid - 7);
            
            // Pen tip (small triangle)
            g.FillPolygon(new SolidBrush(LinePen.Color), new Point[]
            {
                new Point(mid + 4, mid - 10),
                new Point(mid + 6, mid - 8),
                new Point(mid + 5, mid - 8)
            });
        }
    }
}

