using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCollisionFinishThree : MonoBehaviour
{
    private int count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            LoadSceneMode();
        }
    }
    private void LoadSceneMode()
    {
        SceneManager.LoadScene("Finish");
    }
}
