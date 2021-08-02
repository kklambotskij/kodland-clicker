using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
public void Appear()
{
    GetComponent<Animator>().SetTrigger("Finger");
}
}
