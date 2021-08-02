using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfMenu : MonoBehaviour
{
    public void SwitchIncome()
    {
        Clicker.Instance.SwitchIncome();
        UI.Instance.ifMenuOpened = true;
    }
}
