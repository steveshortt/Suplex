﻿using System;
using System.Collections.Generic;

namespace Suplex.Security.AclModel
{
    public static class AccessControlEntryUtilities
    {
        public static IAccessControlEntry MakeAceFromRightType(string rightTypeName, Dictionary<string, string> props = null, bool isAuditAce = false)
        {
            Type rightType = Type.GetType( rightTypeName );
            return MakeGenericAceFromType( rightType, props, isAuditAce );
        }
        public static IAccessControlEntry MakeGenericAceFromType(Type rightType, Dictionary<string, string> props = null, bool isAuditAce = false)
        {
            rightType.ValidateIsEnum();

            IAccessControlEntry ace = null;

            Type objectType = isAuditAce ? typeof( AccessControlEntryAudit<> ) : typeof( AccessControlEntry<> );
            Type genericType = objectType.MakeGenericType( rightType );
            object instance = Activator.CreateInstance( genericType );
            ace = (IAccessControlEntry)instance;
            IAccessControlEntryAudit auditAce = isAuditAce ? (IAccessControlEntryAudit)ace : null;

            if( props?.Count > 0 )
            {
                foreach( string prop in props.Keys )
                {
                    if( prop.Equals( nameof( ace.UId ) ) )
                        ace.UId = Guid.Parse( props[prop] );
                    else if( prop.Equals( RightFields.Right ) )
                        ace.SetRight( props[prop] );
                    else if( prop.Equals( nameof( ace.Allowed ) ) )
                        ace.Allowed = bool.Parse( props[prop] );
                    else if( isAuditAce && prop.Equals( nameof( auditAce.Denied ) ) )
                        auditAce.Denied = bool.Parse( props[prop] );
                    else if( prop.Equals( nameof( ace.Inheritable ) ) )
                        ace.Inheritable = bool.Parse( props[prop] );
                    else if( prop.Equals( nameof( ace.InheritedFrom ) ) )
                        ace.InheritedFrom = Guid.Parse( props[prop] );
                    else if( prop.Equals( nameof( ace.TrusteeUId ) ) )
                        ace.TrusteeUId = Guid.Parse( props[prop] );
                }
            }

            return ace;
        }
    }
}