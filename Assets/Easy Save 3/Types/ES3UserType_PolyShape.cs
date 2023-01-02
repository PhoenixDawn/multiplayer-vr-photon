using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_PolyShape : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PolyShape() : base(typeof(UnityEngine.ProBuilder.PolyShape)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.ProBuilder.PolyShape)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.ProBuilder.PolyShape)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PolyShapeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PolyShapeArray() : base(typeof(UnityEngine.ProBuilder.PolyShape[]), ES3UserType_PolyShape.Instance)
		{
			Instance = this;
		}
	}
}