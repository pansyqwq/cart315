using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 1f;
    private MeshRenderer meshRenderer; //MeshRenderer: A Unity component responsible for rendering a mesh using materials.
    //meshRenderer: The variable that will store a reference to that component.

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();//Find the MeshRenderer component attached to the same GameObject as this script.
													//and then Stores that component in your meshRenderer variable.
    }

    private void Update()//Update() runs once every frame.
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);//This accesses the material used by your MeshRenderer.
        //texturee offset = Instead of moving the entire GameObject, Unity changes which part of the texture is displayed on its surface.
        //Time.deltaTime represents the amount of time (in seconds) between the previous frame and the current frame.
		//With Time.deltaTime, the movement is based on elapsed time instead of frame count.
    }

}
