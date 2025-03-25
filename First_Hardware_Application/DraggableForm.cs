using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Hardware_Application
{
    public static class DraggableForm
    {
        public static void EnableDrag(Control control)
        {
            bool dragging = false;
            Point dragCursorPoint = Point.Empty; // Инициализация
            Point dragFormPoint = Point.Empty;  // Инициализация

            control.MouseDown += (sender, e) =>
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = control.FindForm().Location; // Текущая позиция формы
            };

            control.MouseMove += (sender, e) =>
            {
                if (dragging)
                {
                    Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    control.FindForm().Location = Point.Add(dragFormPoint, new Size(dif));
                }
            };

            control.MouseUp += (sender, e) =>
            {
                dragging = false;
            };
        }
    }
}
