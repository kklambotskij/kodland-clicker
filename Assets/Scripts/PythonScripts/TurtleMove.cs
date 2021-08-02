using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtleMove : MonoBehaviour
{
    [SerializeField] RectTransform turtle;
    [SerializeField] PythonCode pyCode;
    private Vector3 startPosition;
    private Quaternion startRotation;
    string text;
    //150 unity = 40 turtle
    private void Start()
    {
        startPosition = turtle.anchoredPosition;
        startRotation = turtle.transform.rotation;
    }
    public void ForwardButton()
    {
        Vector2 pos = turtle.right * 170;
        turtle.anchoredPosition += new Vector2(pos.x, pos.y);
        pyCode.AddLine("t.forward(40)");
    }

    public void LeftButton()
    {
        turtle.transform.Rotate(new Vector3(0, 0, 90));
        pyCode.AddLine("t.left(90)");
    }

    public void RightButton()
    {
        turtle.transform.Rotate(new Vector3(0, 0, -90));
        pyCode.AddLine("t.right(90)");
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(0);
        //turtle.anchoredPosition = startPosition;
        //turtle.transform.rotation = startRotation;
    }

        void OnCollisionStay2D(Collision2D other)
    {
        SceneManager.LoadScene(1);
    }
}
