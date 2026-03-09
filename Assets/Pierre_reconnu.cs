using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class Pierre_reconnu : MonoBehaviour
{
    [SerializeField]
    private Light _lightBowl;

    [SerializeField]
    [Range(0, 6)]
    private int _numBasket;

    [SerializeField]
    private bool etat;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(this.tag))
        {
            _lightBowl.intensity = 0.1f;

            etat = true;

            EventManager.TriggerEvent("PIERRE_ETAT_CHANGE", new EventParamPierre(_numBasket, true));
        }
        else
        {
            etat = false;
        }

    }

    public void OnTriggerExit(Collider other)
    {

        _lightBowl.intensity = 0;

        etat = false;

        EventManager.TriggerEvent("PIERRE_ETAT_CHANGE", new EventParamPierre(_numBasket, false));
    }


    public class EventParamPierre : EventParam
    {
        public int numBasket;
        public bool etat;

        public EventParamPierre(int numBasket, bool etat)
        {
            this.numBasket = numBasket;
            this.etat = etat;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
