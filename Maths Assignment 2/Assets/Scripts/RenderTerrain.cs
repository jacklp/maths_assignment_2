// CITED FROM: http://answers.unity3d.com/questions/628730/import-8bit-raw-file-and-16bit-explanation.html


using UnityEngine;
using System.Collections;
using System.IO;

public class RenderTerrain : MonoBehaviour
{
	// Private methods.
	//----------------------------------------------------------------------------------------------
	private void Start()
	{
		m_terrain = ( Terrain ) gameObject.GetComponent( "Terrain" );
		m_resolution = m_terrain.terrainData.heightmapResolution;
		m_heightValues = new float[ m_resolution, m_resolution ];
		LoadHeightmap();
	}

	private void LoadHeightmap()
	{

		System.IO.FileInfo fi = new System.IO.FileInfo(Application.dataPath + "/Resources/heightmap.raw");

		int size =  m_resolution*m_resolution*2;

		System.IO.FileStream fs = fi.OpenRead();

		byte[] data = new byte[size];
		fs.Read(data, 0, size);
		fs.Close();



		//bool bigendian = (m_rawByteOrder == BYTE_ORDER.Mac) ? true : false;

		int i=0;

		for(int x = 0 ; x < m_resolution; x++) 
		{
			for(int y = 0; y < m_resolution; y++) 
			{
				//Extract 16 bit data and normalize.
				//float ht = (bigendian) ? (data[i++]*256.0f + data[i++]) : (data[i++] + data[i++]*256.0f);

				//16 bit MAC
				float ht = (data[i++]*256.0f + data[i++]);

				//16 bit PC
				//float ht = (data[i++] + data[i++]*256.0f);


				m_heightValues[m_resolution-x-1,y] = ht / 65535.0f;
			}
		};


		m_terrain.terrainData.SetHeights( 0, 0, m_heightValues );
	
	}

	// Member variables.
	//----------------------------------------------------------------------------------------------
	private Terrain    m_terrain      = null;
	private float[ , ] m_heightValues = null;
	private int        m_resolution   = 0;
}