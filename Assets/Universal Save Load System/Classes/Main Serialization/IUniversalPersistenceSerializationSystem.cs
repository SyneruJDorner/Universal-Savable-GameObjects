using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUniversalSerializedPersistenceSystem
{
    List<UserDefinedData> Serialize(GameObject providedObject);

    void Deserialize(List<UserDefinedData> serializedMonoData, GameObject providedObject);

    void UniSave();

    void UniLoad();

    void SaveMessage();
}
