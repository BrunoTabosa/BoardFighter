using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConfigurationManager : Singleton<GameConfigurationManager>
{

    public IEnumerator Initialize()
    {
        
        yield return null;
    }

    public void InitGameplay()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
