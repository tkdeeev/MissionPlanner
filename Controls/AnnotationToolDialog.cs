using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class AnnotationToolDialog : Form
    {
        public enum AnnotationTool
        {
            Rectangle,
            Circle,
            Polygon,
            Pen
        }

        public enum LineStyle
        {
            Solid,
            Dashed,
            Dots
        }

        public AnnotationTool SelectedTool { get; private set; } = AnnotationTool.Rectangle;
        public Color SelectedColor { get; private set; } = Color.Red;
        public LineStyle SelectedLineStyle { get; private set; } = LineStyle.Solid;

        private readonly Color[] availableColors = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Orange,
            Color.Purple,
            Color.Black,
            Color.Pink
        };

        private RadioButton[] toolButtons;
        private Button[] colorButtons;
        private RadioButton[] styleButtons;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTool;
        private Label lblColor;
        private Label lblStyle;

        public AnnotationToolDialog()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Annotation Tool";
            this.Size = new Size(320, 300);

            int yPos = 10;

            // Tool selection
            lblTool = new Label
            {
                Text = "Tool:",
                Location = new Point(10, yPos),
                Size = new Size(50, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTool);

            yPos += 25;

            toolButtons = new RadioButton[4];
            string[] toolNames = { "Rectangle", "Circle", "Polygon", "Pen" };
            for (int i = 0; i < toolButtons.Length; i++)
            {
                toolButtons[i] = new RadioButton
                {
                    Text = toolNames[i],
                    Location = new Point(20, yPos + i * 25),
                    Size = new Size(100, 20),
                    AutoSize = true
                };
                if (i == 0) toolButtons[i].Checked = true;
                toolButtons[i].CheckedChanged += ToolButton_CheckedChanged;
                this.Controls.Add(toolButtons[i]);
            }

            yPos += toolButtons.Length * 25 + 15;

            // Color selection
            lblColor = new Label
            {
                Text = "Color:",
                Location = new Point(10, yPos),
                Size = new Size(50, 20),
                AutoSize = true
            };
            this.Controls.Add(lblColor);

            yPos += 25;

            colorButtons = new Button[8];
            int colorButtonSize = 30;
            int colorButtonSpacing = 35;
            int colorsPerRow = 4;
            for (int i = 0; i < colorButtons.Length; i++)
            {
                int row = i / colorsPerRow;
                int col = i % colorsPerRow;
                colorButtons[i] = new Button
                {
                    Location = new Point(20 + col * colorButtonSpacing, yPos + row * colorButtonSpacing),
                    Size = new Size(colorButtonSize, colorButtonSize),
                    BackColor = availableColors[i],
                    FlatStyle = FlatStyle.Flat,
                    Tag = i
                };
                colorButtons[i].FlatAppearance.BorderSize = 2;
                colorButtons[i].FlatAppearance.BorderColor = Color.Gray;
                if (i == 0) // Red is default
                {
                    colorButtons[i].FlatAppearance.BorderColor = Color.Black;
                    colorButtons[i].FlatAppearance.BorderSize = 3;
                }
                colorButtons[i].Click += ColorButton_Click;
                this.Controls.Add(colorButtons[i]);
            }

            yPos += (colorButtons.Length / colorsPerRow) * colorButtonSpacing + 15;

            // Line style selection
            lblStyle = new Label
            {
                Text = "Line Style:",
                Location = new Point(10, yPos),
                Size = new Size(70, 20),
                AutoSize = true
            };
            this.Controls.Add(lblStyle);

            yPos += 25;

            styleButtons = new RadioButton[3];
            string[] styleNames = { "Solid", "Dashed", "Dots" };
            for (int i = 0; i < styleButtons.Length; i++)
            {
                styleButtons[i] = new RadioButton
                {
                    Text = styleNames[i],
                    Location = new Point(20, yPos + i * 25),
                    Size = new Size(100, 20),
                    AutoSize = true
                };
                if (i == 0) styleButtons[i].Checked = true;
                styleButtons[i].CheckedChanged += StyleButton_CheckedChanged;
                this.Controls.Add(styleButtons[i]);
            }

            yPos += styleButtons.Length * 25 + 20;

            // OK and Cancel buttons
            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(140, yPos),
                Size = new Size(75, 30),
                DialogResult = DialogResult.OK
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(225, yPos),
                Size = new Size(75, 30),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void ToolButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                for (int i = 0; i < toolButtons.Length; i++)
                {
                    if (toolButtons[i] == rb)
                    {
                        SelectedTool = (AnnotationTool)i;
                        break;
                    }
                }
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int index = (int)btn.Tag;
                SelectedColor = availableColors[index];

                // Update border to show selection
                foreach (var colorBtn in colorButtons)
                {
                    colorBtn.FlatAppearance.BorderColor = Color.Gray;
                    colorBtn.FlatAppearance.BorderSize = 2;
                }
                btn.FlatAppearance.BorderColor = Color.Black;
                btn.FlatAppearance.BorderSize = 3;
            }
        }

        private void StyleButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                for (int i = 0; i < styleButtons.Length; i++)
                {
                    if (styleButtons[i] == rb)
                    {
                        SelectedLineStyle = (LineStyle)i;
                        break;
                    }
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public Pen CreatePen()
        {
            Pen pen = new Pen(SelectedColor, 2);
            switch (SelectedLineStyle)
            {
                case LineStyle.Dashed:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyle.Dots:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case LineStyle.Solid:
                default:
                    pen.DashStyle = DashStyle.Solid;
                    break;
            }
            return pen;
        }
    }
}


