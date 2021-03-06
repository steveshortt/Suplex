﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Suplex.Security.Principal
{
    public class Group : SecurityPrincipalBase
    {
        new public event PropertyChangedEventHandler PropertyChanged;

        public override bool IsUser { get { return false; } set { /*no-op*/ } }

        private byte[] _mask;
        public virtual byte[] Mask
        {
            get => _mask;
            set
            {
                if( value != _mask )
                {
                    _mask = value;
                    IsDirty = true;
                    PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( Mask ) ) );
                }
            }
        }

        public ObservableCollection<Group> Groups { get; set; }



        public override ISecurityPrincipal Clone(bool shallow = true)
        {
            return MemberwiseClone() as Group;
        }
        public override void Sync(ISecurityPrincipal source, bool shallow = true)
        {
            Sync( source as Group, shallow );
        }
        public void Sync(Group source, bool shallow = true)
        {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );

            base.Sync( source, shallow );
            Mask = source.Mask;
        }
    }
}