using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;


namespace GameDataParser.App;

public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IFileReader _fileReader;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;
    private readonly IGamesPrinter _gamesPrinter;

    public GameDataParserApp(
        IUserInteractor userInteractor,
        IGamesPrinter gamesPrinter,
        IVideoGamesDeserializer videoGamesDeserializer,
        IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGamesDeserializer = videoGamesDeserializer;
        _fileReader = fileReader;
    }

    public void Run()
    {
        var fileName = _userInteractor.ReadValidFilePath();
        var fileContents = _fileReader.Read(fileName);
        var videoGames = _videoGamesDeserializer.DeserializerFrom(fileName, fileContents);
        _gamesPrinter.Print(videoGames);
    }
}