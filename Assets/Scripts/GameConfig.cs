using JetBrains.Annotations;

[System.Serializable]
public class GameConfig
{
    public string playerName;
    public int killCount, swordCount, activeSwordNum;
    public bool[] sworded;
    public int[] kakeraCounts;

    public bool isBossGame;
    public int bossHp;

    public int TreasuresCount;
    public int clearCount;

    public int nowPlace;
    public GameConfig()
    {
        playerName = "SlimeHunter";
        swordCount = 1;
        sworded = new bool[6];
        kakeraCounts = new int[6];
        bossHp = Boss.maxHp;
        sworded[0] = true;
    }
}
