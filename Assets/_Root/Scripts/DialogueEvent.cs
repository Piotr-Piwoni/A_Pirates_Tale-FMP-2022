using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CultureFMP
{
    public class DialogueEvent : MonoBehaviour
    {
         public int idNumber;
        public VIDE_Assign videAssign;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                MoveDialogue();
            }
        }

        public void MoveDialogue()
        {
            videAssign.overrideStartNode = idNumber;
        }
    }
}
