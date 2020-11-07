using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace VRoidSDK.Editor
{
    public class ManifestXmlDocument
    {
        private XmlDocument _manifestDocument;
        private const string AndroidNamespaceUri = "http://schemas.android.com/apk/res/android";

        public ManifestXmlDocument(XmlDocument doc)
        {
            _manifestDocument = doc;
        }

        public void Save(string path)
        {
            _manifestDocument.Save(path);
        }

        public void UpdateUrlScheme(Uri uri)
        {
            List<XmlNode> categoryNodes = FindChildrenNodeByName(_manifestDocument, "category");

            IEnumerable<IGrouping<XmlNode, XmlNode>> nodeCategories = categoryNodes.GroupBy((node) => node.ParentNode);
            foreach (IGrouping<XmlNode, XmlNode> parentCategories in nodeCategories)
            {
                if (HasDefaultBrowsableCategory(parentCategories))
                {
                    List<XmlNode> parentCategoryNodes = FindBrotherNodes(parentCategories);
                    var dataNode = FindUri(parentCategoryNodes, uri);
                    if (dataNode != null)
                    {
                        continue;
                    }

                    dataNode = _manifestDocument.CreateElement("data");
                    parentCategories.Key.AppendChild(dataNode);
                    SetSchemeHostPair(dataNode, uri);
                }
            }

            return;
        }

        private bool HasDefaultBrowsableCategory(IGrouping<XmlNode, XmlNode> parentCategories)
        {
            return parentCategories.Any((categoryNode) =>
            {
                var node = categoryNode.Attributes.GetNamedItem("name", AndroidNamespaceUri);
                return (
                    node != null &&
                    (node.Value == "android.intent.category.DEFAULT" ||
                    node.Value == "android.intent.category.BROWSABLE")
                );
            });
        }

        private List<XmlNode> FindBrotherNodes(IGrouping<XmlNode, XmlNode> parentCategories)
        {
            return parentCategories.SelectMany((group) =>
            {
                var pNode = group.ParentNode;
                List<XmlNode> list = new List<XmlNode>();
                foreach (XmlNode i in pNode.ChildNodes)
                {
                    list.Add(i);
                }

                return list;
            }).ToList();
        }

        private XmlNode FindUri(List<XmlNode> parentCategoryNodes, Uri uri)
        {
            List<XmlNode> dataNodes = parentCategoryNodes.FindAll((node) => node.Name == "data");
            XmlNode dataNode = dataNodes.Find((node) =>
            {
                XmlAttributeCollection attrs = node.Attributes;
                if (attrs == null)
                {
                    return false;
                }

                XmlNode schemeAttr = attrs.GetNamedItem("scheme", AndroidNamespaceUri);
                if (!IsAttrSameValue(schemeAttr, uri.Scheme))
                {
                    return false;
                }

                XmlNode hostAttr = attrs.GetNamedItem("host", AndroidNamespaceUri);
                if (!IsAttrSameValue(hostAttr, uri.Authority))
                {
                    return false;
                }

                XmlNode pathAttr = attrs.GetNamedItem("path", AndroidNamespaceUri);
                return uri.LocalPath == "/" || IsAttrSameValue(pathAttr, uri.LocalPath);
            });

            return dataNode;
        }

        private bool IsAttrSameValue(XmlNode attribute, string expectedValue)
        {
            return attribute != null && attribute.Value == expectedValue;
        }

        private void SetSchemeHostPair(XmlNode dataNode, Uri uri)
        {
            XmlElement dataNodeElement = dataNode as XmlElement;
            dataNodeElement.SetAttribute("scheme", AndroidNamespaceUri, uri.Scheme);
            if (!string.IsNullOrEmpty(uri.Authority))
            {
                // host名も書き換え
                dataNodeElement.SetAttribute("host", AndroidNamespaceUri, uri.Authority);
            }
            if (uri.LocalPath != "/")
            {
                // path名も書き換え
                dataNodeElement.SetAttribute("path", AndroidNamespaceUri, uri.LocalPath);
            }
        }

        private List<XmlNode> FindChildrenNodeByName(XmlNode parent, string nodeName)
        {
            List<XmlNode> targetNodes = new List<XmlNode>();
            XmlNodeList children = parent.ChildNodes;
            for (int i = 0; i < children.Count; ++i)
            {
                if (children[i].Name == nodeName)
                {
                    targetNodes.Add(children[i]);
                }
                targetNodes.AddRange(FindChildrenNodeByName(children[i], nodeName));
            }
            return targetNodes;
        }
    }
}
