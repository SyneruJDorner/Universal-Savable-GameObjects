using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUniversalSerializedPersistenceSystem
{
    List<UserDefinedData> Serialize();

    void Deserialize(List<UserDefinedData> data);

    void UniSave();

    void UniLoad();

    void SaveMessage();
}
