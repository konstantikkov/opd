using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPD_konstantinov {

    public class CountDown {
        public delegate void EventCallback(string message);

        Dictionary<string, EventCallback> events;
        int delay = 1000;
        public CountDown() {
            events = new Dictionary<string, EventCallback>();
        }
        public void AddEvent(string name, EventCallback callback) {
            events.Add(name, callback );
        }

        public void RemoveEvent(string name) {
            events.Remove(name);
        }

        public void Skip(int ms, string message) {
            Thread.Sleep(delay);
            foreach (var eventCallback in events) {
                eventCallback.Value(message);
            }
        }
    }

    public class Subscriber {
        public Subscriber(CountDown cd, string name) {
            SubscribeName = name;
            CdObject = cd;
            cd.AddEvent(name, (message) => Display(message));
        }

        public void Ubsubscribe() { 
            CdObject.RemoveEvent(SubscribeName);
        }

        private void Display(string eventText) {
            Console.WriteLine("Event: {0} \n Subscriber: {1}", eventText, SubscribeName);
        }
        private CountDown CdObject;
        private string SubscribeName;
    }
}
