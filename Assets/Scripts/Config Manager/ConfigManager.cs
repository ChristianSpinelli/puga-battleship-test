using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    [Header("References")]
    public Dropdown cannonOptions, droneOptions;
    List<SecondaryCannonType> cannonTypes = new List<SecondaryCannonType>();
    List<DroneType> droneTypes = new List<DroneType>();

    [Header("Behavior")]
    SecondaryCannonType selectedCannon;
    DroneType selectedDrone;

    private void Awake()
    {
        ShipData data = GameDAO.LoadShipData();
        if (data != null)
        {
            selectedCannon = data.selectedCannon;
            selectedDrone = data.selectedDrone;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //initialize list of cannon types
        cannonTypes.Add(SecondaryCannonType.Angle0);
        cannonTypes.Add(SecondaryCannonType.Angle30);
        cannonTypes.Add(SecondaryCannonType.Angle75);
        cannonTypes.Add(SecondaryCannonType.Angle120);
        cannonTypes.Add(SecondaryCannonType.none);

        //initialize list of drone types
        droneTypes.Add(DroneType.Attack);
        droneTypes.Add(DroneType.Healer);
        droneTypes.Add(DroneType.Magnetic);
        droneTypes.Add(DroneType.Rocket);
        droneTypes.Add(DroneType.none);

        //create auxiliar variables
        List<Dropdown.OptionData> cannonList = new List<Dropdown.OptionData>();
        List<Dropdown.OptionData> droneList = new List<Dropdown.OptionData>();
        Dropdown.OptionData data;
        cannonOptions.ClearOptions();
        droneOptions.ClearOptions();

        //fill the dropdown option of cannon types
        foreach (SecondaryCannonType type in cannonTypes)
        {
            data = new Dropdown.OptionData();
            data.text = type.ToString();
            cannonList.Add(data);
        }
        cannonOptions.AddOptions(cannonList);

        //fill the dropdown option of drone types
        foreach (DroneType type in droneTypes)
        {
            data = new Dropdown.OptionData();
            data.text = type.ToString();
            droneList.Add(data);
        }
        droneOptions.AddOptions(droneList);

       
         //select the actual drone selected
         for (int i = 0; i < droneTypes.Count; i++)
            {
                if (droneTypes[i] == selectedDrone)
                {
                    droneOptions.value = i;
                    break;
                }
            }

        //select the actual cannon selected
        for (int i = 0; i < cannonTypes.Count; i++)
        {
            if (cannonTypes[i] == selectedCannon)
            {
                cannonOptions.value = i;
                break;
            }

        }

    }

    public void onConfirm()
    {
        selectedCannon = cannonTypes[cannonOptions.value];
        selectedDrone = droneTypes[droneOptions.value];

        ShipData data = new ShipData();
        data.selectedCannon = selectedCannon;
        data.selectedDrone = selectedDrone;

        GameDAO.SaveShipData(data);
    }
}
