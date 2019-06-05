using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject painelDeDialogo;
    public Text falaNPC;
    public GameObject resposta;
    private bool falaAtiva = false;

    FalasNPC falas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && falaAtiva)
        {

            if (falas.respostas.Length > 0)
            {

                MostrarResposta();

            }

            else {

                falaAtiva = false;
                painelDeDialogo.SetActive(false);
                falaNPC.gameObject.SetActive(false);
                FindObjectOfType<PlayerPlatformerController>().maxSpeed = 7;

            }

        }

    }

    void MostrarResposta() {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for (int i = 0; i < falas.respostas.Length; i++) {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<RespostasBtn>().Setup(falas.respostas[i]);
        }

    }

    public void ProximaFala(FalasNPC fala) {

        falas = fala;

        LimparResposta();

        falaAtiva = true;

        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);
        falaNPC.text = falas.fala;
    }

    void LimparResposta() {

        RespostasBtn[] buttons = FindObjectsOfType<RespostasBtn>();
        foreach(RespostasBtn button in buttons)
        {

            Destroy(button.gameObject);

        }

    }

}
