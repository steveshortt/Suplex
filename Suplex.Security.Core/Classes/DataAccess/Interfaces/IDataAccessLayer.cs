﻿using System;
using System.Collections.Generic;

using Suplex.Security.AclModel;
using Suplex.Security.Principal;

namespace Suplex.Security.AclModel.DataAccess
{
    public interface IDataAccessLayer
    {
        User GetUserByUId(Guid userUId);
        List<User> GetUserByName(string name);
        User UpsertUser(User user);
        void DeleteUser(Guid userUId);

        Group GetGroupByUId(Guid groupUId);
        List<Group> GetGroupByName(string name);
        Group UpsertGroup(Group group);
        void DeleteGroup(Guid groupUId);

        List<Group> GetGroupMembership(Guid principalUId);
        List<ISecurityPrincipal> GetGroupMembers(Guid groupUId);

        ISecureObject GetSecureObjectByUId(Guid secureObjectUId, bool includeChildren);
        ISecureObject GetSecureObjectByUniqueName(string uniqueName, bool includeChildren);
        ISecureObject UpsertSecureObject(ISecureObject secureObject);
        void DeleteSecureObject(Guid secureObjectUId);
    }
}