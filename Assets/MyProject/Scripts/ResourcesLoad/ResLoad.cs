// Loading assets from the Resources folder using the generic Resources.Load<T>(path) method
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResLoad : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBox;
    void Start()
    {
        //Load a text file (Assets/Resources/Text/textFile01.txt)
        var textFile = Resources.Load<TextAsset>("Text/textFile01");

        ////Load text from a JSON file (Assets/Resources/Text/jsonFile01.json)
        //var jsonTextFile = Resources.Load<TextAsset>("Text/jsonFile01");
        ////Then use JsonUtility.FromJson<T>() to deserialize jsonTextFile into an object

        ////Load a Texture (Assets/Resources/Textures/texture01.png)
        //var texture = Resources.Load<Texture2D>("Textures/texture01");

        ////Load a Sprite (Assets/Resources/Sprites/sprite01.png)
        //var sprite = Resources.Load<Sprite>("Sprites/sprite01");

        ////Load an AudioClip (Assets/Resources/Audio/audioClip01.mp3)
        //var audioClip = Resources.Load<AudioClip>("Audio/audioClip01");

        _textBox.text = textFile.text;
    }
    public void ReadFile()
    {

        _textBox.text = Resources.Load<TextAsset>("Text/textFile02").text;
    }
}
