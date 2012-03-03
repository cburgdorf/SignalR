using System;
using SignalR.Hubs;

namespace SignalR.RxExtensions.Demo.Models
{
    //Don't change anything here! The proxy generation is hard coded
    //at the moment

    public class RxHub : Hub
    {
        public void Dummy()
        {
            //we need a dummy method in order to force the ProxyGenerator
            //to create code for this hub
        }

        //This is our observable that we want to be available on the
        //client. In a future version the proxy generator will
        //take care of creating a Rx Subject on the client side for us
        //(hard coded at the moment)

        public IObservable<int> SomeValue { get; set; }
    }
}