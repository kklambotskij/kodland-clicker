using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AnimationLiner : MonoBehaviour
{
    [SerializeField] Animator StartMessage;
    [SerializeField] Animator Hello_worldMessage;
    [SerializeField] Animator Count;
    [SerializeField] Animator Click;
    [SerializeField] Animator Modifier;
    [SerializeField] Animator ModifierCount;
    [SerializeField] public Animator Skill;

    [SerializeField] List<AudioClip> audioList;

    [SerializeField] GameObject helloParticle;
    [SerializeField] TextMeshProUGUI ClickButtonText;
    public int prints;
    private AudioSource audioSource;
    public static AnimationLiner Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayNext();
            StartMessage.SetTrigger("Appear");
        }
        else
        {
            currentClip = 12;
        }
    }

    int currentClip = 0;
    private void PlayNext()
    {
        if (currentClip >= audioList.Count) { return; }

        audioSource.Stop();
        audioSource.clip = audioList[currentClip];
        audioSource.PlayDelayed(1);
        currentClip += 1;
    }

    public void PlayIfSkill()
    {
        currentClip = 6;
        PlayNext();
    }
        public void PlayBoolSkill()
    {
        currentClip = 7;
        PlayNext();
    }
        public void PlayVoidSkill()
    {
        currentClip = 8;
        PlayNext();
    }
        public void PlayForSkill()
    {
        currentClip = 9;
        PlayNext();
    }
        public void PlayOOPSkill()
    {
        currentClip = 10;
        PlayNext();
    }
        public void PlayGameCodeSkill()
    {
        currentClip = 11;
        PlayNext();
    }

    public void PrintHelloWorldAppear()
    {
        if (currentClip == 1)
        {
            PlayNext();
            StartMessage.SetTrigger("Dissapear");
            Hello_worldMessage.SetTrigger("Appear");
        }
    }
    public void PrintHelloWorldDissapear()
    {
        if (currentClip == 2)
        {
        Hello_worldMessage.SetTrigger("Dissapear");
        }
    }
    
    public void PrintDissapear()
    {
        prints += 1;
        if (prints == 10)
        {
            Hello_worldMessage.SetTrigger("FullDissapear");
            Count.SetTrigger("Appear");
            PlayNext();
        }
        Vector3 position;
        if (Hello_worldMessage.transform.position.y > 0)
        {
            position = Hello_worldMessage.transform.position;
            position.z = 96;
        }
        else
        {
            position = new Vector3(0, 0, 96);
        }
        GameObject buf = Instantiate(helloParticle, position, Quaternion.identity);
        Destroy(buf, 10);
    }

    public void MoneyDissapear()
    {
        if (currentClip == 3)
        {
            PlayNext();
            Count.SetTrigger("Dissapear");
            Click.SetTrigger("Appear");
        }
    }

    public void ClickExplanationDissapear()
    {
        if (currentClip == 4)
        {
        Click.SetTrigger("Dissapear");
        Click.SetTrigger("ClickThisPlease");
        }
    }

    public void ModifyerCountAppear()
    {
        if (currentClip == 4)
        {
        PlayNext();
        Click.SetTrigger("Dissapear");
        ModifierCount.SetTrigger("Appear");
        }
    }

    public void ModifierExplanationDissapear()
    {
        if (currentClip == 5)
        {
        PlayNext();
        ModifierCount.SetTrigger("Dissapear");
        Modifier.SetTrigger("Appear");
        }
    }

    public void ModifierDissapear()
    {
        Modifier.SetTrigger("Dissapear");
        ClickButtonText.text = "Count += income";
        Skill.SetTrigger("Appear");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SkipTutorial()
    {
        Modifier.SetTrigger("Dissapear");
        Click.SetTrigger("Dissapear");
        Count.SetTrigger("Dissapear");
        ModifierCount.SetTrigger("Dissapear");
        ClickButtonText.text = "Count += income";
        Skill.SetTrigger("Appear");
    }
}
