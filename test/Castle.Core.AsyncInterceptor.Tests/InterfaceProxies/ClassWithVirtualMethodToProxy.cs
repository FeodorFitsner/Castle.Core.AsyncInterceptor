﻿// Copyright (c) 2016 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Castle.DynamicProxy.InterfaceProxies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClassWithVirtualMethodToProxy
    {
        private readonly List<string> _log;

        protected ClassWithVirtualMethodToProxy()
            : this(new List<string>())
        {
        }

        public ClassWithVirtualMethodToProxy(List<string> log)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            _log = log;
        }

        public IReadOnlyList<string> Log => _log;

        public virtual async Task<Guid> AsynchronousResultMethod()
        {
            _log.Add($"{nameof(AsynchronousResultMethod)}:Start");
            await Task.Delay(10);
            _log.Add($"{nameof(AsynchronousResultMethod)}:End");
            return Guid.NewGuid();
        }
    }
}
