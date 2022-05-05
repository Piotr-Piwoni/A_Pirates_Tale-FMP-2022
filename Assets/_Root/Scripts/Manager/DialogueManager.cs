using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VIDE_Data; //Import this to quickly access Unity's UI classes
//Import this to use VIDE Dialogue's VD class

namespace CultureFMP.Manager
{
    public class DialogueManager : MonoBehaviour
    {
        public GameObject dialogueBox;
        public GameObject playerButtonGroup;
        public GameObject playerChoiceUI;
        public TextMeshProUGUI textBox;
        public TextMeshProUGUI nameLabel;
        public VIDEDemoPlayer videPlayer;
        private bool _dialoguePaused;
        private bool _animatingText; 
        private List<Button> _currentChoices = new List<Button>();

        private IEnumerator _textAnimatorCO;
        private void Awake()
        {
           // VD.LoadDialogues(); //Load all dialogues to memory so that we dont spend time doing so later
            //An alternative to this can be preloading dialogues from the VIDE_Assign component!
            VD.LoadState("TestScene2", true);
        }

        //This begins the dialogue and progresses through it (Called by VIDEDemoPlayer.cs)
        public void Interact(VIDE_Assign _dialogue)
        {
            if (!VD.isActive)
            {
                Begin(_dialogue);
            } else
            {
                CallNext();
            }      
        }

        private void Begin(VIDE_Assign _dialogue)
        {
            textBox.text = "";
            nameLabel.text = "";

            VD.OnActionNode += ActionHandler;
            VD.OnNodeChange += UpdateUI;
            VD.OnEnd += EndDialogue;

            VD.BeginDialogue(_dialogue);

            dialogueBox.SetActive(true);
        }

        private void CallNext()
        {
            if (_animatingText) { CutTextAnim(); return; }

            if (!_dialoguePaused)
            {       
                VD.Next();
            }  
        }
        
        void Update()
        {
            var _data = VD.nodeData;

            if (VD.isActive)
            {
                if (_data.isPlayer)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        if (_data.commentIndex < _currentChoices.Count - 1)
                            _data.commentIndex++;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (_data.commentIndex > 0)
                            _data.commentIndex--;
                    }
                    
                    for (int i = 0; i < _currentChoices.Count; i++)
                    {   
                        _currentChoices[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
                        if (i == _data.commentIndex)
                            _currentChoices[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
                    }
                }
            }
        }
        
        private void UpdateUI(VD.NodeData _data)
        {
            foreach (Button _op in _currentChoices)
                Destroy(_op.gameObject);
            _currentChoices = new List<Button>();
            textBox.text = "";

            PostConditions(_data);

            //If this new Node is a Player Node, set the player choices offered by the node
            if (_data.isPlayer)
            {
                SetOptions(_data.comments);

                //If it has a tag, show it, otherwise let's use the alias we set in the VIDE Assign
                nameLabel.text = _data.tag.Length > 0 ? _data.tag : videPlayer.playerName;
            }
            else
            {

                //This coroutine animates the NPC text instead of displaying it all at once
                _textAnimatorCO = DrawTextCO(_data.comments[_data.commentIndex], 0.02f);
                StartCoroutine(_textAnimatorCO);

                //If it has a tag, show it, otherwise let's use the alias we set in the VIDE Assign
                if (_data.tag.Length > 0)
                    nameLabel.text = _data.tag;
                else
                    nameLabel.text = VD.assigned.alias;
            }
        }

        //This uses the returned string[] from nodeData.comments to create the UIs for each comment
        private void SetOptions(string[] _choices)
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                GameObject _newOp = Instantiate(playerChoiceUI, playerChoiceUI.transform.position, Quaternion.identity, playerButtonGroup.transform) as GameObject;
                _newOp.transform.SetParent(playerButtonGroup.transform.parent, true);
                _newOp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 20 - (20 * i));
                _newOp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                _newOp.GetComponentInChildren<TextMeshProUGUI>().text = _choices[i];
                _newOp.SetActive(true);

                _currentChoices.Add(_newOp.GetComponent<Button>()); 
            }
        }

        private void EndDialogue(VD.NodeData _data)
        {
            VD.OnActionNode -= ActionHandler;
            VD.OnNodeChange -= UpdateUI;
            VD.OnEnd -= EndDialogue;
            dialogueBox.SetActive(false);
            VD.EndDialogue();

            VD.SaveState("TestScene2", true);
        }

        void OnDisable()
        {
            VD.OnActionNode -= ActionHandler;
            VD.OnNodeChange -= UpdateUI;
            VD.OnEnd -= EndDialogue;
            if (dialogueBox != null) 
                dialogueBox.SetActive(false);
            VD.EndDialogue();
        }

        private void PostConditions(VD.NodeData _data)
        {
            if (_data.pausedAction) return;

            if (!_data.isPlayer)
            {
                if (_data.extraData[_data.commentIndex].Contains("fs"))
                {
                    string[] _fontSize = _data.extraData[_data.commentIndex].Split(","[0]);
                    int.TryParse(_fontSize[1], out var _fSize);
                    textBox.fontSize = _fSize;
                }
                else
                {
                    textBox.fontSize = 36;
                }
            }
        }

        private void OnLoadedAction()
        {
            Debug.Log("Finished loading all dialogues");
            VD.OnLoaded -= OnLoadedAction;
        }

        //Another way to handle Action Nodes is to listen to the OnActionNode event, which sends the ID of the action node
        void ActionHandler(int _actionNodeID)
        {
            //Debug.Log("ACTION TRIGGERED: " + actionNodeID.ToString());
        }

        private IEnumerator DrawTextCO(string text, float time)
        {
            _animatingText = true;

            string[] _words = text.Split(' ');

            for (int i = 0; i < _words.Length; i++)
            {
                string _word = _words[i];
                if (i != _words.Length - 1) _word += " ";

                string _previousText = textBox.text;

                float _lastHeight = textBox.preferredHeight;
                textBox.text += _word;
                if (textBox.preferredHeight > _lastHeight)
                {
                    _previousText += System.Environment.NewLine;
                }

                for (int j = 0; j < _word.Length; j++)
                {
                    textBox.text = _previousText + _word.Substring(0, j + 1);
                    yield return new WaitForSeconds(time);
                }
            }
            textBox.text = text;
            _animatingText = false;
        }

        private void CutTextAnim()
        {
            StopCoroutine(_textAnimatorCO);
            textBox.text = VD.nodeData.comments[VD.nodeData.commentIndex];	
            _animatingText = false;
        }
    }
}
