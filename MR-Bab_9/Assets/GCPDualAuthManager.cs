using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using System.Text;

public class GCPDualAuthManager : MonoBehaviour
{
    [Header("Vision API Settings (Standard API Key)")]
    [SerializeField] private string visionApiKey = "AIzaSyAQ8GxZjZXt6or5EHlh0rZ_znkQCLOBk3c";
    
    [Header("Vertex AI Settings (Service Account JSON)")]
    [SerializeField] private string jsonFileName = "Assets/StreamingAssets/gcp_key.json";

    // Struktur Data untuk Request Vision API
    [System.Serializable]
    public class VisionRequest { /* Struktur JSON Vision */ }

    public void StartOCRProcess(byte[] imageBytes)
    {
        StartCoroutine(RequestCloudVision(imageBytes));
    }

    // JALUR 1: Menggunakan API Key untuk Cloud Vision
    IEnumerator RequestCloudVision(byte[] imageBytes)
    {
        string url = $"https://vision.googleapis.com/v1/images:annotate?key={visionApiKey}";
        
        // Encode gambar ke Base64
        string base64Image = System.Convert.ToBase64String(imageBytes);
        string jsonRequest = "{ \"requests\": [ { \"image\": { \"content\": \"" + base64Image + "\" }, \"features\": [ { \"type\": \"TEXT_DETECTION\" } ] } ] }";

        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequest);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("OCR Berhasil: " + request.downloadHandler.text);
                // Lanjut ke Proses AI Gemini
                string hasilTeks = "Contoh_Kode_P882"; // Parsing dari JSON Vision disini
                StartCoroutine(RequestVertexAI(hasilTeks));
            }
            else {
                Debug.LogError("OCR Gagal: " + request.error);
            }
        }
    }

    // JALUR 2: Menggunakan Service Account untuk Vertex AI (Gemini)
    IEnumerator RequestVertexAI(string teksInput)
    {
        // Path ke file JSON di StreamingAssets
        string path = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        string keyJson = File.ReadAllText(path);

        // Catatan: Di produksi, kamu butuh Library Google Auth untuk menukar JSON menjadi Access Token.
        // Untuk Prototype: Kita kirim request ke Endpoint Vertex AI
        Debug.Log("Menghubungi Gemini AI untuk memproses kode: " + teksInput);
        
        // Simulasi integrasi Gemini
        yield return null; 
        Debug.Log("HUD Ready: Menampilkan data logistik di kacamata.");
    }
}