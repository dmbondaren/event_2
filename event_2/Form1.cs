using System;
using System.Drawing;
using System.Windows.Forms;

namespace event_2
{
    public partial class Form1 : Form
    {
        public static int eCount = 0;
        private Point originalLabelPosition; // Початкові координати label1
        public Form1()
        {
            InitializeComponent();
        }

        // Метод для перемещения вниз
        public void MoveDown(object sender, EventArgs e)
        {
            Control C = (Control)sender;
            C.Top += 10;
        }
        public void MoveUp(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Top -= 10;
        }

        // Метод для перемещения кнопки по наведению курсора


        private void button2_Click(object sender, EventArgs e)
        {
            // Перемещаем метку вверх
            MoveUp(label1, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Перемещаем метку вниз
            MoveDown(label1, e);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Виводимо місцезнаходження label1
            label1.Text = $"X: {label1.Location.X}, Y: {label1.Location.Y}";
        }

        // Метод для переміщення елемента до місця натискання мишею на формі
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Виводимо позицію миші в label1
            label1.Text = $"X: {e.X}, Y: {e.Y}";
        }


        // Метод для переміщення елемента до місця натискання мишею на формі
        private void MoveToMouse(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Location = this.PointToClient(Control.MousePosition);
        }
        // Метод для переміщення label1 до місця натискання мишею на формі
        private void MoveToMouse(object sender, MouseEventArgs e)
        {
            // Переміщаємо тільки label1
            if (sender is Label && ((Label)sender).Name == "label1")
            {
                Label label = (Label)sender;
                label.Location = this.PointToClient(Control.MousePosition);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                // Підписуємо label1 на подію руху миші на формі
                label1.MouseMove += MoveToMouse;
                // Підписуємо форму на подію руху миші на формі
                this.MouseMove += MoveToMouse;
                // Підписуємо кнопку2 на подію руху миші на формі
                button2.MouseMove += MoveToMouse;

                button1.Text = "Stop"; // Змінюємо текст кнопки на Stop
            }
            else
            {
                // Відписуємо label1 від події руху миші на формі
                label1.MouseMove -= MoveToMouse;
                // Відписуємо форму від події руху миші на формі
                this.MouseMove -= MoveToMouse;
                // Відписуємо кнопку2 від події руху миші на формі
                button2.MouseMove -= MoveToMouse;

                button1.Text = "Start"; // Змінюємо текст кнопки на Start
            }
        }




    }
}

