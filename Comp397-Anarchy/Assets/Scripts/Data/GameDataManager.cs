using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<GameDataPersistence> gameDataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static GameDataManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        SceneManager.sceneUnloaded -= SceneUnloaded;
    }

    public void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.gameDataPersistenceObjects = FindAllGameDataPersistenceObjects();
        LoadGame();
    }

    public void SceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            return;
        }

        foreach (GameDataPersistence gameDataPersistenceObj in gameDataPersistenceObjects)
        {
            gameDataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            return;
        }
        foreach (GameDataPersistence gameDataPersistenceObj in gameDataPersistenceObjects)
        {
            gameDataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }
    private void ApplicationQuit()
    {
        SaveGame();
    }

    private List<GameDataPersistence> FindAllGameDataPersistenceObjects()
    {
        IEnumerable<GameDataPersistence> gameDataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<GameDataPersistence>();
        return new List<GameDataPersistence>(gameDataPersistencesObjects);
    }
    
    public bool HasGameData()
    {
        return gameData != null;
    }
}
