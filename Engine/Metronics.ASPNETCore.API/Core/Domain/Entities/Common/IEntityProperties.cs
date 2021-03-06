﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Core.Domain.Entities.Common
{
    #region Entity Identity
    public interface IEntity<Key>
    {
        public Key Id { get; set; }
    }
    public interface IEntity : IEntity<long>
    {
    }
    public class Entity<Key> : IEntity<Key>
    {
        public Key Id { get; set; }
    }
    public class Entity : Entity<long>
    {

    }
    #endregion

    #region Creation
    public interface ICreation<Key>
    {
        public Key CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public interface ICreation : ICreation<long?>
    {

    }
    public class Creation<Key> : ICreation<Key>
    {
        public Key CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public class Creation : Creation<long?>
    {

    }
    #endregion

    #region Modification
    public interface IModification<Key>
    {
        public Key LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
    public interface IModification : IModification<long?>
    {

    }
    public class Modification<Key> : IModification<Key>
    {
        public Key LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
    public class Modification : Modification<long?>
    {

    }
    #endregion

    #region Deletion
    public interface IDeletion<Key>
    {
        public Key DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public interface IDeletion : IDeletion<long?>
    {

    }
    public class Deletion<Key> : IDeletion<Key>
    {
        public Key DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public  class Deletion : Deletion<long?>
    {

    }
    #endregion

    #region Full Entity Properties
    public class FullEntity<Key> : IEntity<Key>, ICreation<long?>, IModification<long?>, IDeletion<long?>
    {
        public Key Id { get; set; }
        public long? CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class FullEntity<IdentityKey, CreationKey, ModificationKey, DeletionKey> : IEntity<IdentityKey>, ICreation<CreationKey>, IModification<ModificationKey>, IDeletion<DeletionKey>
    {
        public IdentityKey Id { get; set; }
        public CreationKey CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public ModificationKey LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public DeletionKey DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class FullEntity : FullEntity<long>
    {

    }
    public interface IFullEntityWithoutId : ICreation, IModification, IDeletion
    {

    }
    public class FullEntityWithoutId : IFullEntityWithoutId
    {
        public long? CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    #endregion
}
