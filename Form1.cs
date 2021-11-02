using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorGraphics
{
    struct graphicElement
    {
        private Color color;
        private Point point1, point2;

        public graphicElement(Point point1, Point point2) : this()
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public graphicElement(Color color, Point point1, Point point2)
        {
            this.color = color;
            this.point1 = point1;
            this.point2 = point2;
        }

        public Color Color => color;

        public Point Point1 => point1;

        public Point Point2 => point2;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            graphicElement window = new graphicElement(new Point(0, 0), new Point(ClientSize.Width, ClientSize.Height));

            Graphics graphics = e.Graphics;
            drawCross(graphics, window);
            drawRect(graphics, window);
            drawCircle(graphics, window);
        }

        private void drawCross(Graphics graphics, graphicElement window)
        {
            Color color = Color.Red;
            Pen pen = new Pen(color);

            graphicElement lineHorizontal = new graphicElement(color, new Point(window.Point1.X, window.Point2.Y / 2),
                new Point(window.Point2.X, window.Point2.Y / 2));
            graphicElement lineVertical = new graphicElement(color, new Point(window.Point2.X / 2, window.Point1.Y),
                new Point(window.Point2.X / 2, window.Point2.Y));

            graphics.DrawLine(pen, lineHorizontal.Point1, lineHorizontal.Point2);
            graphics.DrawLine(pen, lineVertical.Point1, lineVertical.Point2);
        }

        private void drawRect(Graphics graphics, graphicElement window)
        {
            Color color = Color.Blue;
            Pen pen = new Pen(color);

            Padding padding = new Padding(3);
            Rectangle rectangle = new Rectangle(window.Point1.X, window.Point1.Y, window.Point2.X, window.Point2.Y);
            rectangle.Inflate(-padding.Size.Width, -padding.Size.Height);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void drawCircle(Graphics graphics, graphicElement window)
        {
            Color color = Color.Green;
            Pen pen = new Pen(color);

            Padding padding = new Padding(3);
            Rectangle rectangle = new Rectangle(window.Point1.X, window.Point1.Y, window.Point2.X, window.Point2.Y);
            rectangle.Inflate(-padding.Size.Width, -padding.Size.Height);
            graphics.DrawEllipse(pen, rectangle);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}