using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

/// <summary>
/// Менеджер модов - это основная ссылка, которая должна быть на стартовой сцене. Именно ModsManager запускает загрузку модов и инициализацию.
/// </summary>
public class YagirModsManager : MonoBehaviour
{
    /// <summary>
    /// Singleton of ModsManager
    /// </summary>
    public static YagirModsManager Instance;
    /// <summary>
    /// Mods Folder Path
    /// </summary>
    [SerializeField] public string modsFolder  { get; private set; }
    /// <summary>
    /// Mods Load Chain Folder
    /// </summary>
    [SerializeField] public string modsChainFolder { get; private set; }
    /// <summary>
    /// Loader mods
    /// </summary>
    public YagirModsLoader modLoader { get; private set; }
    /// <summary>
    /// Loader assembly
    /// </summary>
    public YagirModAssemblyLoader modAssemblyLoader { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Init();
    }

    public void ReloadMods()
    {
        modLoader.UnloadBundles();
        Process.Start(Application.dataPath + "/../" + Application.productName + ".exe");
        Application.Quit();
    }

    public void Init()
    {
        modsFolder = Application.dataPath + $"/../Mods/";
        Directory.CreateDirectory(modsFolder);
        modsChainFolder = modsFolder + "loader.chain";

        modAssemblyLoader = new YagirModAssemblyLoader();
        modLoader = new YagirModsLoader();

        modLoader.Init(modsFolder, modsChainFolder, modAssemblyLoader);
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < modLoader.mods.Count; i++)
        {
            //modLoader.mods[i].bundle?.Unload(true);
            //modLoader.mods[i].scenesBundle?.Unload(true);
        }
    }

    public void PrintPaths()
    {
        UnityEngine.Debug.Log(modsFolder);
        UnityEngine.Debug.Log(modsChainFolder);
    }
}
