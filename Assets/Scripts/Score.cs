using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UI ui;

    public static Score Instance;

    private const string CarrotsPath = "Carrots";
    private const string XpPath = "Xp";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple singletons");
    }
    private void Start()
    {
        ui.UpdateUI(PlayerPrefs.GetInt(XpPath), PlayerPrefs.GetInt(CarrotsPath));
    }
    public void AddXp(int xp)
    {
        int _xp = PlayerPrefs.GetInt(XpPath) + xp;
        int _carrots = PlayerPrefs.GetInt(CarrotsPath);
        PlayerPrefs.SetInt(XpPath, _xp);
        ui.UpdateUI(_xp, _carrots);
    }
    public void AddCarrots(int carrots)
    {
        int _xp = PlayerPrefs.GetInt(XpPath);
        int _carrots = PlayerPrefs.GetInt(CarrotsPath) + carrots;
        PlayerPrefs.SetInt(CarrotsPath, _carrots);
        ui.UpdateUI(_xp, _carrots);
    }
}
