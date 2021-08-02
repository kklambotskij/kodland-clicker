using TMPro;
using UnityEngine;

public class PythonCode : MonoBehaviour
{
    [SerializeField] GameObject CodeWallpaper;
    [SerializeField] TextMeshProUGUI codeText;

    public string GetCode()
    {
        return code;
    }

    public void AddLine(string line)
    {
        code = string.Concat(code, line, '\n');
        print(line);
    }

    public void CodeAppearer()
    {
        codeText.text = code;
        CodeWallpaper.SetActive(true);
    }
    
    public void CodeDissapear()
    {
        CodeWallpaper.SetActive(false);
    }

    private string code = @"
import turtle
t = turtle.Turtle()
t.shape('turtle')

t.up()
t.speed(100)
t.left(180)
t.forward(200)
t.right(90)
t.forward(100)
t.down()
t.right(90)
t.forward(200)
t.right(90)
t.forward(200)
t.right(90)
t.forward(80)
t.up()
t.forward(40)
t.down()
t.forward(80)
t.right(90)
t.forward(200)
t.right(90)
t.up()
t.forward(40)
t.right(90)
t.forward(40)
t.down()
t.forward(120)
t.left(90)
t.forward(120)
t.left(90)
t.forward(120)
t.left(90)
t.forward(40)
t.up()
t.forward(40)
t.down()
t.forward(40)
t.up()
t.left(90)
t.forward(40)
t.left(90)
t.forward(40)
t.down()
t.forward(40)
t.right(90)
t.forward(40)
t.right(90)
t.up()
t.forward(40)
t.down()
t.right(90)
t.forward(40)
t.up()
t.right(90)
t.forward(20)
t.right(90)
t.forward(20)
t.down()
t.color('red')
t.speed(10)
#Код:

";
}
