// avraham michaeli - 203835749 //
// nadav- benassor - 301785663 //

using GraphicsEx2.Exceptions;
using GraphicsEx2.Shapes;
using GraphicsEx2.Transformations;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace GraphicsEx2
{
    // defines all the program elements //
    public partial class Form1 : Form
    {
        private FileContentAndPath fc;
        private Graphics graphics;
        private Translation translation = new Translation();
        private Mirror mirror = new Mirror();
        private Rotation rotation = new Rotation();
        private Scaling scaling = new Scaling();
        private Shearing shearing = new Shearing();
        private int panelHeight, panelWidth;


        // define the height and width of the panel //
        public Form1()
        {
            InitializeComponent();
            panelHeight = panel1.Height;
            panelWidth = panel1.Width;
        }


        // load the file contact and drawing the shapes //
        // if there is not 16 graphic elements or there is not at least one line circle or bezier curve in the data of the file//
        // an exception will be appering in the screen //
        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                graphics = panel1.CreateGraphics();
                fc = Utils.LoadFile();
                tbPath.Text = fc.Path;
                Utils.Draw(fc, graphics, panelHeight, panelWidth);
            }

            // the exception showing in screen //

            catch (NotEnoughElementsExecption ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NotAllShapesExistException nel)
            {
                MessageBox.Show(nel.Message);
            }

        }


        // the translation transformation - the up button on screen //
        #region traslation
        private void Up_Btn(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            translation.Translate(0, (int.Parse(tyTb.Text) * (-1)), fc);
            Init();
        }

        // down button in translation transformation on screen //
        private void Down_Btn(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            translation.Translate(0, int.Parse(tyTb.Text), fc);
            Init();
        }

        // right button in the translation button //
        private void Right_Btn(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            translation.Translate(int.Parse(tyTb.Text), 0, fc);
            Init();
        }
        // left button on screen //
        private void Left_Btn(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            translation.Translate(int.Parse(tyTb.Text) * (-1), 0, fc);
            Init();
        }
        #endregion

        // mirror translation //
        // mirror by x - the button on screen  //
        #region mirror
        private void By_x(object sender, EventArgs e)
        {
            mirror.MirrorByX(fc);
            Init();
        }

        // miroor by y - button on screen //
        private void By_y(object sender, EventArgs e)
        {
            mirror.MirrorByY(fc);
            Init();
        }
        // mirror by axis origin - the button on screen //
        private void Axis(object sender, EventArgs e)
        {
            mirror.MirrorByAxis(fc);
            Init();
        }
        #endregion


        // rotation function - button on screen //
        #region rotate
        private void Rotate_Click(object sender, EventArgs e)
        {
            // the defult parameters are angle = 3 , x = 0 , y = 0 //
            rotation.Rotate(fc, float.Parse(tbAngle.Text), new MyPoint() { X = float.Parse(tbX.Text), Y = float.Parse(tbY.Text) });
            
            Init();
        }
        #endregion

        // scale translation //
        #region scale
        private void ScaleBtn(object sender, EventArgs e)
        {
            // the defult parameters are - sx = 1.1 , sy = 1.1 , x = 0 , y = 0 //
            scaling.Scale(fc, float.Parse(Sx.Text), float.Parse(Sy.Text), new MyPoint() { X = float.Parse(XScale.Text), Y = float.Parse(YScale.Text) });
            Init();
        }
        #endregion

        private void Init()
        {

            //  this.Invalidate();  // request a delayed Repaint by the normal MessageLoop system    
            // this.Update();      // forces Repaint of invalidated area 
            this.Refresh();     // Combines Invalidate() and Update()
            Utils.Draw(fc, graphics, panelHeight, panelWidth);
        }


        // clear buuton //
        private void ClearBtn(object sender, EventArgs e)
        {
            this.Refresh();
        }

        // declare that the mouse was pressed for the shearing function //
        bool _mousePressed;
        // when you pressed on the mouse and you want to activate the functions //
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _mousePressed = true;
        }

        // define the variables for the shearing transformation //
        int oldVal;
        bool once = false;
        bool onceY = false;
        int oldValY;

        // when you drag the mouse left an right and it activates the axis x  shearing actuality //
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // when you press the mouse button , the mouse was pressed on the " enable shearing" transformation and you choosed shearing by axis x "//
            if (_mousePressed && rbShear.Checked && rbByX.Checked)
            {
                // from lines 178-194 recognize if the hraphic object will move left or right //
                if (!once)
                {
                    oldVal = e.X;
                    once = true;
                }
                float a = 1.000000001f;
                if (oldVal > e.X)
                {
                    if (a > 0)
                        a *= (-1);
                }
                else
                {
                    if (a < 0)
                        a *= (-1);
                }
                oldVal = e.X;
                
                // activate the shearing function by axis x //
                shearing.SheareByX(fc, a);

                // clear the previes graphic object on the screen //
                this.Refresh();
                // draw the new graphic object with after the shearing is activated//
                Utils.Draw(fc, graphics, panelHeight, panelWidth);
            }

            // when you press the mouse button , the mouse was pressed on the " enable shearing" transformation and you choosed shearing by axis y "//
            else if (_mousePressed && rbShear.Checked && rbByY.Checked)
            {
                // 209- 225 recognize if the graphic object need to move up or down //
                if (!onceY)
                {
                    oldValY = e.Y;
                    onceY = true;
                }
                float b = 1.000000001f;
                if (oldValY > e.Y)
                {
                    if (b > 0)
                        b *= (-1);
                }
                else
                {
                    if (b < 0)
                        b *= (-1);
                }
                oldValY = e.Y;
                
                // activate shearing by y //
                shearing.SheareByY(fc, b);

                // clear the screen from the previes graphic object //
                this.Refresh();
                // draw the new object after the shearing was done //
                Utils.Draw(fc, graphics, panelHeight, panelWidth);
            }
        }

        // the mouse press stoppet //
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _mousePressed = false;
        }

        // the exception in thr translation transformation about the values input //
        bool ValidateInput()
        {
            try
            {
                bool parsed = int.TryParse(txTb.Text, out int p);
                if (!parsed)
                    throw new InvalidArgumentException("ERROR: Tx must be numaric");
                if (p < 0)
                    throw new InvalidArgumentException("ERROR: Tx cannot be negative");
                if (p > 400)
                    throw new InvalidArgumentException("ERROR: Tx must be less then 400");

                parsed = int.TryParse(tyTb.Text, out int p2);
                if (!parsed)
                    throw new InvalidArgumentException("ERROR: Ty must be numaric");
                if (p2 < 0)
                    throw new InvalidArgumentException("ERROR: Ty cannot be negative");
                if (p2 > 400)
                    throw new InvalidArgumentException("ERROR: Ty must be less then 400");
            }
            // the messeage that is shown //
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // as a defult the x shearing option will be chosen //
        private void RbShear_CheckedChanged(object sender, EventArgs e)
        {
            rbByX.Checked = true;
        }

        // makes sure that the input is only numbers //
        private void Key_Press_DIgits(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
