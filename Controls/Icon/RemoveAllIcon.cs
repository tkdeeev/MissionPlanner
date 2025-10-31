using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class RemoveAllIcon : Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;

            // Draw an X icon to indicate remove all
            // Draw a circle with X inside
            g.DrawEllipse(LinePen, mid - 8, mid - 8, 16, 16);
            
            // Draw X inside circle
            g.DrawLine(LinePen, mid - 5, mid - 5, mid + 5, mid + 5);
            g.DrawLine(LinePen, mid - 5, mid + 5, mid + 5, mid - 5);
        }
    }
}

