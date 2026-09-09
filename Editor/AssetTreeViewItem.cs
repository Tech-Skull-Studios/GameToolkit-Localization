// Copyright (c) H. Ibrahim Penekli. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEditor.IMGUI.Controls;

namespace GameToolkit.Localization.Editor
{
    #if UNITY_6000_5_OR_NEWER
    public class AssetTreeViewItem : TreeViewItem<int>
    #else
    public class AssetTreeViewItem : TreeViewItem
    #endif
    {
        private bool m_IsDirty;

        /// <summary>
        /// Gets or sets item as dirty. Added "*" postfix to the display name if is dirty.
        /// </summary>
        public bool IsDirty
        {
            get { return m_IsDirty; }
            set
            {
                m_IsDirty = value;
                if (value)
                {
                    displayName = LocalizedAsset.name + "*";
                }
                else
                {
                    displayName = LocalizedAsset.name;
                }
            }
        }

        public LocalizedAssetBase LocalizedAsset { get; private set; }

        #if UNITY_6000_5_OR_NEWER
        public AssetTreeViewItem(int id, int depth, LocalizedAssetBase data) : base(id, depth, data.name)
        #else
        public AssetTreeViewItem(int depth, LocalizedAssetBase data) : base(data.GetInstanceID(), depth, data.name)
        #endif
        {
            LocalizedAsset = data;
        }
    }
}
