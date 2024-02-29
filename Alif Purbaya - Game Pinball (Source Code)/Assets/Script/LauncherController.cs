using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
	public Collider bola; // referensi ke bola
	public KeyCode input; // tombol input untuk aktivasi launch
	public float maxTimeHold;
    public float maxforce; // besar gaya yang diberikan saat launch
    private bool isHold = false;
	
	// hanya dapat membaca input saat bersentuhan dengan bola saja
	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider == bola)
		{
			ReadInput(bola);
		}
	}
	
	// baca input
	private void ReadInput(Collider collider)
	{
		if (Input.GetKey(input))
		{
			// dorong bola ke atas dengan menggunakan gaya dorong dngn besaran tertentu
			
            StartCoroutine(StartHold(collider));
		}
	}

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxforce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
    }
}
