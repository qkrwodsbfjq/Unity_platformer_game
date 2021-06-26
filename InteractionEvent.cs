using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
/*
    public int lineY;
    public int s_lineY;
*/
    [SerializeField] DialogueEvent dialogue;
    //[SerializeField] SelectEvent select;

    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);//(1, lineY);
        return dialogue.dialogues;
    }
    /*
    public SelectDialogue[] GetSelectes()
    {
        select.Selecter = DatabaseManager.instance.GetSelects(1, s_lineY);
        return select.Selecter;
    }
  */
}