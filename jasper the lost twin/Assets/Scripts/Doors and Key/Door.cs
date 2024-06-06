using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    private PlayerScript thePlayer;

    public SpriteRenderer theSR;

	public Sprite doorOpenSprite;

	public bool doorOpen, waitingToOpen;
    
	[SerializeField]
	public SceneField sceneToLoad;
	[SerializeField]
	public SceneField[] scenesToUnLoad;
	[SerializeField]
	public Vector3 targetPosition; 

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);

	            thePlayer.followingKey = null;
                
	            StartCoroutine(TransitionToNewScene());	            
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
    
	private IEnumerator TransitionToNewScene()
	{
		yield return StartCoroutine(SceneTransition.instance.FadeOut());
		// Load the new scene
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
		UnloadScenes();
		
		// Wait until the new scene is fully loaded
		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		thePlayer.transform.position = targetPosition;
		yield return StartCoroutine(SceneTransition.instance.FadeIn());
	}
	
	private void UnloadScenes()
	{
		foreach (SceneField scene in scenesToUnLoad)
		{
			UnloadSceneAsync(scene);
		}
	}
	
	private void UnloadSceneAsync(SceneField scene)
	{
		SceneManager.UnloadSceneAsync(scene);
	}

}
