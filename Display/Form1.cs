using Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var input = textBox1.Text;
            var lines = input.Split('\n');
            var regex = new Regex(@"([0-9\.]+) ([a-z]+)");
            var wallet = new Dictionary<string, decimal>();
            foreach (var line in lines)
            {
                if (regex.IsMatch(line)) {
                    var matches = regex.Matches(line);
                    wallet.Add(matches[0].Groups[2].Value, decimal.Parse(matches[0].Groups[1].Value));
                }
            }

            ValueGetter getter = new ValueGetter();
            var values = getter.GetValues().ToDictionary((v)=>v.Item1, (v)=>v);
            var walletValues = new Dictionary<string, decimal>();
            foreach (var item in wallet)
            {
                walletValues.Add(item.Key, values[item.Key].Item2 * item.Value);
                sb.AppendLine($"{item.Key}: {item.Value}@${values[item.Key].Item2} = {walletValues[item.Key]}");
            }

            var total = walletValues.Sum((v)=>v.Value);

            sb.AppendLine($"Total Value of Wallet: {total}");

            foreach (var value in values)
            {
                sb.AppendLine($"{value.Key}: {value.Value.Item4}");
            }

            sb.AppendLine($"buy {values.First().Key}");
            sb.AppendLine($"sell {values.Last().Key}");

            textBox1.Text = sb.ToString();
        }
    }
}
