using System.Collections;
using TMPro;
using UnityEngine;

public class Fabrick : MonoBehaviour
{
    public int fabricksCount;
    void Start()
    {
        StartCoroutine(Fabric());
    }
    public void Starter()
    {
        fabricksCount += 1;
        UI.Instance.ShowFabrics(fabricksCount);
    }
    IEnumerator Fabric()
    {
        for (;;)
        {
            yield return new WaitForSeconds(1f);
            Clicker.Instance.moneyCount += fabricksCount;
        }
    }
}
