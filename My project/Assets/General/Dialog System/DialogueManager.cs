using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;

    public Animator dialogueBoxAnimator;

    [SerializeField] private Dialogue testDialogue;

    void Start()
    {
        sentences = new Queue<string>();

        StartDialogue(testDialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //dialogueBoxAnimator.SetBool("IsOpen", true); //Make dialogue box appear

        sentences.Clear();
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
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(2);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        // dialogueBoxAnimator.SetBool("IsOpen", false);
    }
}