using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Input.multiTouchEnabled = true;

        SceneManager.LoadScene(Global.SceneName.s_mainMenu);

    }
}
