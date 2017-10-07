using System;
using System.Collections.Generic;
using System.Linq;

namespace Chaso.Push.Client
{
    public class ChasoPushClient : IChasoPushClient
    {
        internal class PushNotify : PushClient
        {
            protected PushNotify(Uri uri) : base(uri)
            {

            }
            private static PushNotify pushNotify;
            public static PushNotify GetInstance(string url) { return pushNotify ?? (pushNotify = new PushNotify(new Uri(url))); }
        }


        PushNotify PushNotifyIntance;
        private Dictionary<Models.Notify, List<KeyValuePair<int, object>>> _itemsToPush;
        public ChasoPushClient(string url)
        {
            _itemsToPush = new Dictionary<Models.Notify, List<KeyValuePair<int, object>>>();
            PushNotifyIntance = PushNotify.GetInstance(url);
        }
        public void Add(string channelName, string eventName)
        {
            Add(channelName, eventName, new KeyValuePair<int, object>(0, new { }));
        }
        public void Add(string channelName, string eventName, int key, object value)
        {
            Add(channelName, eventName, new KeyValuePair<int, object>(key, value));
        }
        private void Add(string channelName, string eventName, KeyValuePair<int, object> keyValuePair)
        {
            if (!_itemsToPush.Any(l => l.Key.Channel == channelName && l.Key.EventName == eventName))
                _itemsToPush.Add(new Models.Notify(channelName, eventName), new List<KeyValuePair<int, object>>());
            var key = _itemsToPush.First(l => l.Key.Channel == channelName && l.Key.EventName == eventName);
            if (!key.Value.Any(l => l.Key == keyValuePair.Key))
                key.Value.Add(keyValuePair);
        }
        public void Clear()
        {
            _itemsToPush.Clear();
        }
        public IEnumerable<string> Send()
        {
            var alerts = new List<string>();

            foreach (var item in _itemsToPush)
            {
                foreach (var value in item.Value)
                    alerts.Add(SendNotify(item.Key.Channel, item.Key.EventName, Newtonsoft.Json.JsonConvert.SerializeObject(value.Value)));
            }
            _itemsToPush.Clear();
            return alerts;
        }
        public string Send(string channel, string eventName, object data = null)
        {
            return SendNotify(channel, eventName, data);
        }
        private string SendNotify(string channel, string eventName, object data)
        {
            var result = PushNotifyIntance.PushOperations.NotifyWithHttpMessagesAsync(new Models.Notify(channel, eventName, data)).Result;
            return string.Format("{0}. {1}", result.Body.ToString(), result.Response.ReasonPhrase);
        }

        private bool disposing = false;

        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool dispose)
        {
            if (disposing) return;
            if (dispose)
            {
                disposing = true;
                PushNotifyIntance?.Dispose();
            }
        }
    }
}
