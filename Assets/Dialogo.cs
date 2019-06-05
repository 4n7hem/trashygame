using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public FalasNPC[] dialogo = new FalasNPC[2];

    private bool dialogoConcluido = false;

    DialogController dialogoController;

    // Start is called before the first frame update
    void Start()
    {
        dialogoController = FindObjectOfType<DialogController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerPlatformerController>().maxSpeed = 0;

            if (!dialogoConcluido)
            {
                dialogoController.ProximaFala(dialogo[0]);
            }
            else
            {
                dialogoController.ProximaFala(dialogo[1]);
            }

            dialogoConcluido = true;

        }

    }

}
