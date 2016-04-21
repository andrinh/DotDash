using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

    public string scene;

    public void switchScene()
    {
        Application.LoadLevel(scene);
    }
}
