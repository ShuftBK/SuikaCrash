using UnityEngine;
using System.Collections;

public class SuikaGenerator : MonoBehaviour
{
    public float max = 5;
    public float min = 1;

    [SerializeField]

    private GameObject Suika;
    private float RandomTime;

    void Awake()
    {
        InvokeRepeating("Generate", Random.Range(min, max), Random.Range(min, max));
    }

    void Generate()
    {
        GameObject obj = Suika;
        GameObject prefab = Instantiate(obj);
        prefab.transform.SetParent(this.transform, false);
    }

}
