using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Import this to quickly access Unity's UI classes
using VIDE_Data; //Import this to use VIDE Dialogue's VD class
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI label;
    public TextMeshProUGUI NPC_text; 
    public TextMeshProUGUI[] PLAYER_text;
    public KeyCode continueButton;
    public VIDE_Assign vIDE;

    private bool keyDown = false;

    private void Start () 
    {
        NPC_text.gameObject.SetActive(false);
        foreach (TextMeshProUGUI t in PLAYER_text)
            t.transform.parent.gameObject.SetActive(false);

        Begin(vIDE);
	}

    //Check if a dialogue is active and if we are NOT in a player node in order to continue
    private void Update()
    {
        if (VD.isActive)
        {
            if (!VD.nodeData.isPlayer && Input.GetKeyUp(continueButton))
            {
                if (keyDown)
                {
                    keyDown = false;
                } else
                {
                    VD.Next();
                }
            }
        } else
        {
            if (Input.GetKeyUp(continueButton))
            {
                Start();
            }
        }
    }

    private void Begin(VIDE_Assign dialogue)
    { 
        NPC_text.text = "";
        label.text = "";

        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;

        VD.BeginDialogue(dialogue);

        dialogueBox.SetActive(true);
    }

    public void SelectChoiceAndGoToNext(int playerChoice)
    {
        keyDown = true;
        VD.nodeData.commentIndex = playerChoice;
        VD.Next();
    }

	private void UpdateUI (VD.NodeData data)
    {
        WipeAll();

		if (!data.isPlayer)
        {
            NPC_text.gameObject.SetActive(true);
            NPC_text.text = data.comments[data.commentIndex];

            if (data.tag.Length > 0)
                label.text = data.tag;
            else
                label.text = VD.assigned.alias;
        } else
        {
            for (int i = 0; i < PLAYER_text.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    PLAYER_text[i].transform.parent.gameObject.SetActive(true);
                    PLAYER_text[i].text = data.comments[i];
                } else
                {
                    PLAYER_text[i].transform.parent.gameObject.SetActive(false);
                }

                PLAYER_text[0].transform.parent.GetComponent<Button>().Select();
            }
        }
	}

    private void WipeAll()
    {
        NPC_text.gameObject.SetActive(false);
        foreach (TextMeshProUGUI t in PLAYER_text)
            t.transform.parent.gameObject.SetActive(false);
    }

    private void End(VD.NodeData data)
    {
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        dialogueBox.SetActive(false);
        VD.EndDialogue(); //Third most important method when using VIDE     
        WipeAll();
    }

    //Just in case something happens to this script
    private void OnDisable()
    {
        VD.OnNodeChange -= UpdateUI;
        if(dialogueBox != null) dialogueBox.SetActive(false);
        VD.OnEnd -= End;
    }
}
