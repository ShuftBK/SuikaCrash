using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour
{

    //public GameObject AudioSuika;
    bool OneShotStarter = false;

    void Update()
    {

        if (Application.loadedLevelName == "Title" && Input.GetKey(KeyCode.Space))
        {
            scenemove("Suika");
        }

        if (Application.loadedLevelName == "Suika" && OneShotStarter == false)
        {
            StartCoroutine("GameSuika");
        }

        if (Application.loadedLevelName == "Result" && Input.GetKey(KeyCode.Space))
        {
            SuiCounter.Suicountcs = 0;
            scenemove("Title");
        }

    }

    IEnumerator GameSuika()
    {
        OneShotStarter = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        OneShotStarter = false;
        scenemove("Result");
    }

    void scenemove(string name)
    {
        Application.LoadLevel(name);
    }


}
