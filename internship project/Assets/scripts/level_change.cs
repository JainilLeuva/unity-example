using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_change : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(changescene());
        }
    }

    IEnumerator changescene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("stage 2");
    }
}
