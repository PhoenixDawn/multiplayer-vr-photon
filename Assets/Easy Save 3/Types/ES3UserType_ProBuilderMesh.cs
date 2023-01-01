using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_ProBuilderMesh : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ProBuilderMesh() : base(typeof(UnityEngine.ProBuilder.ProBuilderMesh)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.ProBuilder.ProBuilderMesh)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.ProBuilder.ProBuilderMesh)obj;
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


	public class ES3UserType_ProBuilderMeshArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ProBuilderMeshArray() : base(typeof(UnityEngine.ProBuilder.ProBuilderMesh[]), ES3UserType_ProBuilderMesh.Instance)
		{
			Instance = this;
		}
	}
}