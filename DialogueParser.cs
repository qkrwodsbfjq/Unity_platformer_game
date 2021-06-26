using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{

    public Dialogue[] Parse(string _CSVFilieName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFilieName);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue();

            dialogue.name = row[1];

            List<string> contextList = new List<string>();
            //List<string> EventList = new List<string>();
            // List<string> SkipList = new List<string>();


            do
            {
                contextList.Add(row[2]);
                //EventList.Add(row[3]);
                //SkipList.Add(row[4]);
                Debug.Log(row[2]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (row[0].ToString() == "");
            /*
            dialogue.contexts = contextList.ToArray();
            //dialogue.number = EventList.ToArray();
            //dialogue.skipnum = SkipList.ToArray();

            dialogueList.Add(dialogue);

            //GameObject obj = GameObject.Find("DialogueManager");
            //obj.GetComponent<interactionEvent>().lineY = dialogueList.Count;
            */
        }

        return dialogueList.ToArray();
    }
    
    void Start()
    {
        Parse("dialogue");
    }
}