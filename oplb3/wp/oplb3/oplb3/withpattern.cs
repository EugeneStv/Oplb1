using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplb3
{

    public class CommandHistory
    {
        private List<ICommand> excommands = new List<ICommand>();
        private List<ICommand> undocommands = new List<ICommand>();

        public void Execute(ICommand command)
        {
            command.Execute();
            excommands.Add(command);
            undocommands.Clear();
        }

        public void Undo()
        {
            if (excommands.Count > 0)
            {
                var command = excommands[excommands.Count - 1];
                command.Undo();
                excommands.RemoveAt(excommands.Count - 1);
                undocommands.Add(command);
            }
        }

        public void Redo()
        {
            if (undocommands.Count > 0)
            {
                var command = undocommands[undocommands.Count - 1];
                command.Execute();
                undocommands.RemoveAt(undocommands.Count - 1);
                excommands.Add(command);
            }
        }

        public bool CanUndo => excommands.Count > 0;
        public bool CanRedo => undocommands.Count > 0;
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class DrawLineCommand : ICommand
    {
        private Canvas canvas;
        private Pen pen;
        private List<Point> points;
        private Bitmap backup;

        public DrawLineCommand(Canvas canvas, Pen pen, List<Point> points)
        {
            this.canvas = canvas;
            this.pen = new Pen(pen.Color, pen.Width);
            this.points = new List<Point>(points);
            backup = (Bitmap)canvas.GetBitmap().Clone();
        }

        public void Execute()
        {
            canvas.DrawLine(pen, points);
        }

        public void Undo()
        {
            canvas.Restore(backup);
        }
    }


    public class ClearCanvasCommand : ICommand
    {
        private Canvas canvas;
        private Bitmap backup;

        public ClearCanvasCommand(Canvas canvas)
        {
            this.canvas = canvas;
            backup = (Bitmap)canvas.GetBitmap().Clone();
        }

        public void Execute()
        {
            canvas.Clear();
        }

        public void Undo()
        {
            canvas.Restore(backup);
        }
    }

}

