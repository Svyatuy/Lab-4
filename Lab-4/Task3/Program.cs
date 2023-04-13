using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            EventBus eventBus = new EventBus(5, 1000, 5000, 1.5);
            Publisher publisher = new Publisher(eventBus);

            PrioritySubscriber sub1 = new PrioritySubscriber(1);
            PrioritySubscriber sub2 = new PrioritySubscriber(2);
            PrioritySubscriber sub3 = new PrioritySubscriber(3);

            eventBus.Register("OddEvent", sub1.Priority, new Action<object, EventArgs>(sub1.HandleEvent));
            eventBus.Register("EvenEvent", sub2.Priority, new Action<object, EventArgs>(sub2.HandleEvent));
            eventBus.Register("OddEvent", sub3.Priority, new Action<object, EventArgs>(sub3.HandleEvent));


            publisher.SendEvent();

            Console.ReadLine();
        }
    }
}