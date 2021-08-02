using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Clicker : MonoBehaviour
{
    public int moneyCount;
    public int incomeCount;
    public int upgradePrice => incomeCount * 10;
    public int clicksCount;
    public static Clicker Instance { get; private set; }
    [SerializeField] GameObject ClickParticle;
    [SerializeField] Transform Canvas;
    [SerializeField] Transform MoneySpawner;
    [SerializeField] Transform IncomeSpawner;
    [SerializeField] Transform ParticleButton;

    [SerializeField] GameObject IncomeIf;
    [SerializeField] GameObject IncomeUsual;
    [SerializeField] AudioSource SkillAudioSourcer;
    

    public bool[] skillsBought = new bool[6];

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }
    void Start()
    {
        incomeCount = 1;
        if (PlayerPrefs.HasKey("money"))
        {
            string str = PlayerPrefs.GetString("skills");
            int i = 0;
            foreach (var item in str)
            {
                if (i.ToString() == item.ToString())
                {
                    skillsBought[i] = true;
                }
                i++;
            }
            SwitchIncome();
            UI.Instance.BackButton.SetActive(true);
            AddMoney(PlayerPrefs.GetInt("money"));
            AddIncome(PlayerPrefs.GetInt("income"));
            AnimationLiner.Instance.SkipTutorial();
        }
        if (skillsBought[0])
        {
            UI.Instance.IfCost.SetActive(false);
        }
        if (skillsBought[1])
        {
            UI.Instance.BoolCost.SetActive(false);
        }
        if (skillsBought[2])
        {
            UI.Instance.VoidCost.SetActive(false);
        }
        if (skillsBought[3])
        {
            UI.Instance.ForCost.SetActive(false);
        }
        if (skillsBought[4])
        {
            UI.Instance.OOPCost.SetActive(false);
        }
        if (skillsBought[5])
        {
            UI.Instance.CodeCost.SetActive(false);
        }
    }
    public void OnClick()
    {
        AddMoney(incomeCount);
        if (skillsBought[0])
        {
            PlayerPrefs.SetInt("money", moneyCount);
        }
        if (moneyCount >= 10)
        {
            AnimationLiner.Instance.ModifyerCountAppear();
        }
        SkillAudioSourcer.pitch = Random.Range(0.8f, 1f);
        SkillAudioSourcer.Play();
    }
    public void AddMoney(int count)
    {
        GameObject buf = Instantiate(ClickParticle, MoneySpawner.transform.position, Quaternion.identity);
        buf.GetComponent<Text>().text = moneyCount.ToString();
        buf.transform.SetParent(Canvas);
        buf.transform.localScale = new Vector3(1, 1, 1);
        Destroy(buf, 1);
        moneyCount += count;
        UI.Instance.ShowMoney(moneyCount);
    }
    public void Modificator()
    {
        if (!skillsBought[0])
        {
            AddIncome(1);
        }
        else if(moneyCount >= 100)
        {
            AddMoney(-100);
            AddIncome(1);
            if (incomeCount % 100 == 0)
            {
                Ads.instance.ShowRewardedVideo();
            }
            else if (incomeCount % 50 == 0)
            {
                Ads.instance.ShowVideo();
            }
        }
        if (incomeCount == 10)
        {
            AnimationLiner.Instance.ModifierDissapear();
        }
    }

    public void AddIncome(int count)
    {
        GameObject buf = Instantiate(ClickParticle, IncomeSpawner.transform.position, Quaternion.identity);
        buf.GetComponent<Text>().text = incomeCount.ToString();
        buf.transform.SetParent(Canvas);
        buf.transform.localScale = new Vector3(1, 1, 1);
        incomeCount += count;
        if (skillsBought[0])
        {
            PlayerPrefs.SetInt("income", incomeCount);
            PlayerPrefs.SetInt("money", moneyCount);
        }
        Destroy(buf, 1);
        UI.Instance.ShowModificator(incomeCount);
    }
    private bool BuySkill(int number, int cost)
    {
        if (skillsBought[number] == true)
        {
            return true;
        }
        if (moneyCount >= cost)
        {
            AddMoney(-cost);
            PlayerPrefs.SetInt("money", moneyCount);
            skillsBought[number] = true;
            string str = PlayerPrefs.GetString("skills", "");
            str += number.ToString();
            PlayerPrefs.SetString("skills", str);
            return true;
        }
        return false;
    }
    public void SkillIf()
    {
        if (BuySkill(0, 500))
        {
            UI.Instance.BackButton.SetActive(true);
            UI.Instance.IfCost.SetActive(false);
            UI.Instance.IfMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayIfSkill();
        }
    }

    public void SkillBool()
    {
        if (BuySkill(1, 10000))
        {
            UI.Instance.BoolCost.SetActive(false);
            UI.Instance.BoolText.text = "bool isActive = true;";
            UI.Instance.BoolMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayBoolSkill();
        }
    }

    public void SkillVoid()
    {
        if (BuySkill(2, 100000))
        {
            UI.Instance.VoidCost.SetActive(false);
            UI.Instance.VoidMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayVoidSkill();
        }
    }

    public void SkillFor()
    {
        if (BuySkill(3, 1000000))
        {
            UI.Instance.ForCost.SetActive(false);
            UI.Instance.ForMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayForSkill();
        }
    }
    public void SkillOOP()
    {
        if (BuySkill(4, 10000000))
        {
            UI.Instance.OOPCost.SetActive(false);
            UI.Instance.OOPMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayOOPSkill();
        }
    }
    public void SkillCode()
    {
        if (BuySkill(5, 1000000000))
        {
            UI.Instance.CodeCost.SetActive(false);
            UI.Instance.CodeMenu.GetComponent<Animator>().SetTrigger("Appear");
            AnimationLiner.Instance.PlayGameCodeSkill();
        }
    }

    public void SwitchIncome()
    {
        IncomeUsual.SetActive(false);
        IncomeIf.SetActive(true);
    }

    public void ClickFor()
    {
        OnClick();
        Invoke("OnClick", 0.1f);
        Invoke("OnClick", 0.2f);
    }
    private List<string> oopString = new List<string>();
    public void SpawnerOOP()
    {
        if (oopString.Count == 0)
        {
            oopString.Add("Наследование");
            oopString.Add("Инкапсуляция");
            oopString.Add("Полиморфизм");
        }

        GameObject buf = Instantiate(ClickParticle, ParticleButton.position, Quaternion.identity);
        buf.GetComponent<Text>().text = oopString[0];
        buf.transform.SetParent(Canvas);
        buf.transform.localScale = new Vector3(1, 1, 1);
        Destroy(buf, 2);
        oopString.RemoveAt(0);
    }

    public void SourceCodeButton()
    {
        Application.OpenURL("https://github.com/kolobchara/kodland-clicker");
    }
}

