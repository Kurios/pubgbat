using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

using Discord.WebSocket;
using Discord;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private RandomTables randomTables = new RandomTables();

        private DiscordSocketClient client;

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task MessageRecieved(SocketMessage message)
        {
            if (message.Content == "!mode all")
            {
                randomTables.FlagRule = RandomTables.ALLOW_ALL_MODES;
                await message.Channel.SendMessageAsync("Allow All Modes");
            }
            else if (message.Content == "!mode simon")
            {
                randomTables.FlagRule = RandomTables.SIMON_MODE;
                await message.Channel.SendMessageAsync("Simon Mode");
            }
            else if (message.Content == "!mode bonus")
            {
                randomTables.FlagRule = RandomTables.BONUS_CHALLENGE;
                await message.Channel.SendMessageAsync("Bonus Mode");
            }
            else if (message.Content == "!roll")
            {
                //generate message;
                string ret = "```c\nPROD MODE<DEV>\n";
                ret += "Weapons  : \"" + randomTables.getWeaponRule() + "\"\n";
                ret += "Armour   : \"" + randomTables.getArmourRule() + "\"\n";
                ret += "Medicine : \"" + randomTables.getMedicineRules() + "\"\n";
                ret += "Location : \"" + randomTables.getLocation() + "\"\n";
                ret += "Fuckery  : \"" + randomTables.getFuckeryRules() + "\"\n";
                await message.Channel.SendMessageAsync(ret + "```");
            }
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.

            DiscordSocketClient client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += MessageRecieved;
            string token = Properties.Settings.Default.Secret;
            string username = "pubgbat#2967";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
