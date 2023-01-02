using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("material")]
	public class ES3UserType_Renderer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Renderer() : base(typeof(UnityEngine.Renderer)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Renderer)obj;
			
			writer.WritePropertyByRef("material", instance.material);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Renderer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "material":
						instance.material = reader.Read<UnityEngine.Material>(ES3Type_Material.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_RendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RendererArray() : base(typeof(UnityEngine.Renderer[]), ES3UserType_Renderer.Instance)
		{
			Instance = this;
		}
	}
}