namespace NewOCPConcept
{
    public interface IHellowWorld
    {
        public void SayHellow(string text);
    }

    public class HellowWorld : IHellowWorld
    {
        public void SayHellow(string text)
        {
            Console.WriteLine(text);
        }
    }
}
