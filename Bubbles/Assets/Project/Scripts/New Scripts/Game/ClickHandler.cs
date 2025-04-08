using UnityEngine;

namespace NewScripts
{
    public class ClickHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    IClickable clickable = hit.collider.GetComponent<IClickable>();
                    if (clickable != null)
                    {
                        clickable.OnClick();
                    }
                }
            }
        }
    }
}