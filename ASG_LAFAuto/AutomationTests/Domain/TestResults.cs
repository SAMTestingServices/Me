namespace Engine.TestEngine
{
    public class TestResults
    {
        public int totalNumberOfTests;
        public int numberFailures;
        public int numberSuccesses;
       
        public string totalExecutionTime;


        public TestResults(int totalNumberOfTests,int numberFailures,int numberSuccesses, string totalExecutionTime)
        {
            this.totalNumberOfTests = totalNumberOfTests;
            this.numberFailures = numberFailures;
            this.numberSuccesses = numberSuccesses;
            this.totalExecutionTime = totalExecutionTime;
        }
    }
}