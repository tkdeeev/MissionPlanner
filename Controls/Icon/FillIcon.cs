using System.Drawing;

namespace MissionPlanner.Controls.Icon
{
    public class FillIcon : Icon
    {
        public enum FillType
        {
            NoFill,
            LightFill,
            StrongFill
        }

        private FillType fillType;

        public FillIcon(FillType type)
        {
            fillType = type;
        }

        internal override void doPaint(Graphics g)
        {
            var mid = Width / 2;
            var size = 16;
            
            // Draw a rectangle shape to represent fill
            Rectangle rect = new Rectangle(mid - size/2, mid - size/2, size, size);
            
            switch (fillType)
            {
                case FillType.NoFill:
                    // Just outline
                    g.DrawRectangle(LinePen, rect);
                    break;
                case FillType.LightFill:
                    // 10% fill - draw outline and a light pattern
                    g.DrawRectangle(LinePen, rect);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(25, LinePen.Color)))
                    {
                        g.FillRectangle(brush, rect);
                    }
                    break;
                case FillType.StrongFill:
                    // 50% fill - draw outline and a stronger pattern
                    g.DrawRectangle(LinePen, rect);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, LinePen.Color)))
                    {
                        g.FillRectangle(brush, rect);
                    }
                    break;
            }
        }
    }
}

