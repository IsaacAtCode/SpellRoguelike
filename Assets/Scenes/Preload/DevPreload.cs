using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
    void Awake()
    {
        GameObject check = GameObject.Find("__app");
        if (check == null)
        { SceneManager.LoadScene("_preload", LoadSceneMode.Additive) ; }
    }
}
