using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespostasBtn : MonoBehaviour
{

    RespostasNPC respostaData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProximaFala()
    {
        FindObjectOfType<DialogController>().ProximaFala(respostaData.proxFala);
    }

    public void Setup(RespostasNPC resposta) {

        respostaData = resposta;

    }


}
