﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using CoCEd.Model;

namespace CoCEd.ViewModel
{
    public sealed class KeyItemVM : NamedVector4VM
    {
        public KeyItemVM(GameVM game, AmfObject keyItems, XmlNamedVector4 xml)
            : base(game, keyItems, xml)
        {
        }

        protected override void InitializeObject(AmfObject obj)
        {
            obj["keyName"] = _xml.Name;
        }

        protected override bool IsObject(AmfObject obj)
        {
            return obj.GetString("keyName") == _xml.Name;
        }

        protected override void NotifyGameVM()
        {
            _game.OnKeyItemChanged(_xml.Name);
        }

        protected override void OnIsOwnedChanged()
        {
            VM.Instance.Game.OnKeyItemAddedOrRemoved(_xml.Name, IsOwned);
        }
    }
}
