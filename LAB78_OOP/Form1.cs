using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LAB78_OOP
{
    public partial class Form1 : Form
    {
        Storage<Shape> sto = new Storage<Shape>();
        public Form1()
        {
          
            InitializeComponent();
            (pictureBox1 as Control).KeyPress += new KeyPressEventHandler(PressEventHandler);    
        }


        public void PressEventHandler(object sender, KeyPressEventArgs e)
        {
            if (sto.size() != 0)
            {
                if (e.KeyChar == 119)
                {
                    
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                            sto.getIterator().OffsetXY(0, -2, pictureBox1.Width, pictureBox1.Height);

                    }
                }
                if (e.KeyChar == 115) 
                    {
                  
                    for (int i = 0; i < sto.size(); i++, sto.next()) {
                        if (sto.getIterator().selected)
                            sto.getIterator().OffsetXY(0, 2, pictureBox1.Width, pictureBox1.Height);

                        }
                }
                if (e.KeyChar == 97)
                {
                  
                    for (int i = 0; i < sto.size(); i++, sto.next())

                    {
                        if (sto.getIterator().selected)
                            sto.getIterator().OffsetXY(-2, 0, pictureBox1.Width, pictureBox1.Height);

                    }
                }
                if (e.KeyChar == 100)
                {
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                            sto.getIterator().OffsetXY(2, 0, pictureBox1.Width, pictureBox1.Height);

                    }
                }
                if (e.KeyChar == 98)
                {
                    
                   
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                            if (sto.getIterator().selected)
                                sto.getIterator().Grow(1);
                    }
                }
                if (e.KeyChar == 118)
                {

                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                            sto.getIterator().Grow(-1);
                    }
                }
                if (e.KeyChar == 32)
                {
                   // if (sto.size() == 1 && (sto.getIterator().selected)) { sto.del(); }
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                            sto.delIterator();
                            
                    }
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        //if (sto.size() == 1 && sto.isChecked()) { sto.del(); break; }
                        if (sto.getIterator().selected)
                            sto.delIterator();

                    }
                    //sto.setCurPTR();
                }
                if (e.KeyChar == 110)
                {
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                        {
                            if (sto.getIterator() is Polygon) ((Polygon)sto.getIterator()).growN(1);
                            if (sto.getIterator() is Star) ((Star)sto.getIterator()).growN(1);
                        }
                    }
                }
                if (e.KeyChar == 109)
                {
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                        {
                            if (sto.getIterator() is Polygon) ((Polygon)sto.getIterator()).growN(-1);
                            if (sto.getIterator() is Star) ((Star)sto.getIterator()).growN(-1);
                        }
                    }
                }
                if (e.KeyChar == 46)
                {
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                        {
                            sto.getIterator().Rotate(2); 
                        }
                    }
                }
                if (e.KeyChar == 44)
                {
                    for (int i = 0; i < sto.size(); i++, sto.next())
                    {
                        if (sto.getIterator().selected)
                        {
                            sto.getIterator().Rotate(-2);
                        }
                    }
                }
                if (e.KeyChar == 107)
                {

                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < sto.size(); i++, sto.next())
                        {
                            {
                                    if (sto.getIterator().selected)
                                    {
                                        sto.getIterator().SetColor(colorDialog1.Color);
                                    }
                            }
                        }
                       
                    }
                       
                }
              
                    Random rnd = new Random();
                    int obj = rnd.Next(1, 3);
               if (e.KeyChar==49)
               {
                    for (int j = 0; j < sto.size(); j++, sto.next())
                    {
                        if (sto.getIterator().selected) { sto.getIterator().selected = false; }
                    }
                    int rad = rnd.Next(10, 100);
                        sto.add(new Circle(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width - 50, pictureBox1.Height - 50));
               }
                if (e.KeyChar == 51)
                {
                    for (int j = 0; j < sto.size(); j++, sto.next())
                    {
                        if (sto.getIterator().selected) { sto.getIterator().selected = false; }
                    }
                    int rad = rnd.Next(10, 100);
                        sto.add(new Polygon(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, rnd.Next(3, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width-50, pictureBox1.Height - 50));
                        ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                }
               if(e.KeyChar==50)
               {
                    for (int j = 0; j < sto.size(); j++, sto.next())
                    {
                        if (sto.getIterator().selected) { sto.getIterator().selected = false; }
                    }
                    int rad = rnd.Next(10, 100);
                        sto.add(new Star(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, rnd.Next(5, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width - 50, pictureBox1.Height - 50));
                        ((Star)sto.get()).Rotate(rnd.Next(0, 180));
               }
                
            }
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter stream = new StreamWriter(f);
                stream.WriteLine(sto.size());
                if (sto.size() != 0)
                {
                    sto.toFirst();
                    for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Save(stream);
                }
                stream.Close();
                f.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0)
            {
                SGroup group = new SGroup(pictureBox1.Width, pictureBox1.Height);
                sto.toFirst();
                int cnt = 0;
                for (int i = 0; i < sto.size(); i++, sto.next()) 
                    if (sto.getIterator().selected == true) cnt++;
                while (cnt != 0)
                {
                    if (sto.getIterator().selected == true)
                    {
                        group.Add(sto.getIterator());
                        sto.delIterator();
                        cnt--;
                    }
                    if (sto.size() != 0) sto.next();
                }
                sto.add(group);
            }
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (sto.size() != 0) sto.del();
            pictureBox1.Invalidate();
        }

     

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            bool isFinded = false;
            if (sto.size() != 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    if (sto.getIterator().Find(e.X, e.Y) == true && e.Button == MouseButtons.Left)
                    {
                        isFinded = true;
                        for (int j = 0; j < sto.size(); j++, sto.next())
                        {
                            if (sto.getIterator().selected) { sto.getIterator().selected = false; }
                        }
                        sto.getIterator().selected = true;
                        break;
                    }
                    if (sto.getIterator().Find(e.X, e.Y) == true && e.Button == MouseButtons.Right)
                    {
                        isFinded = true;
                        sto.getIterator().selected = true;
                        break;
                    }
                }
            }
            if (isFinded == false)
            {
                for (int j = 0; j < sto.size(); j++, sto.next())
                {
                    if (sto.getIterator().selected) { sto.getIterator().selected = false; }
                }
                if (radioButton3.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Circle(e.X, e.Y, rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                }
                else
                if (radioButton2.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Polygon(e.X, e.Y, rad, rnd.Next(3, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                    ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                }
                else
                if (radioButton1.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Star(e.X, e.Y, rad, rnd.Next(5, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                    ((Star)sto.get()).Rotate(rnd.Next(0, 180));
                }

            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sto.size() != 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    sto.getIterator().DrawObj(e.Graphics);
                    if (sto.getIterator().selected == true) sto.getIterator().DrawRectangle(e.Graphics, new Pen(Color.Gray, 2));
                }
               // sto.get().DrawRectangle(e.Graphics, new Pen(Color.Red, 1));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0 && sto.get() is SGroup)
            {
                while (((SGroup)sto.get()).size() != 0)
                {
                    sto.addAfter(((SGroup)sto.get()).Out());
                    sto.prevCur();
                }
                sto.del();
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader stream = new StreamReader(f);
                int i = Convert.ToInt32(stream.ReadLine());
                Factory shapeFactory = new ShapeFactory();  
                for (; i > 0; i--)
                {
                    string tmp = stream.ReadLine();
                    sto.add(shapeFactory.createShape(tmp));
                    sto.get().Load(stream, shapeFactory);
                }
                stream.Close();
                f.Close();
            }
            pictureBox1.Invalidate();
        }

       

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        
    }
}
public abstract class Shape  
{
    public string name;
    public bool selected = false;
    protected Rectangle rect;
    protected int x, y, width, height;
    abstract public void Resize(); 
    abstract public void SetXY(int _x, int _y); 
    abstract public void OffsetXY(int _x, int _y, int wight1, int height1);
    abstract public void SetColor(Color c);
    abstract public void Grow(int gr);
    abstract public void Rotate(int gr);
    abstract public void DrawObj(System.Drawing.Graphics e);
    abstract public void DrawRectangle(System.Drawing.Graphics e, Pen pen);
    abstract public bool Find(int _x, int _y);
    abstract public bool Find(Shape obj);
    abstract public void Clone(); 
    abstract public Rectangle GetRectangle();  
    abstract public void Save(StreamWriter stream);
    abstract public void Load(StreamReader stream, Factory factory);
    abstract public string GetInfo();
}

public abstract class Factory
{
    public abstract Shape createShape(string name);
}

public class ShapeFactory : Factory
{
    public override Shape createShape(string name)
    {
        Shape shape;
        switch (name)
        {
            case "Круг":
                shape = new Circle();
                break;
            case "Группа":
                shape = new SGroup();
                break;
            case "Многоугольник":
                shape = new Polygon();
                break;
            case "Звезда":
                shape = new Star();
                break;
            default:
                shape = null;
                break;
        }
        return shape;
    }
}


public class SGroup : Shape
{
    public Storage<Shape> sto;

    public SGroup()
    {
        sto = new Storage<Shape>();
        name = "Группа";
    }

    public SGroup(int Width, int Height)
    {
        width = Width;
        height = Height;
        sto = new Storage<Shape>();
        selected = true;
        name = "Группа";
    }

    public void Add(Shape s)
    {
        sto.add(s);
        if (sto.size() == 1) rect = new Rectangle(s.GetRectangle().X, s.GetRectangle().Y, s.GetRectangle().Width, s.GetRectangle().Height); 
        else
        {
            if (s.GetRectangle().Left < rect.Left)
            {
                int tmp = rect.Right;
                rect.X = s.GetRectangle().Left;
                rect.Width = tmp - rect.X;
            }
            if (s.GetRectangle().Right > rect.Right) rect.Width = s.GetRectangle().Right - rect.X;
            if (s.GetRectangle().Top < rect.Top)
            {
                int tmp = rect.Bottom;
                rect.Y = s.GetRectangle().Top;
                rect.Height = tmp - rect.Y;
            }
            if (s.GetRectangle().Bottom > rect.Bottom) rect.Height = s.GetRectangle().Bottom - rect.Y;
        }
    }

    public Shape Out()
    {
        if (sto.size() != 0)
        {
            Shape tmp = sto.get();
            sto.del();
            Resize();
            return tmp;
        }
        return null;
    }

    public int size()
    {
        return sto.size();
    }

    public override void Resize()
    {
        if (sto.size() != 0)
            {
                sto.toFirst();
                rect = sto.getIterator().GetRectangle();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    if (sto.getIterator().GetRectangle().Left < rect.Left)
                    {
                        int tmp = rect.Right;
                        rect.X = sto.getIterator().GetRectangle().Left;
                        rect.Width = tmp - rect.X;
                    }
                    if (sto.getIterator().GetRectangle().Right > rect.Right) rect.Width = sto.getIterator().GetRectangle().Right - rect.X;
                    if (sto.getIterator().GetRectangle().Top < rect.Top)
                    {
                        int tmp = rect.Bottom;
                        rect.Y = sto.getIterator().GetRectangle().Top;
                        rect.Height = tmp - rect.Y;
                    }
                    if (sto.getIterator().GetRectangle().Bottom > rect.Bottom) rect.Height = sto.getIterator().GetRectangle().Bottom - rect.Y;
                }
            }
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().DrawObj(e);
        }
    }

    public override void Grow(int gr)
    {
        if (sto.size() != 0)
        {
            if (gr > 0 && rect.X + gr > 1 && gr + rect.Right < width - 1 && rect.Y + gr > 1 && gr + rect.Bottom < height - 1)
            {
                rect.X -= gr;
                rect.Y -= gr;
                rect.Width += 2 * gr;
                rect.Height += 2 * gr;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Grow(gr);
            }
            if (gr < 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Grow(gr);
                if (gr < 0) Resize();
            }
        }
    }

    public override void OffsetXY(int _x, int _y, int wight1, int height1)
    {
        
        if (sto.size() != 0)
        {
            if (rect.X + _x > 0 && _x + rect.Right < wight1)
            {
                rect.X += _x;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().OffsetXY(_x, 0, wight1, height1);
            }
            if (rect.Y + _y > 0 && _y + rect.Bottom < height1)
            {
                rect.Y += _y;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().OffsetXY(0, _y, wight1, height1);
            }
        }
    }

    public override void SetColor(Color c)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().SetColor(c);
        }
    }

    public override void SetXY(int _x, int _y)
    {
        throw new NotImplementedException();
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Группа");
        stream.WriteLine(sto.size() + " " + width + " " + height);
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Save(stream);
        }
    }

    public override void Load(StreamReader stream, Factory factory)
    {
         
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int i = Convert.ToInt32(data[0]);
        width = Convert.ToInt32(data[1]);
        height = Convert.ToInt32(data[2]);
        for (; i > 0; i--)
        {
            Shape tmp = factory.createShape(stream.ReadLine());
            tmp.Load(stream, factory);
            Add(tmp);
        }
    }

    public override string GetInfo()
    {
        return name + "    Количество элементов : " + sto.size().ToString();
    }

    public override void Rotate(int gr)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Rotate(gr);
        }
    }

    public override bool Find(Shape obj)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) if (sto.getIterator().Find(obj) == true) return true;
        }
        return false;
    }
}

