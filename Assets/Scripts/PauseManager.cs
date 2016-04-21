using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public Sprite unpauseSprite;
    public Sprite pauseSprite;

    private static bool paused;
    private Button pauseButton;
 
    void Awake()
    {
        Time.timeScale = 1;
        paused = false;
        pauseButton = GetComponent<Button>();
    }

    public void setPaused()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            pauseButton.image.overrideSprite = unpauseSprite;
        }
        else if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseButton.image.overrideSprite = pauseSprite;
        }

    }
}
