using System;
using System.Linq;
using System.Linq.Expressions;
using SignalR.Hosting.AspNet;
using SignalR.Hubs;
using SignalR.Infrastructure;

namespace SignalR.RxExtensions
{
    public class Clientside<T>
    {
        private readonly IObservable<T> _observable;

        internal Clientside(IObservable<T> observable)
        {
            _observable = observable;
        }

        public IDisposable Observable<THub>(Expression<Func<THub, dynamic>> expression) where THub : Hub, new()
        {
            var connectionManager = AspNetHost.DependencyResolver.Resolve<IConnectionManager>();
            dynamic clients = connectionManager.GetClients<THub>();

            Func<string, string> camelCase = value => String.Join(".", value.Split('.').Select(n => Char.ToLower(n[0]) + n.Substring(1)));

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("'expression' should be a member expression");
            }

            return _observable.Subscribe(
                x => clients.Invoke(camelCase(memberExpression.Member.Name) + "OnNext", x),
                x => clients.Invoke(camelCase(memberExpression.Member.Name) + "OnError", x),
                () => clients.Invoke(camelCase(memberExpression.Member.Name) + "OnCompleted")
                );
        }
    }

    public static class SignalRObservableExtensions
    {
        public static Clientside<T> ToClientside<T>(this IObservable<T> observable)
        {
            return new Clientside<T>(observable);
        }
    }
}