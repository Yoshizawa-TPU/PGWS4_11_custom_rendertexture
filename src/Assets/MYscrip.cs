using UnityEngine;
using UnityEngine.EventSystems;

public class MYscrip : MonoBehaviour
{

    [SerializeField] CustomRenderTexture texField = default!;
    [SerializeField] CustomRenderTexture texColor = default!;
    [SerializeField] Material m_Material = default!;
    float intensity = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texField.Initialize();
        texColor.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        m_Material.SetFloat("_intensity", intensity);
        intensity = 0.0f;
    }

    public void OnDrag(BaseEventData e)
    {
        RectTransform rt = transform as RectTransform;
        Vector2 lp;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, (e as PointerEventData).position, null, out lp))
        {
            Vector2 cood = lp / rt.rect.size + rt.pivot;
            m_Material.SetVector("_Position", new Vector4(cood.x, cood.y, 0, 0));
            intensity = -0.0001f;



        }
    }
}
