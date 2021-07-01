using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameAnswerNode : MonoBehaviour
{
    [SerializeField] public GameObject currentObject;

    [SerializeField] public float objectRegenTimer = 0.5f;

    MinigameController myMinigameController;
    MinigameFirstNode myMinigameFirstNode;
    MinigameLaneController myMinigameLaneController;

    private void Awake()
    {
        myMinigameController = FindObjectOfType<MinigameController>();
        myMinigameFirstNode = FindObjectOfType<MinigameFirstNode>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentObject == null)
        {
            StartCoroutine(RegenDelay(objectRegenTimer));
        }
        else
        {

        }
    }

    public IEnumerator RegenDelay(float timer)
    {
        myMinigameController.CallNextMove();
        yield return new WaitForSeconds(timer);
    }
}
