using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Buttons")]
    [Header("UI")]
    public Button clueButton;
    public Button remindMeButton;
    [Header("Panel")]
    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    [Header("Prefabs")]
    public GameObject[] memoryTile;

    Dictionary<int, Color32>[] memoryMap;

    // Private Variables
    float yPos; // Memory Tile Y position
    string seedPhrase;
    int seedHash;
    int maxTiles = 99;
    Color32 randomColor;

    void Start() => StartGame();

    void StartGame()
    {
        gameMode = GameMode.Levels;

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

        //! DELETE THIS LATER
        PlayerPrefs.SetInt("Level", maxTiles);

        // Cap tile production till maxTiles   
        int totalTiles = PlayerPrefs.GetInt("Level") <= maxTiles ?
        (PlayerPrefs.GetInt("Level")) : maxTiles;

        // Create dictionary
        memoryMap = new Dictionary<int, Color32>[totalTiles];

        // Loop through total tiles
        for (int i = 0; i < totalTiles; i++)
        {
            // Save co-ordinates
            //SaveCoordinates(i, );
            //memoryMap[i].Add(i);
            tempMemoryTile = Instantiate(memoryTile[Random.Range(0, memoryTile.Length)], new Vector3(0f, yPos, 0f), Quaternion.identity);
            tempMemoryTile.transform.SetParent(memoryTileParent.transform);
            yPos += 20f;
        }
    }

    // Spawn incremental blocks based on user succession
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
        if (playerController.playerAttempts > 0)
        playerController.playerAttempts++;
        else
        remindMeButton.interactable = false;
    }

    // Gives 1 hint
    void ClueButton()
    {

        // Increment attempts
        if (playerController.playerAttempts > 0)
        playerController.playerAttempts++;
        else
        clueButton.interactable = false;
    }

    void SaveCoordinates(int index, int value, Color32 color)
    {
        memoryMap[index].Add(value, color);
    }

    Color32 RandomColor()
    {
        randomColor = new Color32((byte) Random.Range(0f, 255f), (byte) Random.Range(0, 255f), (byte) Random.Range(0f, 255f), (byte) 255f);
        return randomColor;
    }

    void EndGame()
    {

    }

    public enum GameMode { Levels, Infinite }
}
