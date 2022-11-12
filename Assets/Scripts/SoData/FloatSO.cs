
using UnityEngine;



    [CreateAssetMenu(fileName = "Stored Data", menuName = "Stored Data", order = 1)]

    public class FloatSO : ScriptableObject
    {
		[SerializeField]
		private float _Health;
		[SerializeField]
		private float _Price;
		public float Health
		{
			get { return _Health; }
			set { _Health = value; }
		}
	public float Price
	{
		get { return _Price; }
		set { _Price = value; }
	}

	}

