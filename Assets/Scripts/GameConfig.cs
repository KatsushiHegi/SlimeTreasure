[System.Serializable]
public class GameConfig
{
    public string playerName;
    public int killCount;
    public int swordCount;
    public bool[] activeSword;
    public int[] kakeraCounts;
    public GameConfig()
    {
        playerName = "SlimeHunter";
        killCount = 0;
        swordCount = 1;
        activeSword = new bool[6];
        kakeraCounts = new int[6];

        for (int i = 0; i < activeSword.Length; i++)
        {
            activeSword[i] = false;
            kakeraCounts[i] = 0;
        }
        activeSword[0] = true;
    }
}
