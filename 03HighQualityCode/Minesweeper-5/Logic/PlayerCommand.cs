namespace Minesweeper.Logic
{
    using System;

    /// <summary>
    ///     Wraps player command as object.
    ///     Evaluate command
    ///     Represent command design pattern
    /// </summary>
    public class PlayerCommand
    {
        public static readonly string ReturnKey = "x";
        private const string WRONG_INPUT_MESSAGE = "Wrong input row/col on the field!";
        private readonly string[] commands;
        
        /// <summary>
        /// Create object of type PlayerCommand
        /// </summary>
        /// <param name="command">User input as string</param>
        public PlayerCommand(string command)
        {
            if (string.IsNullOrEmpty(command) || command.Trim().ToLower() == ReturnKey)
            {
                this.IsReturnKey = true;
            }
            else
            {
                this.commands = command.Trim().ToUpper().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                this.EvaluateCommand();
            }
        }

        public bool IsReturnKey { get; private set; }

        public bool IsBadInput { get; private set; }

        public string Message { get; private set; }

        public int Row { get; private set; }

        public int Col { get; private set; }

        private void EvaluateCommand()
        {
            var isCommandLengthOk = this.commands.Length >= 2;
            int row, col;

            if (isCommandLengthOk &&
                int.TryParse(this.commands[0], out row) && 
                int.TryParse(this.commands[1], out col))
            {
                this.Row = row;
                this.Col = col;
                this.IsReturnKey = false;
                this.IsBadInput = false;
            }
            else
            {
                this.IsBadInput = true;
                this.Message = WRONG_INPUT_MESSAGE;
            }
        }
    }
}