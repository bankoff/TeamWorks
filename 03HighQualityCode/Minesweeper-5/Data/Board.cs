namespace Minesweeper.Data
{
    using System;

    using Minesweeper.Enums;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Represent playing field populated with mines
    /// </summary>
    public class Board : IBoard, IAcceptable
    {
        private int rows;
        private int columns;
        private int minesCount;
        private Field[,] fieldsMatrix;

        public Board(int rows, int columns, int minesCount)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.MinesCount = minesCount;
            this.FieldsMatrix = new Field[rows, columns];

            this.FieldsMatrix = PrepareMatrix(this.rows, this.columns);
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot be less than zero.");
                }

                this.rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return this.columns;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Columns cannot be less than zero.");
                }

                this.columns = value;
            }
        }

        public int MinesCount
        {
            get
            {
                return this.minesCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("There should be positive number of mines in the game.");
                }

                this.minesCount = value;
            }
        }

        public Field[,] FieldsMatrix
        {
            get 
            {
                return (Field[,])this.fieldsMatrix.Clone();
            }

            private set
            {
                this.fieldsMatrix = value;
            }
        }

        public Field this[int row, int col]
        {
            get
            {
                if (!this.IsPositionValid(row, col))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return this.fieldsMatrix[row, col];
            }

            set
            {
                if (!this.IsPositionValid(row, col))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                this.fieldsMatrix[row, col] = value;
            }
        }        

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private static Field[,] PrepareMatrix(int rows, int cols)
        {
            var fieldMatrix = new Field[rows, cols];
            var field = new Field(0, FieldStatus.Closed);

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    fieldMatrix[row, col] = field.Clone() as Field;
                }
            }

            return fieldMatrix;
        }

        private bool IsPositionValid(int row, int col)
        {
            if ((row < 0 || row >= this.fieldsMatrix.GetLength(0)) || (col < 0 || col >= this.fieldsMatrix.GetLength(1)))
            {
                return false;
            }

            return true;
        }
    }
}
