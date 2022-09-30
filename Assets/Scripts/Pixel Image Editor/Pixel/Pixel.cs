using System.Collections;
using UnityEngine;
using StardropTools;
using StardropTools.Pool;

namespace PixelEditor
{
    /// <summary>
    /// Object that represents a pixel in the image
    /// </summary>
    public class Pixel : BaseObject, IPoolable<Pixel>
    {
        [SerializeField] PixelData data;
        [SerializeField] new MeshRenderer renderer;

        protected private PoolItem<Pixel> poolItem;

        public void SetPixelData(PixelData newData)
        {
            data = newData;

            WorldPosition = data.position;
            renderer.sharedMaterial.color = data.color;
        }

        #region Poolable

        public void OnDespawn()
        {

        }

        public void OnSpawn()
        {

        }

        public void SetPoolItem(PoolItem<Pixel> poolItem) => this.poolItem = poolItem;

        public void Despawn() => poolItem.Despawn();

        #endregion // Poolable
    }
}