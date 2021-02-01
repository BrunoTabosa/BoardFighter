using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameConfigurationManager gameManager => GameConfigurationManager.Instance;

    void Awake()
    {
        gameManager.Initialize();
    }

    public void OnPlayClicked()
    {
        gameManager.InitGameplay();
    }
}
