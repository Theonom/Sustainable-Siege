using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ShareController : MonoBehaviour
{
    public Text sumZombie, sumTrash;

    private string message;

    private void Start()
    {
        sumZombie.text = StateText.sumZombie;
        sumTrash.text = StateText.sumTrash;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Share()
    {
        message = "Saya berhasil membunuh " + StateText.sumZombie + " Zombie, dan saya berhasil mengumpulkan " + StateText.sumTrash + " Sampah. Aya bermain game Sustainable Sieg: Trash Tactic";
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "Share image.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);
    }
}
