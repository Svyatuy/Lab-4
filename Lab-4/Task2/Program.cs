using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventBus eventBus = new EventBus(2000);
            PrioritySubscriber sub1 = new PrioritySubscriber(1);
            PrioritySubscriber sub2 = new PrioritySubscriber(2);
            PrioritySubscriber sub3 = new PrioritySubscriber(3);
            PrioritySubscriber sub4 = new PrioritySubscriber(4);
            eventBus.Register("EvenEvent", 1, new EventHandler(sub1.HandleEvent));
            eventBus.Register("EvenEvent", 2, new EventHandler(sub2.HandleEvent));
            eventBus.Register("OddEvent", 3, new EventHandler(sub3.HandleEvent));
            eventBus.Register("OddEvent", 4, new EventHandler(sub4.HandleEvent));
            Publisher publisher = new Publisher(eventBus);
            publisher.SendEvent();
        }
    }
}