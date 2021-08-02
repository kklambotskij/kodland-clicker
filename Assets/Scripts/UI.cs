using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Modifier;
    [SerializeField] private TextMeshProUGUI Money;

    [SerializeField] public GameObject IfMenu;
    [SerializeField] public GameObject IfCost;

    [SerializeField] public GameObject BoolMenu;
    [SerializeField] public GameObject BoolCost;
    [SerializeField] public TextMeshProUGUI BoolText;

    [SerializeField] public GameObject VoidMenu;
    [SerializeField] public GameObject VoidCost;

    [SerializeField] public GameObject ForMenu;
    [SerializeField] public GameObject ForCost;

    [SerializeField] public GameObject OOPMenu;
    [SerializeField] public GameObject OOPCost;

    [SerializeField] public GameObject CodeMenu;
    [SerializeField] public GameObject CodeCost;

    [SerializeField] public GameObject BackButton;
    [SerializeField] AudioSource audioSourcer;

    public bool ifMenuOpened;
    public static UI Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }
    public void ShowFabrics(int fabricksCount)
    {
        //fabricText.text = "������ � �������:" + fabricksCount;
    }
    public void ShowClicks(int clicksCount)
    {
        //Clicks.text = "������: " + clicksCount;
    }
    public void ShowMoney(int moneyCount)
    {
        if(moneyCount > 1000000000)
        {
            Money.text = "int count = " + (moneyCount / 1000000000) + "B;";
        }
        else if (moneyCount > 1000000)
        {
            Money.text = "int count = " + (moneyCount / 1000000) + "M;";
        }
        else if(moneyCount >1000)
        {
            Money.text = "int count = " + (moneyCount / 1000) + "k;";
        }
        else
        {
            print(moneyCount);
            Money.text = "int count = " + moneyCount + ";";
        }
    }
    public void ShowModificator(int incomeCount)
    {
        Modifier.text = "int income = " + incomeCount + ";";
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void CloseIfMenu()
    {
        IfMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        audioSourcer.Stop();
    }
    public void CloseBoolMenu()
    {
        BoolMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        BoolText.text = "bool isActive = false;";
        audioSourcer.Stop();
    }
    public void CloseVoidMenu()
    {
        VoidMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        audioSourcer.Stop();
    }
    public void CloseForMenu()
    {
        ForMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        audioSourcer.Stop();
    }
    public void CloseOOPMenu()
    {
        OOPMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        audioSourcer.Stop();
    }
    public void CloseCodeMenu()
    {
        CodeMenu.GetComponent<Animator>().SetTrigger("Dissapear");
        audioSourcer.Stop();
    }
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