public class Circle: Shape
{
    protected int radius;
    protected Color col;
    public Circle()
    {
        x = 0;
        y = 0;
        radius = 0;
        name = "Круг";
    }
    public Circle(int x, int y, int r, Color c, int Width, int Height)
    {
        width = Width;
        height = Height;
        name = "Круг";
        this.x = x;
        this.y = y;
        col = c;
        if (r > x) r = x;
        if (x + r > width) r = width - x ;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        radius = r;
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
        selected = true;
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawEllipse(new Pen(Color.Black, 2), rect);
        e.FillEllipse(new SolidBrush(col), rect);
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override void OffsetXY(int _x, int _y, int wight1, int height1)
    {
        if (x + _x > radius && x + _x + radius < wight1) x += _x;
        if (y + _y > radius && y + _y + radius < height1) y += _y;
        Resize();
    }

    public override void Resize()
    {
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {
        throw new NotImplementedException();
    }

   public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override bool Find(int _x, int _y)
    {
        if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= radius * radius) return true; else return false;
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Круг");
        stream.WriteLine((rect.X + radius) + " " + (rect.Y + radius) + " " + radius + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void Load(StreamReader stream, Factory factory)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        col = Color.FromArgb(Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]));
        width = Convert.ToInt32(data[6]);
        height = Convert.ToInt32(data[7]);
        Resize();
    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Радиус: " + radius + " " + col.ToString();
    }

