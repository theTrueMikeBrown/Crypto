using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crypto
{
    public class ValueGetter
    {
        public IEnumerable<Tuple<string, decimal, decimal, decimal>> GetValues()
        {
            IRestClient client = new RestClient("https://min-api.cryptocompare.com/data/");
            Values historical = GetHistorical(client);
            Values current = GetCurrent(client);

            List<Tuple<string, decimal, decimal, decimal>> values = new List<Tuple<string, decimal, decimal, decimal>>();
            values.Add(new Tuple<string, decimal, decimal, decimal>("btc", 1 / current.BTC, 1 / historical.BTC, 100 - (current.BTC / historical.BTC * 100)));
            values.Add(new Tuple<string, decimal, decimal, decimal>("bch", 1 / current.BCH, 1 / historical.BCH, 100 - (current.BCH / historical.BCH * 100)));
            values.Add(new Tuple<string, decimal, decimal, decimal>("doge", 1 / current.DOGE, 1 / historical.DOGE, 100 - (current.DOGE / historical.DOGE * 100)));
            values.Add(new Tuple<string, decimal, decimal, decimal>("ltc", 1 / current.LTC, 1 / historical.LTC, 100 - (current.LTC / historical.LTC * 100)));
            values.Add(new Tuple<string, decimal, decimal, decimal>("dash", 1 / current.DASH, 1 / historical.DASH, 100 - (current.DASH / historical.DASH * 100)));

            var sorted = values.OrderBy((v) => v.Item4);
            return sorted;
        }

        private static Values GetCurrent(IRestClient client)
        {
            IRestRequest currentRequest = new RestRequest("price", Method.GET);
            currentRequest.AddParameter("fsym", "USD", ParameterType.QueryString);
            currentRequest.AddParameter("tsyms", "BTC,BCH,DOGE,LTC,DASH", ParameterType.QueryString);
            var current = client.Get<Values>(currentRequest).Data;
            return current;
        }

        private static Values GetHistorical(IRestClient client)
        {
            int unixTimestamp = (int)(DateTime.UtcNow.AddDays(-1).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            IRestRequest historicalRequest = new RestRequest("pricehistorical", Method.GET);
            historicalRequest.AddParameter("fsym", "USD", ParameterType.QueryString);
            historicalRequest.AddParameter("tsyms", "BTC,BCH,DOGE,LTC,DASH", ParameterType.QueryString);
            historicalRequest.AddParameter("ts", unixTimestamp, ParameterType.QueryString);
            var historical = client.Get<HistoricalData>(historicalRequest).Data.USD;
            return historical;
        }
    }
}