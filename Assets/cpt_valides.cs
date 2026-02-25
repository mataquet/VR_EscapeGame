using UnityEngine;
using static Pierre_reconnu;

public class cpt_valides : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool[] tab_valide = new bool[7];

    [SerializeField]
    private Animator ouverture_porte;

    void OnEnable()
    {
        EventManager.StartListening("PIERRE_ETAT_CHANGE", OnPierreEtatChange);
    }

    void OnDisable()
    {
        EventManager.StopListening("PIERRE_ETAT_CHANGE", OnPierreEtatChange);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnPierreEtatChange(EventParam param)
    {
        EventParamPierre pierreParam = param as EventParamPierre;

        tab_valide[pierreParam.numBasket] = pierreParam.etat;

        for (int i = 0; i < 7; i++)
        {
            if (tab_valide[i] == false)
            {
                //Debug.Log("tableau non comlpété");
                return;
            }

        }
        Debug.Log("tableau comlpété");
        ouverture_porte.enabled = true;
        ouverture_porte.SetTrigger("ouverture");

    }
}

