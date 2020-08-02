using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameDAO : MonoBehaviour
{
    public static void SaveCurrencyData(CurrencyData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/currencyData.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CurrencyData LoadCurrencyData()
    {
        CurrencyData data = new CurrencyData();
        string path = Application.persistentDataPath + "/currencyData.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = formatter.Deserialize(stream) as CurrencyData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }


    public static void SaveShipData(ShipData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shipData.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShipData LoadShipData()
    {
        ShipData data = new ShipData();
        string path = Application.persistentDataPath + "/shipData.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = formatter.Deserialize(stream) as ShipData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }


}
