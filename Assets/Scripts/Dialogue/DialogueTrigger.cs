using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTree dialogue;

    // Called automatically by unity when a rigid body intersects a collider with "isTrigger" checked.
    public void OnTriggerEnter(Collider other){
        dialogueManager.StartDialog(dialogue);
    }
}
