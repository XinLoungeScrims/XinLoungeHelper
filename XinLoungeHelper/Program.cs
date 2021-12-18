using System;
using Tomat.Framework.Core.Bot;
using XinLoungeHelper;

// load our environment variables containing our token
DotNetEnv.Env.TraversePath().Load();

// check if token actually loaded
string? token = Environment.GetEnvironmentVariable("TOKEN");
if (string.IsNullOrEmpty(token))
{
    throw new Exception("Token was not loaded or was found empty.");
}

// initialise and start the bot with the token found in .env
using DiscordBot discordBot = new XinLoungeHelperBot(token);
await discordBot.StartBot();