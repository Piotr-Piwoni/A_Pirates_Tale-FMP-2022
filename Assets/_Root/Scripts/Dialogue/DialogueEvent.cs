using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CultureFMP.Dialogue
{
    public class DialogueEvent : MonoBehaviour
    {
         public int idNumber;
         public string dialogueName;
        public VIDE_Assign videAssign;
        public bool colleted;
        private void OnTriggerEnter(Collider _other)
        {
            if (_other.CompareTag("Player"))
            {
                MoveDialogue();
            }
        }

        public void MoveDialogue()
        {
            videAssign.overrideStartNode = idNumber;
        }

        public void ChangeDialogue()
        {
            videAssign.assignedDialogue = dialogueName;
        }

        public void Collected()
        {
            if (colleted)
            {
                videAssign.overrideStartNode = idNumber;
            }
        }

        
    }
}
