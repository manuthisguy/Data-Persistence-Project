using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class UIScript : MonoBehaviour
{
    private TextMeshProUGUI typingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        typingText = GameObject.Find("TypingText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        if(typingText.text != null)
        {
            GameManager.instance.playerName = typingText.text;
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        GameManager.instance.SaveScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
