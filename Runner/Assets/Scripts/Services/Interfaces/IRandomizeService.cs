using System.Collections.Generic;

public interface IRandomizeService : IGameService
{
    int Randomize(int index, List<LevelPartData> levelPartDatas);
}