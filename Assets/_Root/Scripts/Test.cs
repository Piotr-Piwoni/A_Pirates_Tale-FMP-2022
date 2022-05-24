using CultureFMP.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP
{
    public class Test : MonoBehaviour
    {
        public DialogueEvent dialogueEvent;
        public Transform tpLocation;

        private void Update()
        {
            if (transform.position == tpLocation.position)
            {
                dialogueEvent.colleted = true;
                dialogueEvent.ChangeDialogue();
            }
        }

    }
}
