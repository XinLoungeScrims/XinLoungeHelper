using System;
using Tomat.Framework.Core.Bot;
using XinLoungeHelper;

// load our environment variables containing our token
DotNetEnv.Env.Load();
//Console.WriteLine("token: " + Environment.GetEnvironmentVariable("TOKEN"));

// initialise and start the bot with the token found in .env
using DiscordBot discordBot = new XinLoungeHelperBot("");
await discordBot.StartBot();