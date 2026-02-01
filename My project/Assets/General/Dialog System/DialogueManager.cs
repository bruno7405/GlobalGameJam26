using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using System;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;

    public Animator dialogueBoxAnimator;

    public static DialogueManager Instance;

    [SerializeField] Color[] colors = new Color[8]; // Red, green, blue, pink, purple, yellow, orange, silver

    public event Action onDialogFinished;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //dialogueBoxAnimator.SetBool("IsOpen", true); //Make dialogue box appear

        sentences.Clear();
        StopAllCoroutines();
        foreach (string sentence in dialogue.sentences) sentences.Enqueue(sentence);
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentences.Count == 0) //reach the end of queue
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        int charsPerSfx = 4;
        int counter = 0;
        dialogueText.text = "";

        // read color of sentence
        int i = 1;
        char c = sentence[i];
        string color = "";
        while (c != ']')
        {
            color += c;
            c = sentence[++i];
        }

        Debug.Log(color);
        color = color.ToLower();
        switch (color)
        {
            case "red":
                dialogueText.color = colors[0];
                break;
            case "green":
                dialogueText.color = colors[1];
                break;
            case "blue":
                dialogueText.color = colors[2];
                break;
            case "pink":
                dialogueText.color = colors[3];
                break;
            case "purple":
                dialogueText.color = colors[4];
                break;
            case "yellow":
                dialogueText.color = colors[5];
                break;
            case "orange":
                dialogueText.color = colors[6];
                break;
            case "silver":
                dialogueText.color = colors[7];
                break;
            default:
                dialogueText.color = Color.ghostWhite;
                break;
        }

        sentence = sentence.Substring(i + 1);

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            counter++;
            if (counter == charsPerSfx)
            {
                AudioManager.instance.PlayOneShot("boop", 0.05f);
                counter = 0;
            }
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1.75f);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        dialogueText.text = "";
        onDialogFinished?.Invoke();
    }
}