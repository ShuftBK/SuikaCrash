using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArmCrash : MonoBehaviour
{

    Vector3 MousePosition;
    Vector3 ArmPosition;
    Vector3 BeforeFramePosition;

    Image image;
    public Sprite sss;
    public Sprite Normal;

    public static Vector3 GetHitPosition;

    public float ArmY;
    public float Xmargin;


    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        MousePosition = Input.mousePosition;
        if (gameObject.name == "LeftArm")
            MousePosition.x += Xmargin;
        else
            MousePosition.x -= Xmargin;
        ArmPosition = new Vector3(MousePosition.x, ArmY, 0);
        GetComponent<RectTransform>().position = ArmPosition;


        //もし前フレームと今のフレームのGHPが同じならばスルーされ通常通り追従する
        //新しくHitした場合はロードされる
        if (BeforeFramePosition != GetHitPosition)
        {
            Debug.Log(GetHitPosition);
            //画面左側の処理
            if (GetHitPosition.x < 800)
            {
                //左側の左腕の処理
                if (gameObject.name == "LeftArm")
                {
                    ArmPosition = new Vector3(GetHitPosition.x, GetHitPosition.y, 0);
                    GetComponent<RectTransform>().position = ArmPosition;
                    StartCoroutine("LeftArmE");
                }//左側の右腕の処理
                else
                {
                    image.sprite = null;
                }
            }
            if (GetHitPosition.x > 800)
            {
                if (gameObject.name == "RightArm")
                {
                    ArmPosition = new Vector3(GetHitPosition.x, GetHitPosition.y, 0);
                    GetComponent<RectTransform>().position = ArmPosition;
                    StartCoroutine("RightArmE");
                }
                else
                {
                    image.sprite = null;
                }
            }

            image.sprite = Normal;
        }


        BeforeFramePosition = GetHitPosition;
    }

    IEnumerator LeftArmE()
    {
        image.sprite = sss;
        yield return new WaitForSeconds(0.2f);

    }

    IEnumerator RightArmE()
    {
        image.sprite = sss;
        yield return new WaitForSeconds(0.2f);
    }


}
