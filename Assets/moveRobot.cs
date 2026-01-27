using UnityEngine;

public class moveRobot : MonoBehaviour
{

    public Animator robot_animation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnHoverEntered()
    {
        robot_animation.SetTrigger("Start");
    }

    public void Stop_Robot()
    {
        robot_animation.SetTrigger("Stop");
    }
}
