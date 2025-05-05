using UnityEngine;
namespace x
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    struct Undertale
    {
        public int mama;

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        public static Undertale urod = new Undertale();
    }
}


public class VineRandomGenerotor : MonoBehaviour
{
    public GameObject[] water;
    void Start()
    {
        x.Undertale.urod.mama--;
        foreach (GameObject item in water)
        {
            item.transform.localScale = Vector3.one * Random.Range(10f, 100f);
        }
    }
    public void DrinkVine()
    {
        foreach (GameObject item in water)
        {
            Instantiate(Resources.Load<GameObject>("Drink"), transform.position, Quaternion.identity);
            item.transform.localScale = item.transform.localScale * Random.Range(0.9f, 1f);
        }
    }
}
