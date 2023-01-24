using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Resources;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI BarText;
    public TextMeshProUGUI BarName;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    // Start is called before the first frame update
    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        BarName.text = currentScene.sentences[sentenceIndex].speaker.SpeakerName;
        BarName.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool isCompleted()
    {
        return state == State.COMPLETED;
    }

    private IEnumerator TypeText(string text )
    {
        BarText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            BarText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
