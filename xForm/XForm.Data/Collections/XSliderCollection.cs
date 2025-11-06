using System;
using System.Collections;
using System.Collections.Specialized;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for XSliderCollection.
	/// </summary>
	public class XSliderCollection : NameObjectCollectionBase
	{
		private DictionaryEntry dictionaryEntry = new DictionaryEntry();
		
		public XSliderCollection()
		{
		}

		public XSliderCollection ( IDictionary d, Boolean bReadOnly )
		{
			foreach ( DictionaryEntry de in d)
			{ 
				this.BaseAdd(	(String) de.Key, de.Value );
			}
			this.IsReadOnly = bReadOnly;
		}

		public XSlider this[ int index ]
		{
			get
			{
				return(	(XSlider) base.BaseGet(index)	);
			}
		}

		public XSlider this[ String key ]
		{
			get
			{
				return(	(XSlider) this.BaseGet( key	)	);
			}
			set
			{
				this.BaseSet(	key, value );
			}
		}

		public String[] Allkeys
		{
			get
			{
				return(	this.BaseGetAllKeys()	);
			}
		}

		public Array AllValues
		{
			get
			{	
				return(	this.BaseGetAllValues()	);
			}
		}

		public String[] AllStringValues
		{
			get
			{
				return(	(String[]) this.BaseGetAllValues( Type.GetType( "System.String")));
			}
		}

		public Boolean HasKeys
		{
			get
			{
				return( this.BaseHasKeys()	);
			}
		}

		public void Add ( String key, XSlider value)
		{
			this.BaseAdd ( key, value );
		}
	
		public void Remove (String key)
		{
			this.BaseRemove ( key );
		}

		public void Remove(int index )
		{
			this.BaseRemoveAt ( index );
		}

		public void Clear()
		{
			this.BaseClear();
		}
	}
}
