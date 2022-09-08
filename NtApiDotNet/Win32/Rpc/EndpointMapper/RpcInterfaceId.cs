﻿//  Copyright 2022 Google LLC. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;

namespace NtApiDotNet.Win32.Rpc.EndpointMapper
{
    internal sealed class RpcInterfaceId
    {
        public Guid Uuid { get; }
        public Version Version { get; }

        public RpcInterfaceId(Guid uuid) : this(uuid, new Version())
        {
        }

        public RpcInterfaceId(Guid uuid, Version version)
        {
            Uuid = uuid;
            Version = version ?? throw new ArgumentNullException(nameof(version));
        }

        public RPC_IF_ID_EPT ToRpcIfId()
        {
            return new RPC_IF_ID_EPT()
            {
                Uuid = Uuid,
                VersMajor = (short)Version.Major,
                VersMinor = (short)Version.Minor
            };
        }
    }
}