using UnityEngine;
using VRStandardAssets.Utils;
using System.Linq;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class TravelerInteraction : MonoBehaviour
    {
        public VRInteractiveItem m_InteractiveItem;
        public Shader m_Highlight;
        public TravelManager m_TravelManager;
        public Canvas m_Dialog;
        private Shader standardShader;
        private bool isDialogShowing;


        private void Awake ()
        {
            //m_Renderer.material = m_NormalMaterial;
            standardShader = Shader.Find("Standard (Specular setup)");
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");
            //change the shader of the traveler
            var renderer = this.gameObject.GetComponentInChildren<Renderer>();
            renderer.material.shader = m_Highlight;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            var renderer = this.gameObject.GetComponentInChildren<Renderer>();
            renderer.material.shader = standardShader;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            if (!isDialogShowing)
            {
                var textComponent = m_Dialog.gameObject.GetComponentInChildren(typeof(UnityEngine.UI.Text)) as UnityEngine.UI.Text;
                var travelerInfo = m_TravelManager.TravelerList.SingleOrDefault(x => x.Name == this.gameObject.name);
                textComponent.text = travelerInfo.Name + "\n" + travelerInfo.Title;
                m_Dialog.gameObject.SetActive(true);                
                isDialogShowing = true;
            }
            else
            {
                m_Dialog.gameObject.SetActive(false);
                isDialogShowing = false;
            }
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            //m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}