    public override void Rotate(int gr)
    {
        
    }

    public override bool Find(Shape obj)
    {
        string[] data = obj.GetInfo().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (data[0] != "Группа")
        {
            int _x = Convert.ToInt32(data[2]);
            int _y = Convert.ToInt32(data[4]);
            int _rad = Convert.ToInt32(data[6]);
            if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= Math.Pow(radius + _rad, 2)) return true;
        }
        else return obj.Find(this); 
        return false;
    }
}

public class Polygon : Circle
{
    private int n, rotate = 0;
    List<PointF> lst;
    public Polygon() : base()
    {
        name = "Многоугольник";
    }

    public Polygon(int x, int y, int r, int n, Color c, int Width, int Height) : base(x, y, r, c, Width, Height)
    {
        this.n = n;
        if (r > x) r = x;
        if (x + r > width) r = width - x;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        selected = true;
        Resize();
        name = "Многоугольник";
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawPolygon(new Pen(Color.Black, 2), lst.ToArray());
        e.FillPolygon(new SolidBrush(col), lst.ToArray());
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void Load(StreamReader stream, Factory factory)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        n = Convert.ToInt32(data[3]);
        rotate = Convert.ToInt32(data[4]);
        col = Color.FromArgb(Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
        width = Convert.ToInt32(data[8]);
        height = Convert.ToInt32(data[9]);
        Resize();
    }

    public override void OffsetXY(int _x, int _y, int wight1, int height1)
    {
        
        if (x + _x > radius && x + _x + radius < wight1) x += _x;
        if (y + _y > radius && y + _y + radius < height1) y += _y;
        Resize();
    }

    public override void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        for (int i = rotate; i < rotate + 360; i += 360 / n)
        {
            double radiani = (double)(i * 3.14) / 180;
            float xx = x + (int)(radius * Math.Cos(radiani));
            float yy = y + (int)(radius * Math.Sin(radiani));
            lst.Add(new PointF(xx, yy));
        }
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Многоугольник");
        stream.WriteLine(x + " " + y + " " + radius + " " + n + " " + rotate + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {

    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Радиус: " + radius + " Количество углов: " + n + " " + col.ToString();
    }

    public override void Rotate(int gr)
    {
        rotate += gr;
        Resize();
    }
    
    public void growN(int gr)
    {
        if (n + gr > 2) n += gr;
        Resize();
    }
}

public class Star: Circle
{
    private int n, rotate = 0;
    List<PointF> lst;
    public Star() : base()
    {
        name = "Звезда";
    }

    public Star(int x, int y, int r, int n, Color c, int Width, int Height) : base(x, y, r, c, Width, Height)
    {
        this.n = n;
        if (r > x) r = x;
        if (x + r > width) r = width - x;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        selected = true;
        Resize();
        name = "Звезда";
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawPolygon(new Pen(Color.Black, 2), lst.ToArray());
        e.FillPolygon(new SolidBrush(col), lst.ToArray());
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void Load(StreamReader stream, Factory factory)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        n = Convert.ToInt32(data[3]);
        rotate = Convert.ToInt32(data[4]);
        col = Color.FromArgb(Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
        width = Convert.ToInt32(data[8]);
        height = Convert.ToInt32(data[9]);
        Resize();
    }

    public override void Rotate(int gr)
    {
        rotate += gr;
        Resize();
    }

    public override void OffsetXY(int _x, int _y, int wight1, int height1)
    {
        
        if (x + _x > radius && x + _x + radius < wight1) x += _x;
        if (y + _y > radius && y + _y + radius < height1) y += _y;
        Resize();
    }

    public override void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        double a = rotate * Math.PI / 180, da = Math.PI / n, l;
        for (int k = 0; k < 2 * n + 1; k++)
        {
            l = k % 2 == 0 ? radius : radius / 2;
            lst.Add(new PointF((float)(x + l * Math.Cos(a)), (float)(y + l * Math.Sin(a))));
            a += da;
        }
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Звезда");
        stream.WriteLine(x + " " + y + " " + radius + " " + n + " " + rotate + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {

    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Радиус: " + radius + " Количество углов: " + n + " " + col.ToString();
    }

    public void growN(int gr)
    {
        if (n + gr > 3) n += gr;
        Resize();
    }
}

/*class DPanel : Panel
{
    public DPanel()
    {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
    }
}*/


public class Storage<T> 
{
    public class list
    {
        public T data { get; set; }
        public list right { get; set; }
        public list left { get; set; }

        public bool isChecked = false;
    };
    private list first;
    private list last;
    private list current;
    private list iterator;

    private int rate;
    public Storage()
    {
        first = null;
        rate = 0;
    }
    public void add(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = last;
            last.right = tmp;
            last = tmp;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
        }
        last.right = first; 
        current = tmp;
        first.left = last;
        rate++;
    }
    public void addBefore(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = (current.left);
            (current.left).right = tmp;
            current.left = tmp;
            tmp.right = current;
            if (current == first) first = current.left;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
            first.right = first;
            first.left = first;
        }
        current = tmp;
        rate++;
    }
    public void addAfter(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = current;
            tmp.right = current.right;
            (current.right).left = tmp;
            current.right = tmp;
            if (current == last) last = current.right;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
            first.right = first;
            first.left = first;
        }
        current = tmp;
        rate++;
    }
    public void toFirst()
    {
        iterator = first;
    }
    public void toLast()
    {
        iterator = last;
    }
    public void next()
    {
        iterator = iterator.right;
    }
    public void prev()
    {
        iterator = iterator.left;
    }
    public void nextCur()
    {
        current = current.right;

    }
    public void prevCur()
    {
        current = current.left;

    }
    public void del()
    {
        if (rate == 1)
        {
            first = null;
            last = null;
            current = null;
        }
        else
        {
            (current.left).right = current.right;
            (current.right).left = current.left;
            list tmp = current;
            if (current == last)
            {
                current = current.left;
                last = current;
            }
            else
            {
                if (current == first) first = current.right;
                current = current.right;
            }
        }
        rate--;
    }
    public void delIterator()
    {
        if (rate == 1)
        {
            first = null;
            last = null;
            iterator = null;
        }
        else
        {
            (iterator.left).right = iterator.right;
            (iterator.right).left = iterator.left;
            if (iterator == last)
            {
                iterator = iterator.left;
                last = iterator;
            }
            else
            {
                if (iterator == first) first = iterator.right;
                iterator = iterator.left;
            }
        }
        rate--;
    }
    public void delIterator1()
    {
        if (rate == 1)
        {
            first = null;
            last = null;
            iterator = null;
        }
        else
        {
            (iterator.left).right = iterator.right;
            (iterator.right).left = iterator.left;
            if (iterator == last)
            {
                iterator = iterator.left;
                last = iterator;
            }
            else
            {
                if (iterator == first) first = iterator.right;
                iterator = iterator.left;
            }
        }
        rate--;
    }
    public int size()
    {
        return rate;
    }
    public list getIteratorPTR()
    {
        return iterator;
    }
    public list getCurPTR()
    {
        return current;
    }
    public void setCurPTR()
    {
        current = iterator;
    }
    public bool isChecked()
    {
        if (iterator.isChecked == true) return true; else return false;
    }
    public void check()
    {
        iterator.isChecked = !iterator.isChecked;
    }
    public T getIterator()
    {
        return (iterator.data);
    }
    public T get()
    {
        return (current.data);
    }
};
