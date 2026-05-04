// AnchorModuleScript.cs — STUB VERSION (tanpa Azure SDK)
// Digunakan untuk build Bab 9 (Multiplayer + TableAnchor) tanpa install Azure Spatial Anchors
// Semua method Azure dikosongkan tapi tetap ada agar referensi dari script lain tidak error
// Original: MRTK.Tutorials.AzureSpatialAnchors

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

#if WINDOWS_UWP
using Windows.Storage;
#endif

public class AnchorModuleScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The unique identifier used to identify the shared file (containing the Azure anchor ID) on the web server.")]
    private string publicSharingPin = "1982734901747";

    [HideInInspector]
    public string currentAzureAnchorID = "";

    // ----------------------------------------------------------
    // STUB: Azure session methods — dikosongkan, tidak melakukan apapun
    // ----------------------------------------------------------

    void Start() { }
    void Update() { }
    void OnDestroy() { }

    public void StartAzureSession()
    {
        Debug.Log("[STUB] StartAzureSession: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void StopAzureSession()
    {
        Debug.Log("[STUB] StopAzureSession: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void CreateAzureAnchor(GameObject theObject)
    {
        Debug.Log("[STUB] CreateAzureAnchor: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void RemoveLocalAnchor(GameObject theObject)
    {
        Debug.Log("[STUB] RemoveLocalAnchor: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void FindAzureAnchor(string id = "")
    {
        Debug.Log("[STUB] FindAzureAnchor: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void DeleteAzureAnchor()
    {
        Debug.Log("[STUB] DeleteAzureAnchor: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void SaveAzureAnchorIdToDisk()
    {
        Debug.Log("[STUB] SaveAzureAnchorIdToDisk: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void GetAzureAnchorIdFromDisk()
    {
        Debug.Log("[STUB] GetAzureAnchorIdFromDisk: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void ShareAzureAnchorIdToNetwork()
    {
        Debug.Log("[STUB] ShareAzureAnchorIdToNetwork: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    public void GetAzureAnchorIdFromNetwork()
    {
        Debug.Log("[STUB] GetAzureAnchorIdFromNetwork: Azure SDK tidak terinstall. Method ini dikosongkan.");
    }

    // ----------------------------------------------------------
    // Events tetap ada agar script lain yang subscribe tidak error
    // ----------------------------------------------------------

    public delegate void StartASASessionDelegate();
    public event StartASASessionDelegate OnStartASASession;

    public delegate void EndASASessionDelegate();
    public event EndASASessionDelegate OnEndASASession;

    public delegate void CreateAnchorDelegate();
    public event CreateAnchorDelegate OnCreateAnchorStarted;
    public event CreateAnchorDelegate OnCreateAnchorSucceeded;
    public event CreateAnchorDelegate OnCreateAnchorFailed;

    public delegate void CreateLocalAnchorDelegate();
    public event CreateLocalAnchorDelegate OnCreateLocalAnchor;

    public delegate void RemoveLocalAnchorDelegate();
    public event RemoveLocalAnchorDelegate OnRemoveLocalAnchor;

    public delegate void FindAnchorDelegate();
    public event FindAnchorDelegate OnFindASAAnchor;

    public delegate void AnchorLocatedDelegate();
    public event AnchorLocatedDelegate OnASAAnchorLocated;

    public delegate void DeleteASAAnchorDelegate();
    public event DeleteASAAnchorDelegate OnDeleteASAAnchor;
}
