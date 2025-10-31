using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class EraserIcon : Icon
    {
        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;

            // Draw an eraser icon - a rectangle (eraser) with crossed diagonal lines
            // Eraser body (rectangle)
            var rect = new Rectangle(mid - 8, mid - 5, 16, 10);
            g.DrawRectangle(LinePen, rect);
            
            // Fill rectangle with light gray to represent eraser
            using (var eraserBrush = new SolidBrush(Color.FromArgb(200, 200, 200)))
            {
                g.FillRectangle(eraserBrush, rect);
            }
            
            // Draw diagonal X pattern to indicate erasing
            g.DrawLine(LinePen, mid - 6, mid - 3, mid + 6, mid + 3);
            g.DrawLine(LinePen, mid - 6, mid + 3, mid + 6, mid - 3);
        }
    }
}
