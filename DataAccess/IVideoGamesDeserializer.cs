using GameDataParser.Model;

namespace GameDataParser.DataAccess;

public interface IVideoGamesDeserializer
{
    List<VideoGame> DeserializerFrom(string fileName, string fileContents);
}