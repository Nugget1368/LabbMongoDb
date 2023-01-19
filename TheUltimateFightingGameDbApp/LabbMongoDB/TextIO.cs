namespace LabbMongoDB
{
    internal class TextIO : IIO
    {
        

        public void ClearWindow()
        {
            Console.Clear();
        }

        public void Exit()
        {
            FancyText("Exited the application....\n");
            Environment.Exit(0);
        }
        public string GetInput()
        {
            Output("\ntext> ");
            return Console.ReadLine();
        }
        public int GetNumInput()
        {
            bool success = false;
            int input = 0;
            while (!(success))
            {
                Output("\nnumber> ");
                success = int.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        public void Output(string output)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            FancyText(output);
            //Console.ForegroundColor = ConsoleColor.White;
        }
        public void SuccessfulOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            FancyText(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ErrorOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            FancyText(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void HeaderOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            FancyText(output);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReturnOutput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            FancyText("Returning to main window.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ContinueOutput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            FancyText("Press any key to continue....\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void FancyText(string text)
        {
            int speed = 30;
            for(int x = 0; x < text.Length; x++)
            {
                Console.Write(text[x]);
                Thread.Sleep(speed);
            }
        }
    }
}
