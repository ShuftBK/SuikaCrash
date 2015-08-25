using UnityEngine;

public class SuiCounterGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject SuiCounter;

    void Awake()
    {
        GameObject SuiCounterGenerate = Instantiate(SuiCounter);
        SuiCounterGenerate.transform.SetParent(this.transform, false);
    }

}