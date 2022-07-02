﻿using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;
using System.Collections.Generic;
using System.Xml;

namespace BannerKings.UI.Extensions
{

    [PrefabExtension("KingdomManagement", "descendant::Widget[1]/Children", "KingdomManagement")]
    internal class KingdomManagementExtension : PrefabExtensionInsertPatch
    {
        public override InsertType Type => InsertType.Child;
        public override int Index => 4;

        private List<XmlNode> nodes;

        public KingdomManagementExtension()
        {
            XmlDocument firstChild = new XmlDocument();
            //XmlDocument secondChild = new XmlDocument();
            firstChild.LoadXml("<KingdomCourt Id=\"CourtPanel\" DataSource=\"{Court}\" MarginTop=\"188\" MarginBottom=\"75\" />");
            //secondChild.LoadXml("<KingdomDemesne Id=\"DemesnePanel\" DataSource=\"{Demesne}\" MarginTop=\"188\" MarginBottom=\"75\" />");
            nodes = new List<XmlNode> { firstChild };
        }

        [PrefabExtensionXmlNodes]
        public IEnumerable<XmlNode> Nodes => nodes;
        
    }

    [PrefabExtension("KingdomManagement", "descendant::Widget[@VisualDefinition='TopPanel']/Children/KingdomTabControlWidget[1]/Children", "KingdomManagement")]
    internal class KingdomManagementExtension2 : PrefabExtensionInsertPatch
    {
        public override InsertType Type => InsertType.Child;
        public override int Index => 2;

        private List<XmlNode> nodes;

        public KingdomManagementExtension2()
        {
            XmlDocument firstChild = new XmlDocument();
            //XmlDocument secondChild = new XmlDocument();
            firstChild.LoadXml("<ButtonWidget Id=\"CourtButton\" IsSelected=\"@CourtSelected\" DoNotPassEventsToChildren=\"true\" WidthSizePolicy=\"Fixed\" HeightSizePolicy=\"Fixed\" SuggestedWidth=\"!Header.Tab.Center.Width.Scaled\" SuggestedHeight=\"!Header.Tab.Center.Height.Scaled\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\" PositionYOffset=\"2\" MarginLeft=\"5\" Brush=\"Header.Tab.Center\" Command.Click=\"SelectCourt\" UpdateChildrenStates=\"true\"><Children><TextWidget WidthSizePolicy=\"CoverChildren\" HeightSizePolicy=\"CoverChildren\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\" Brush=\"Clan.TabControl.Text\" Text=\"@CourtText\" /></Children></ButtonWidget>");
            //secondChild.LoadXml("<ButtonWidget Id=\"DemesneButton\" IsSelected=\"@DemesneSelected\" DoNotPassEventsToChildren=\"true\" WidthSizePolicy=\"Fixed\" HeightSizePolicy=\"Fixed\" SuggestedWidth=\"!Header.Tab.Center.Width.Scaled\" SuggestedHeight=\"!Header.Tab.Center.Height.Scaled\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\" PositionYOffset=\"2\" MarginLeft=\"5\" Brush=\"Header.Tab.Center\" Command.Click=\"SelectDemesne\" UpdateChildrenStates=\"true\"><Children><TextWidget WidthSizePolicy=\"CoverChildren\" HeightSizePolicy=\"CoverChildren\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\" Brush=\"Clan.TabControl.Text\" Text=\"@DemesneText\" /></Children></ButtonWidget>");
            nodes = new List<XmlNode> { firstChild };
        }

        [PrefabExtensionXmlNodes]
        public IEnumerable<XmlNode> Nodes => nodes;

    }
}
