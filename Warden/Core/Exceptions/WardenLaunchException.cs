﻿using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Warden.Core.Exceptions
{
    [Serializable]
    public class WardenLaunchException : Exception
    {
        public WardenLaunchException()
        {
        }

        public WardenLaunchException(string message)
            : base(message)
        {
        }

        public WardenLaunchException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected WardenLaunchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        public string ResourceReferenceProperty { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}