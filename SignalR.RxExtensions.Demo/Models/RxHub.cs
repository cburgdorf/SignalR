using System;
using SignalR.Hubs;

namespace Mvc3SignalR.Models
{
    public class RxHub : Hub
    {
        public void Dummy()
        {
            //we need a dummy method in order to force the ProxyGenerator
            //to create code for this hub
        }

        public IObservable<int> SomeValue { get; set; }
    }
}