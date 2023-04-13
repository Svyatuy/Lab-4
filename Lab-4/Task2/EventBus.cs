using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class EventBus
    {
        private Dictionary<string, Dictionary<int, List<Delegate>>> eventHandlers = new Dictionary<string, Dictionary<int, List<Delegate>>>();
        private Dictionary<string, DateTime> lastEventTime = new Dictionary<string, DateTime>();
        private int throttlingTime;

        public EventBus(int throtTime)
        {
            throttlingTime = throtTime;
        }

        public void Register(string eventName, int priority, Delegate eventHandler)
        {
            if (!eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = new Dictionary<int, List<Delegate>>();
            }
            if (!eventHandlers[eventName].ContainsKey(priority))
            {
                eventHandlers[eventName][priority] = new List<Delegate>();
            }
            eventHandlers[eventName][priority].Add(eventHandler);
        }

        public void Unregister(string eventName, int priority, Delegate eventHandler)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                if (eventHandlers[eventName].ContainsKey(priority))
                {
                    eventHandlers[eventName][priority].Remove(eventHandler);
                }
            }
        }

        public void Send(string eventName, object sender, EventArgs args)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                DateTime minEventTime;
                if (!lastEventTime.TryGetValue(eventName, out minEventTime) || (DateTime.Now - minEventTime).TotalMilliseconds >= throttlingTime)
                {
                    lastEventTime[eventName] = DateTime.Now;
                    foreach (int priority in eventHandlers[eventName].Keys)
                    {
                        foreach (Delegate eventHandler in eventHandlers[eventName][priority])
                        {
                            eventHandler.DynamicInvoke(sender, args);
                        }
                    }
                }
            }
        }
    }
}
