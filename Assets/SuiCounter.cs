using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuiCounter : MonoBehaviour
{
    public static int Suicountcs;

    void Update()
    {
        this.GetComponent<Text>().text = Suicountcs.ToString();
    }

}
