using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VIDE_Data; //Import this to quickly access Unity's UI classes
//Import this to use VIDE Dialogue's VD class

namespace CultureFMP.Manager
{
    public class UIManager : MonoBehaviour
    {
        public GameObject dialogueBox;
        public TextMeshProUGUI label;
        public TextMeshProUGUI npcText; 
        public TextMeshProUGUI[] playerText;
        public KeyCode continueButton;

        private bool _keyDown = false;

        private void Start () 
        {
            npcText.gameObject.SetActive(false);
            foreach (TextMeshProUGUI t in playerText)
                t.transform.parent.gameObject.SetActive(false);
        }

        //Check if a dialogue is active and if we are NOT in a player node in order to continue
        private void Update()
        {
            if (VD.isActive)
            {
                if (!VD.nodeData.isPlayer && Input.GetKeyUp(continueButton))
                {
                    if (_keyDown)
                    {
                        _keyDown = false;
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

        public void Begin(VIDE_Assign dialogue)
        { 
            npcText.text = "";
            label.text = "";

            VD.OnNodeChange += UpdateUI;
            VD.OnEnd += End;

            VD.BeginDialogue(dialogue);

            dialogueBox.SetActive(true);
        }

        public void SelectChoiceAndGoToNext(int playerChoice)
        {
            _keyDown = true;
            VD.nodeData.commentIndex = playerChoice;
            VD.Next();
        }

        private void UpdateUI (VD.NodeData data)
        {
            WipeAll();

            if (!data.isPlayer)
            {
                npcText.gameObject.SetActive(true);
                npcText.text = data.comments[data.commentIndex];

                if (data.tag.Length > 0)
                    label.text = data.tag;
                else
                    label.text = VD.assigned.alias;
            } else
            {
                for (int i = 0; i < playerText.Length; i++)
                {
                    if (i < data.comments.Length)
                    {
                        playerText[i].transform.parent.gameObject.SetActive(true);
                        playerText[i].text = data.comments[i];
                    } else
                    {
                        playerText[i].transform.parent.gameObject.SetActive(false);
                    }

                    playerText[0].transform.parent.GetComponent<Button>().Select();
                }
            }
        }

        private void WipeAll()
        {
            npcText.gameObject.SetActive(false);
            foreach (TextMeshProUGUI t in playerText)
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
}
