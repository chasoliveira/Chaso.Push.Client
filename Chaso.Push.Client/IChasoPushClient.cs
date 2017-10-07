using System;
using System.Collections.Generic;

namespace Chaso.Push.Client
{
    public interface IChasoPushClient: IDisposable
    {
        void Add(string channelName, string eventName);
        void Add(string channelName, string eventName, int key, object value);
        void Clear();
        IEnumerable<string> Send();
        string Send(string channel, string eventName, object data = null);
    }
}