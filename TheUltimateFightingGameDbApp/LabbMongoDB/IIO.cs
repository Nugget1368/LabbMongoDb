namespace LabbMongoDB
{
    interface IIO
    {
        void ClearWindow();
        void Exit();
        string GetInput();
        int GetNumInput();
        void Output(string output);
        void ErrorOutput(string output);
        void SuccessfulOutput(string output);
        void HeaderOutput(string output);
        void ReturnOutput();
        void ContinueOutput();



    }
}
