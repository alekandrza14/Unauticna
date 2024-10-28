using UnityEngine;
using UnityEngine.UI;

public class BinarMagic : MonoBehaviour
{
    public Text ввод;
    public GameObject boom,yuhu;
    public string[] binarCode;
    public string[] CodeOutput;
    public string CodeInput;
    public static BinarMonipulation body;
    public static float speed = 1;
    void endCode()
    {
        for (int i = 0; i < binarCode.Length; i++)
        {
            if (binarCode[i] == CodeInput)
            {
                Invoke(CodeOutput[i],0);
            }
        }
    }
    //Octopus
    public void Octo()
    {
        RaycastHit hit = MainRay.MainHit;
        ElementalInventory m = ElementalInventory.main();
        if (hit.collider != null)
        {
            body = Instantiate(m.inv2("Octopus").gameObject, hit.point + Vector3.up * m.inv2("Octopus").gameObject.transform.localScale.y / 2, Quaternion.identity).AddComponent<BinarMonipulation>();

            cistalenemy.dies++;
        }

    }
    public void Soul()
    {
        RaycastHit hit = MainRay.MainHit;
        ElementalInventory m = ElementalInventory.main();
        if (hit.collider != null)
        {
            body = Instantiate(m.inv2("Soul").gameObject, hit.point + Vector3.up * m.inv2("Soul").gameObject.transform.localScale.y / 2, Quaternion.identity).AddComponent<BinarMonipulation>();

            cistalenemy.dies++;
        }

    }
    public void Fire()
    {
        RaycastHit hit = MainRay.MainHit;
        ElementalInventory m = ElementalInventory.main();
        if (hit.collider != null)
        {
            body = Instantiate(m.inv2("Fire").gameObject, hit.point + Vector3.up * m.inv2("Fire").gameObject.transform.localScale.y / 2, Quaternion.identity).AddComponent<BinarMonipulation>();

            cistalenemy.dies++;
        }

    }//ForVision
    public void ForVision()
    {
        mover.main().PlayerCamera.GetComponent<Camera>().farClipPlane = 1000000.0f;
    }
    public void Move()
    {
        body.InvokeRepeating("Move", 0, 0.1f);
    }
    public void SpeedUp()
    {
        speed *= 2;
    }
    public void SpeedDown()
    {
        speed /= 2;
    }
    public void TimeUp()
    {
        Time.timeScale *= 2;
    }
    public void TimeDown()
    {
        Time.timeScale /= 2;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
        {
            Instantiate(boom);
            ввод.text += " ";
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.F1))
        {
            Instantiate(yuhu);
            ввод.text += "█";
        }
        if (ввод.text.Length == 8)
        {
            CodeInput = ввод.text;
            endCode();
            ввод.text = "";
        }
    }
}
