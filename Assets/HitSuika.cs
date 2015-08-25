using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitSuika : MonoBehaviour
{
    Image buttonimage;
    bool count = false;
    public Sprite BrokenSuika;
    public SuiCounter suicounter;

    // Use this for initialization
    void Start()
    {
        buttonimage = GetComponent<Image>();
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        pos.x = Random.Range(-500, 500);
        pos.y = 455;
        GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public void SuikaBreak()
    {
        StartCoroutine("SuikaDestroyer");
    }

    /// <summary>
    /// OneShot Coroutine. Change Image and Destroy GameObject.
    /// </summary>
    /// <returns>No return</returns>
    IEnumerator SuikaDestroyer()
    {

        buttonimage.sprite = BrokenSuika;
        var BreakPointX = GetComponent<RectTransform>().position.x;
        var BreakPointY = GetComponent<RectTransform>().position.y;

        ArmCrash.GetHitPosition = new Vector3(BreakPointX, BreakPointY, 0);

        if (count == false)
        {
            SuiCounter.Suicountcs++;
            count = true;
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
