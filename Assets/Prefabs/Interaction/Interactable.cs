using UnityEngine;

public class Interactable : MonoBehaviour
{
    ///
    /// Event Driven Interaction System
    /// 
    /// 

    #region Properties
    #endregion

    #region Constructors
    #endregion

    #region Unity Methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Methods
    public void Touch()
    {
        Debug.Log("Interacting with " + gameObject.name);
        // Add your interaction logic here
    }
    #endregion

    #region Events and Delegates
    #endregion
}
