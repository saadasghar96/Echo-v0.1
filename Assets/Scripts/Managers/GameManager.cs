using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static Variables
    // Singleton
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    public static GameMode gameMode;
    public static int infiniteModeLevel;

    // Public Variables
    public PlayerController playerController;
    public GuideController guideController;
    public MemoryTileController memoryTileController;
    [Header("Panel")]
    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    [Header("Prefabs")]
    public GameObject[] memoryTile;

    Dictionary<int, Color32> memoryMap = new Dictionary<int, Color32>();

    // Private Variables
    float yPos; // Memory Tile Y position
    string seedPhrase;
    int seedHash;

    void Start() => StartGame();

    void StartGame()
    {
        gameMode = GameMode.Infinite;

        // Choose game mode
        if (gameMode == GameMode.Levels)
        {
            SpawnLevels();
        }
        else if (gameMode == GameMode.Infinite)
        {
            SpawnInfinite();
        }
    }

    void SpawnLevels()
    {
        // Set seed
        seedPhrase = "Level " + (PlayerPrefs.GetInt("Level") + 1);
        seedHash = seedPhrase.GetHashCode();
        Random.InitState(seedHash);

        GameObject memoryTileParent = new GameObject("MemoryTileParent");
        GameObject tempMemoryTile;

        for (int i = 0; i < 10; i++)
        {
            tempMemoryTile = Instantiate(memoryTile[Random.Range(0, memoryTile.Length)], new Vector3(0f, yPos, 0f), Quaternion.identity);
            tempMemoryTile.transform.SetParent(memoryTileParent.transform);
            yPos += 20f;
        }
    }

    void SpawnInfinite()
    {
        // Set seed
        seedPhrase = "Level " + (PlayerPrefs.GetInt("Level") + 1);
        seedHash = seedPhrase.GetHashCode();
        Random.InitState(seedHash);

        GameObject memoryTileParent = new GameObject("MemoryTileParent");
        GameObject tempMemoryTile;

        for (int i = 0; i < 10; i++)
        {
            tempMemoryTile = Instantiate(memoryTile[Random.Range(0, memoryTile.Length)], new Vector3(0f, yPos, 0f), Quaternion.identity);
            tempMemoryTile.transform.SetParent(memoryTileParent.transform);
            yPos+=20f;
        }
    }

    // The guide creates, follows and stores a pattern
    void GuidePlayer()
    {

    }

    // Replay pattern
    void ReminderButton()
    {

        // Increment attempts
        playerController.playerAttempts++;
    }

    // Gives 1 hint
    void ClueButton()
    {

        // Increment attempts
        playerController.playerAttempts++;
    }

    Color32 RandomColor()
    {
        return new Color32((byte) Random.Range(0f, 255f), (byte) Random.Range(0, 255f), (byte) Random.Range(0f, 255f), (byte) 255f);
    }

    void EndGame()
    {

    }

    public enum GameMode { Levels, Infinite }
}
