using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private Dictionary<string, string> dialogueDictionary = new Dictionary<string, string>();

    void Start()
    {
        LoadDialoguesFromJSON();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ClearDialogue();
        }
    }

    void LoadDialoguesFromJSON()
    {
        string jsonString = Resources.Load<TextAsset>("Dialogue/dialogue").text;
        DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(jsonString);
        foreach (Dialogue dialogue in dialogueData.dialogues)
        {
            dialogueDictionary.Add(dialogue.id, dialogue.content);
        }
    }

    public void DisplayDialogue(string dialogueID)
    {
        if (dialogueDictionary.ContainsKey(dialogueID))
        {
            dialogueText.text = dialogueDictionary[dialogueID];
        }
    }

    public void ClearDialogue()
    {
        dialogueText.text = string.Empty;
    }
}

[System.Serializable]
public class DialogueData
{
    public List<Dialogue> dialogues;
}

[System.Serializable]
public class Dialogue
{
    public string id;
    public string content;
}
