using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseChar : MonoBehaviour
{
    public Button Shooter, Knifer;
    public GameObject NextPlayer;
    GameObject[] gos;
    // Use this for initialization
    void Start()
    {
            FindNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (NextPlayer == null)
        {
            //  FindNext();
            gos = null;
            //探す種類
            if (Shooter.interactable)
                gos = GameObject.FindGameObjectsWithTag("Knifer");
            else if (Knifer.interactable)
                gos = GameObject.FindGameObjectsWithTag("Shooter");

            if (gos.Length > 0)
            {
                for (int i = 0; i < gos.Length; i++)
                {
                    if (gos[i].GetComponent<PersonalPro>().stateInfo.IsName("Idle"))
                    {
                        NextPlayer = gos[i];
                        NextPlayer.GetComponent<PlayerMove>().enabled = true;
                        break;
                    }

                }
            }

        }
        else
        {
            NextPlayer.GetComponent<PlayerMove>().enabled = true;
            if (NextPlayer.GetComponent<PlayerMove>().stateInfo.IsName("Idle") == false)
            {
                NextPlayer = null;
            }
        }

    }
    void FindNext()
    {
        gos = null;
        //探す種類
        if (Shooter.interactable)
            gos = GameObject.FindGameObjectsWithTag("Knifer");
        else if (Knifer.interactable)
            gos = GameObject.FindGameObjectsWithTag("Shooter");

        for (int i = 0; i < gos.Length; i++)
        {
            if (gos[i].GetComponent<PersonalPro>().stateInfo.IsName("Idle"))
            {
               NextPlayer = gos[i];
               NextPlayer.GetComponent<PlayerMove>().enabled = true;
                break;
            }

        }
    }
}
