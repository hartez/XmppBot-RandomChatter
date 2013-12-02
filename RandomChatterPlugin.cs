using System;
using System.ComponentModel.Composition;
using System.IO;
using SimpleConfig;
using XmppBot.Common;

namespace XmppBot_RandomChatter
{
    [Export(typeof(IXmppBotPlugin))]
    public class RandomChatterPlugin : IXmppBotPlugin
    {
        private int _percentChanceOfResponse;
        private string[] _responses;

        public RandomChatterPlugin()
        {
            var config = Configuration.Load<RandomChatterConfig>();
            Initialize(config);
        }

        public RandomChatterPlugin(string configPath)
        {
            var config = Configuration.Load<RandomChatterConfig>(configPath: configPath);
            Initialize(config);
        }

        public string Evaluate(ParsedLine line)
        {
            var r = new Random();

            if(_responses.Length > 0 && r.Next(0, 99) >= _percentChanceOfResponse)
            {
                return _responses[r.Next(0, _responses.Length - 1)];
            }

            return null;
        }

        public string Name
        {
            get { return "Random Chatter"; }
        }

        private void Initialize(RandomChatterConfig config)
        {
            _percentChanceOfResponse = 100 - config.PercentChanceOfResponse;

            if(!String.IsNullOrEmpty(config.ResponsesFilePath))
            {
                ReadChatterStrings(config.ResponsesFilePath);
            }
            else
            {
                _responses = new string[0];
            }
        }

        private void ReadChatterStrings(string path)
        {
            _responses = File.ReadAllLines(path);
        }
    }
}