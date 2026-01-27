using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events; 

public class HandManager : MonoBehaviour
{
    private InputDevice mainDevice;
    [SerializeField]
    InputDeviceCharacteristics controllerCharacteristics;
	public GameObject cube;
	public GameObject bras;
	bool primaryButtonValue;
	Vector2 primary2Daxisout;
	bool isActive = false;
	bool isPressed = false;
    private float lastShootTime = -Mathf.Infinity;


    List<InputDevice> devicesList = new List<InputDevice>();

	// Start is called before the first frame update
	void Start()
    {

        StartCoroutine(getDevice());
		cube.SetActive(isActive);

	}

    // Update is called once per frame
    void Update()
    {
        /*if (mainDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryButtonValue) && primaryButtonValue)
        {
			if (isPressed == false)
			{
				isPressed = true;
				isActive = !isActive;
				cube.SetActive(isActive);
			}
        }
		else
		{
			isPressed = false;
		}*/

        if (mainDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2Daxisout))
		{
			bras.transform.Rotate(primary2Daxisout.y, 0, 0);
		}

    }

    IEnumerator getDevice()
    {
		while (devicesList.Count == 0)
        {
			InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devicesList);
			foreach (InputDevice inputItem in devicesList)
			{
				Debug.Log($"{inputItem.name} : {inputItem.characteristics}");
			}

			if (devicesList.Count > 0)
			{
				mainDevice = devicesList[0];
			}
			yield return true;
		}
	}
}
