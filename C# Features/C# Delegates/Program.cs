using System;

namespace C__Delegates
{
    public delegate void SimpleDelegate();
    public delegate void SimpleDelegate2(string message);
    class Program
    {
        public static void MyFunc()
        {
            Console.WriteLine("I was called by delegate.");
        }

        public static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public static void Caller(SimpleDelegate2 function)
        {
            if (function != null)
            {
                function("Hello from the delegate!");
                Console.WriteLine($"Method represented by this delegate: {function.Method}");
            }
            else
            {
                Console.WriteLine("The delegate function was null.");
            }
        }

        public static string Messenger(string message)
        {
            return ($"{message} Always keep it {100}");
        }

        static void Main(string[] args)
        {
            // Instantiation.
            // Create an instance similar to class instantiation and pass in the function
            // that you want that delegate to reference.
            SimpleDelegate simpleDelegate = new SimpleDelegate(MyFunc);
            SimpleDelegate2 messageFunc = new SimpleDelegate2(Message);

            // Invocation of the delegate;
            simpleDelegate();

            // Invocation of the function that takes delegate as an argument.
            Caller(messageFunc);

            // Create new object of type SampleTest that will utilize its
            // internal delegate declarations.
            SampleTest myObj = new SampleTest();

            // Pass the Messenger function from the Program class
            // as a parameter for the delegate parameter used in the Process method.
            myObj.Process(Messenger);
        }
    }

    public class SampleTest
    {
        public delegate void SampleTestDelegate1();
        public delegate string MessengerProcessor(string message);
    
        public void Process(MessengerProcessor messengerProcessor)
        {
            if (messengerProcessor != null)
            {
                string receivedMsg = messengerProcessor("Hello from MessengerProcessor.");
                Console.WriteLine(receivedMsg);
            }
            else
                Console.WriteLine("Process(): parameter was null.");
        }
    }
}
