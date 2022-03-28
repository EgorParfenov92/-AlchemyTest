using System;
using UnityEngine;

class Element : MonoBehaviour, IElement
{
    [SerializeField]
    private Substance substance;
    [SerializeField]
    private ElementType type;
    [SerializeField]
    private Material materialFail;
    public Action<Element> Trigger { get; set; }
    public bool Bad
    {
        get => bad;
        set
        {
            if (value == bad)
                return;
            if (value)
            {
                meshRenderer.material = materialFail;
            }
            else
            {
                meshRenderer.material = material;
            }
            bad = value;
        }
    }
    public Substance Substance => substance;
    public ElementType ElementType => type;

    private bool bad = false;
    private Material material;
    private MeshRenderer meshRenderer;
    public void Hide()
    {
        if (transform.parent != null)
        {
            transform.parent.GetComponent<ElementObserverEventHandler>().Hide();
        }
        else
        {
            del();
        }
    }
    private void del()
    {
        Destroy(this.gameObject);
    }
    private void Start()
    {
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }
    private void OnTriggerEnter(Collider other)
    {
        Element e = other.GetComponent<Element>();
        if(e != null)
        {
            Trigger?.Invoke(e);
        }
    }
}
