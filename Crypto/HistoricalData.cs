namespace Crypto
{
    public class HistoricalData
    {
        public Values USD { get; set; }
    }

}

/*
 Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


// 20180208211202
// https://min-api.cryptocompare.com/data/pricehistorical?fsym=USD&tsyms=BTC,BCH,DOGE,LTC,DASH&ts=1452680400

{
  "USD": {
    "BTC": 0.002314,
    "BCH": 0,
    "DOGE": 4762.36,
    "LTC": 0.2874,
    "DASH": 0.2791
  }
}


// 20180208210905
// https://min-api.cryptocompare.com/data/price?fsym=USD&tsyms=BTC,BCH,DOGE,LTC,DASH

{
  "BTC": 0.0001253,
  "BCH": 0.000787,
  "DOGE": 223.11,
  "LTC": 0.006835,
  "DASH": 0.00169
}
     */
