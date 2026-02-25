using UnityEngine;
using UnityEngine.Audio;

public class Choix_déplacement_chariot : MonoBehaviour
{
    [SerializeField]
    private HingeJoint hinge;

    [SerializeField]
    private Animator direction_chariot;




    int anim_a_faire = 3;
    //bool aller = true;
    int APPUI = 0;
    float TIMER = 0;



    void Update()
    {
    TIMER += Time.deltaTime;
    float angle = hinge.angle; // angle actuel du levier    

        if (angle > 20)
        {
            anim_a_faire = 2;
        }
        else if (angle < -20)
        {
            anim_a_faire = 1;
        }
        else
        {
            anim_a_faire = 3;
        }
    }

    public void PlaySelectedAnimation()
    {
        Debug.Log("Timer : " +  TIMER);
        Debug.Log("APPUI :" + APPUI); 
        if (TIMER > 17)
        {
            Debug.Log("APPUI incremente : ");
            APPUI++;
            if (APPUI == 1)
            {
                Debug.Log("Avance, "); 
                switch (anim_a_faire)
                {
                    case 1:
                        direction_chariot.SetTrigger("Gauche");
                        Debug.Log("Gauche ! \n"); 
                        //aller = false;
                        break;
                    case 2:
                        direction_chariot.SetTrigger("Droite");
                        //AudioSource.PlayClipAtPoint(son_minecart, direction_chariot.transform.position);
                        Debug.Log("Droite ! \n"); 
                        //aller = false;
                        break;
                    case 3:
                        direction_chariot.SetTrigger("Tout_droit");
                        //AudioSource.PlayClipAtPoint(son_minecart, direction_chariot.transform.position);
                        Debug.Log("Centre !\n"); 
                        //aller = false;
                        break;
                }
                Debug.Log("Sortie du switch");
            }
            else if (APPUI == 2) {
                Debug.Log("Recule ! \n"); 
                direction_chariot.SetTrigger("Retour");
                //AudioSource.PlayClipAtPoint(son_minecart, direction_chariot.transform.position);
                //aller = true;
                APPUI = 0; 
            Debug.Log("Sortie du Appui 2 ");

            }
             TIMER = 0;
        } 
    }
}
