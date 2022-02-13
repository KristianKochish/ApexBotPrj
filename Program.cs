using ApexBotPrj;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("5162272218:AAFks9qse_7sqjT37M2vt9LNq2e6gxdbBTo");

using var cts = new CancellationTokenSource();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
};
botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Type != UpdateType.Message)
        return;
    // Only process text messages
    if (update.Message!.Type != MessageType.Text)
        return;

    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    // Echo received message text
    /*Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "You said:\n" + messageText,
        cancellationToken: cancellationToken);*/
    if ((messageText.ToLower()).Equals("br"))
    {
        requestBrMaps(chatId, cancellationToken, botClient);
    }
    if ((messageText.ToLower()).Equals("guide")) {
        gameGuide(chatId, cancellationToken, botClient);
    }
}

Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}


static async void requestBrMaps(long chatId, CancellationToken cancellationToken, ITelegramBotClient botClient)
{
    Message sentMessage;
    var httpClient = new HttpClient();
    //var result = await httpClient.GetAsync("https://api.mozambiquehe.re/maprotation?version=5&auth=OXiAlre4S3fLz9gPLlaF");
    var content = await httpClient.GetStringAsync("https://api.mozambiquehe.re/maprotation?version=5&auth=OXiAlre4S3fLz9gPLlaF");
    Console.WriteLine(content);

    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(content);
    DateTime dateTimeNow = DateTime.Now;
    long elapsedTicks = (data.battle_royale.next.readableDate_start.Subtract(dateTimeNow).Ticks);
    TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

    sentMessage = await botClient.SendTextMessageAsync(chatId: chatId,
                                                               text: "Current map is:\n" + data.battle_royale.current.map,
                                                               cancellationToken: cancellationToken);
    sentMessage = await botClient.SendTextMessageAsync(chatId: chatId,
                                                              text: "Next map is in:\n" + data.battle_royale.next.map + " in " + (elapsedSpan.Days + " days " + elapsedSpan.Hours + " hours " + elapsedSpan.Minutes + " minutes " + elapsedSpan.Seconds + " seconds "),
                                                              cancellationToken: cancellationToken);
}

static async void gameGuide(long chatId, CancellationToken cancellationToken, ITelegramBotClient botClient) {

    Message message = await botClient.SendAudioAsync(
    chatId: chatId,
    audio: "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",//"D:\\Downloads\\y2mate (mp3cut.net).mp3",
    /*
    performer: "Joel Thomas Hunger",
    title: "Fun Guitar and Ukulele",
    duration: 91, // in seconds
    */
    cancellationToken: cancellationToken);
}