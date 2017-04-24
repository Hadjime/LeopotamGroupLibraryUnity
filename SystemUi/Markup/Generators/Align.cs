// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2017 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Math;
using LeopotamGroup.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LeopotamGroup.SystemUi.Markup.Generators {
    static class AlignNode {
        static readonly int HashedSide = "side".GetStableHashCode ();

        /// <summary>
        /// Create "align" node.
        /// </summary>
        /// <param name="go">Gameobject holder.</param>
        /// <param name="node">Xml node.</param>
        /// <param name="container">Markup container.</param>
        public static void Create (GameObject go, XmlNode node, MarkupContainer container) {
#if UNITY_EDITOR
            go.name = "align";
#endif
            var rt = go.GetComponent<RectTransform> ();
            var offset = Vector2.one * 0.5f;
            var attrValue = node.GetAttribute (HashedSide);
            if (!string.IsNullOrEmpty (attrValue)) {
                var parts = MarkupUtils.SplitAttrValue(attrValue);
                for (var i = 0; i < parts.Length; i++) {
                    switch (parts[i]) {
                        case "left":
                            offset.x = 0f;
                            break;
                        case "right":
                            offset.x = 1f;
                            break;
                        case "top":
                            offset.y = 1f;
                            break;
                        case "down":
                            offset.y = 0f;
                            break;
                    }
                }
            }

            rt.anchorMin = offset;
            rt.anchorMax = offset;
            rt.offsetMin = -Vector2.one * 0.5f;
            rt.offsetMax = -rt.offsetMin;

            MarkupUtils.SetHidden (go, node);
        }
    }
}