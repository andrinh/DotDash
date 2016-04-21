using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour {

    public GameObject gameOverCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hazard")
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            Button pauseButton = GameObject.FindGameObjectWithTag("PauseButton").GetComponent<Button>();
            pauseButton.interactable = false;
            gameOverCanvas.SetActive(true);
        }
    }
}
